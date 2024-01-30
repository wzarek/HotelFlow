import React from 'react'
import SearchForm from '../shared/SearchForm'
import {ReactComponent as HomeHotelSvg} from '../../imgs/HomeHotel.svg'
import {ReactComponent as TimeSvg} from '../../imgs/TimeTicking.svg'
import {ReactComponent as GoDown} from '../../imgs/GoDown.svg'
import RoomSingle from '../../imgs/tmp/RoomSingle.jpg'
import RoomDouble from '../../imgs/tmp/RoomDouble.jpg'
import RoomTriple from '../../imgs/tmp/RoomTriple.jpg'
import RoomQuadruple from '../../imgs/tmp/RoomQuadruple.jpg'
import RoomCard from '../shared/RoomCard'

const Home = () => {
    return (
        <main>
            <section className='py-[10em] bg-gray-300 w-full flex items-center gap-[5rem] relative rounded-b-[30em] pb-[15em]'>
                <HomeHotelSvg className='absolute w-1/2 right-[15rem] top-[-11rem] z-0 opacity-30 pointer-events-none' />
                <h1 className='w-[45%] font-medium text-[5rem] text-right relative z-10'>welcome to <span className='text-blue-600 font-semibold text-[6rem]'>HotelFlow!</span></h1>
                <section className='p-[4em] bg-white rounded-2xl w-1/4 relative z-10'>
                    <h2 className='text-[1.5rem] font-medium mb-[2rem] text-center'>how about your trip?</h2>
                    <SearchForm />
                </section>
                <GoDown className="absolute z-0 w-[10rem] bottom-[-5rem] right-[47%] animate-button-down duration-100"/>
            </section>
            <section className='w-[80%] mx-auto mt-[10rem] relative'>
                <div className='flex justify-between items-center gap-[2rem] relative z-10'>
                    <div className='w-1/4 h-[5px] bg-black rounded-lg'></div>
                    <h3 className='font-semibold text-[2.5rem] whitespace-nowrap'>limited offer</h3>
                    <div className='w-full h-[5px] bg-black rounded-lg'></div>
                </div>
                <TimeSvg className='absolute w-1/2 left-[-25rem] bottom-[-7rem] z-0 opacity-30' />
                <section className='grid grid-cols-4 mt-[2rem] gap-[3rem]'>
                    <RoomCard name='single room' dateFrom='04.11' dateTo='05.11' img={RoomSingle} price={100} numPerson={1} />
                    <RoomCard name='double room' dateFrom='11.11' dateTo='12.11' img={RoomDouble} price={150} numPerson={2} />
                    <RoomCard name='triple room' dateFrom='28.10' dateTo='29.10' img={RoomTriple} price={230} numPerson={3} />
                    <RoomCard name='quadruple room' dateFrom='12.12' dateTo='13.12' img={RoomQuadruple} price={330} numPerson={4} />
                </section>
            </section>
        </main>
    )
}

export default Home