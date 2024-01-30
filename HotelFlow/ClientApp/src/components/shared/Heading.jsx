import React from 'react'

const Heading = ({text}) => {
  return (
    <div className='flex justify-between items-center gap-[2rem] relative z-10 w-full mb-[5rem]'>
        <div className='w-[30vw] h-[5px] bg-black rounded-lg'></div>
        <h1 className='font-semibold text-[2.5rem] whitespace-nowrap'>{text}</h1>
        <div className='w-full h-[5px] bg-black rounded-lg'></div>
      </div>
  )
}

export default Heading