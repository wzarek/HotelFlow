import React from 'react'
import SubmitInput from './SubmitInput'

const RoomCard = ({dateFrom, dateTo, name, price, numPerson, img}) => {
  return (
    <div className='group cursor-pointer relative p-[3rem] pb-[2rem] bg-white shadow-lg w-[100%] rounded-2xl duration-100 hover:scale-105'>
        <div className='bg-black w-full aspect-square rounded-lg overflow-hidden'>
          <img className='aspect-square w-full object-cover duration-100 group-hover:scale-110' src={img} />
        </div>
        <p className='absolute top-[1rem] left-[3rem] text-blue-600 font-bold duration-100 group-hover:scale-110 group-hover:translate-x-[75%] group-hover:text-red-600'>{dateFrom} - {dateTo}</p>
        <div className='pt-[.5rem] w-full flex justify-between items-center'>
            <p className='text-[0.8rem] font-medium duration-100 group-hover:text-red-600 group-hover:scale-110 group-hover:translate-x-[15%]'>{price} zł / {numPerson} pers.</p>
        </div>
        <div className='w-full flex justify-between items-center'>
            <h4 className='text-[1.25rem] font-medium duration-100 group-hover:scale-110 group-hover:translate-x-[10%]'>{name}</h4>
            <a href="" className='text-[1.5rem] text-blue-600 font-bold duration-100 group-hover:scale-110 group-hover:translate-x-[-100%]'>{'>'}</a>
        </div>
    </div>
  )
}

export default RoomCard