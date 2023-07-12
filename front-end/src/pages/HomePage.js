import React from 'react'
import UserCard from '../components/common/UserCard'
import Carousel from '../components/common/Carousel'
import Footer from '../components/common/Footer'

function HomePage() {
  return (
    <div>

      {/* <----------------Landing Page Card ------------------>*/}

      <div className="flex justify-center pb-10">
        <div className="card w-4/5 bg-base-100 shadow-xl rounded-xl">
            <figure className="px-10 pt-10">
                <img src="https://2716595.fs1.hubspotusercontent-na1.net/hubfs/2716595/how-to-start-a-daycare-in-nevada_11zon.jpg" alt="Shoes" className="rounded-xl blur-sm" />
   
            </figure>
            {/* <div className='bg-black/10 absolute top-0 left-0 w-full h-screen' />
            <div className='absolute text-2xl md:text-7xl text-white top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2'>
                <p className='tex-red-700'>I am Morgan Freeman</p>
            </div> */}
        </div>
      </div>

      {/* <-----------------HHCC Services --------------------->*/}
      <h1 className="text-4xl font-bold text-center pt-6 pb-6">Our Services</h1>

      <div className="grid grid-cols-2 gap-4 gap-y-6 pt-6">
        <div className="col-span-1 flex justify-center">
            {/* card on left */}
            <div className="card w-3/5 bg-base-200 shadow-xl">
                <figure className="px-10 pt-10 pb-10">
                    <img src="https://st.depositphotos.com/1000137/4664/i/600/depositphotos_46644109-stock-photo-cute-children-drawing-with-teacher.jpg" className="max-w-xs rounded-xl" />
                </figure>
            </div>
        </div>
        
        <div className="col-span-1 pt-28 pl-8 pr-8">
            <h2 className="text-xl font-bold mb-2">Day Care</h2>
            <p>HHCC's day care service provides a safe and enriching environment for children, where they can explore, learn, and develop their skills under the guidance of compassionate and dedicated caregivers.</p>
        </div>

        
        <div className="col-span-1 pt-20 pl-16 pr-8">
            <h2 className="text-xl font-bold mb-2">Dog Day Care</h2>
            <p>HHCC's dog day care service offers a fun and supervised space for furry friends to socialize, exercise, and receive personalized care, ensuring a tail-wagging experience for every canine companion.</p>
        </div>

        <div className="col-span-1 flex justify-center pt-6">
            {/* card on left */}
            
            <div className="card w-3/5 bg-base-200 shadow-xl">
                <figure className="px-10 pt-10 pb-10">
                    <img src="https://www.petlovercentral.com/wp-content/uploads/2019/05/image-petlovercentral3.jpg" className="max-w-xs rounded-xl" />
                </figure>
            </div>
        </div>

        <div className="col-span-1 flex justify-center pt-6">
            {/* card on left */}
            <div className="card w-3/5 bg-base-200 shadow-xl">
                <figure className="px-10 pt-10 pb-10">
                    <img src="https://dlyhjlf6lts50.cloudfront.net/app/uploads/2019/02/AdultDayMeal.png" className="max-w-xs rounded-xl" />
                </figure>
            </div>
        </div>

        
        <div className="col-span-1 pt-20 pl-8 pr-8">
            <h2 className="text-xl font-bold mb-2">Adult Day Care</h2>
            <p>HHCC offers a comprehensive day care service for the elderly, providing a supportive and engaging environment where seniors can socialize, participate in meaningful activities, and receive personalized care, promoting their overall well-being and enhancing their quality of life.</p>
        </div>
      </div>

      {/* <--------------------HHCC Center Pictures ---------------------->*/}

      <h1 className="text-4xl font-bold text-center pt-20">Our Centers</h1>

      <div className="flex justify-center pt-6">
        <div className="card card-compact w-9/10 bg-base-100 shadow-xl">
            <div className="card-body">
            <Carousel />
            </div>
        </div>
      </div>
      
      <div className="pt-6">
            <Footer />
      </div>
    </div>
  )
}

export default HomePage