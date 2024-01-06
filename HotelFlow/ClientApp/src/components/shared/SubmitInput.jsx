import React from 'react'

const SubmitInput = ({name, text}) => {

  return (
    <div className='absolute bottom-[-6rem] left-[5.5rem]'>
        <input className='animate-glow w-[10rem] h-[3rem] bg-blue-600 p-[.5rem] rounded-lg text-white ease-out duration-100 hover:scale-110 hover:bg-black' type="submit" id={name} name={name} value={text} />
    </div>
  )
}

export default SubmitInput