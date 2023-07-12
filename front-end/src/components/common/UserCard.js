import React from 'react'
import users from "../../mockdata/users.json";
import { Link } from 'react-router-dom';

function UserCard() {
  return (
    <div className="card w-3/4 bg-base-200 shadow-sm hover:shadow-lg pt-4">
        
        <div className="card-body items-center text-center space-y-2 pt-4">
            <h2 className="card-title">Dependent Name</h2>
            <p className="font-semibold">Last Visit: </p>
            <button className="btn btn-primary w-64">Edit</button>
            <div className="card-actions justify-end">

            
                {/* You can open the modal using ID.showModal() method */}
                
                <button className="btn btn-info w-64" onClick={()=>window.my_modal_3.showModal()}>View Dependent</button>
                <dialog id="my_modal_3" className="modal">
                <form method="dialog" className="modal-box">

                    

                    <div className="flex justify-left">
                        <h3 className="text-lg font-bold pt-4">Dependent Information</h3>
                    </div>

                    <div className="divider" />

                    {users.dependents.map((dependent, index) => (
                        <div key={index}>
                            <h3 className="text-lg text-left font-bold pt-4">Dependent: {dependent.firstName} {dependent.lastName}</h3>
                            <h3 className="text-lg text-left font-bold pt-4">Care Giver: {dependent.user}</h3>

                            <div className="divider" />

                            {/* accomodations */}
                            <h3 className="text-lg font-bold text-left pb-4">Accomodations</h3>

                            
                            <div className="overflow-x-auto">
                                <table className="table w-full">
                                    <thead>
                                        <tr>
                                            <th>Special Needs</th>
                                            <td>{dependent.accomodiations.specialNeeds}</td>
                                        </tr>
                                        <tr>
                                            <th>Allergies</th>
                                            <tr>{dependent.accomodiations.allergies}</tr>
                                        </tr>
                                        <tr>
                                            <th>Diet</th>
                                            <tr>{dependent.accomodiations.diet}</tr>
                                        </tr>
                                    </thead>
                                </table>
                            </div>

                        </div>
                    ))}

                    

                    {/* info */}
                    <div className="divider" />

                    

                    
                    <div className="divider" />


                    <button className="btn btn-sm btn-circle btn-ghost absolute right-2 top-2">✕</button>

                    {/* <p className="py-4">Press ESC key or click on ✕ button to close</p> */}
                </form>
                </dialog>
            
            </div>
        </div>
    </div>
  )
}

export default UserCard