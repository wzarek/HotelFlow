import React from 'react'

const SubmitInput = ({name, text}) => {

  return (
    <div className='absolute bottom-[-6rem] left-[5.5rem]'>
        <input className='animate-glow w-[10rem] h-[3rem] text-white bg-blue-600 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium p-[.5rem] rounded-lg ease-out duration-100 hover:bg-blue-800' type="submit" id={name} name={name} value={text} />
    </div>
  )
}

export default SubmitInput