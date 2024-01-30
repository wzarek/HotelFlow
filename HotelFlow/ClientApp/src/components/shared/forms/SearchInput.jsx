import React, { useState } from 'react'

const SearchInput = ({type, name, label, defaultValue}) => {
  const [inputValue, setInputValue] = useState(defaultValue)

  return (
    <div className='flex justify-between items-center my-[.5rem]'>
        {
          label ? <label htmlFor={name}>{label}</label> : <></>
        }
        {
          label ? <input value={inputValue} onChange={(e) => setInputValue(e.target.value)} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type={type} id={name} name={name} /> : <input value={inputValue} onChange={(e) => setInputValue(e.target.value)} className='w-[100%] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type={type} id={name} name={name} />
        }
    </div>
  )
}

export default SearchInput