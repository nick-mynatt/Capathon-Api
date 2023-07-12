using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using AutoMapper;
using Capathon.Dtos.User;
using Capathon.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Capathon.Services
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>{
            new User {  UId = 1, CId = 1, DIds = "",
                        Username = "username", Password = "Password", 
                        FirstName = "Nick", LastName = "Mynatt", 
                        PhoneNumber = "123456789", Email = "nick.mynatt@capgemini.com", Address = "123 Street",
                        Dependents = new List<Dependent>(),
            },
        };

        private readonly IMapper _mapper;
        private readonly CapathonBroadwayContext _dataContext;

        public UserService(IMapper mapper, CapathonBroadwayContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var dbCareCenters = await _dataContext.Users.ToListAsync();
            serviceResponse.Data = dbCareCenters.Select(d => _mapper.Map<GetUserDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = _dataContext.Users.FirstOrDefaultAsync(i => i.CId == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var user = _mapper.Map<User>(newUser);

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = 
                await _dataContext.Users.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                var user = 
                    await _dataContext.Users.FirstOrDefaultAsync(i => i.UId == updatedUser.UId);
                if (user == null)
                    throw new Exception($"User with Id {updatedUser.CId} not found.");
                
                user.DIds = updatedUser.DIds;
                user.CId = updatedUser.CId;
                user.Username = updatedUser.Username;
                user.Password = updatedUser.Password;
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.PhoneNumber = updatedUser.PhoneNumber;
                user.Email = updatedUser.Email;
                user.Address = updatedUser.Address;

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync(i => i.UId == id);
                if (user == null)
                    throw new Exception($"User with Id {id} not found.");

                _dataContext.Users.Remove(user);

                serviceResponse.Data = await _dataContext.Users.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}