import React from 'react'
import { createSearchParams, useNavigate } from 'react-router-dom'

const SearchForm = () => {
  const navigate = useNavigate()
  
  const dateFromDefault = new Date()
  const dateToDefault = new Date()
  dateToDefault.setDate(dateFromDefault.getDate() + 2)

  const handleSearchSubmit = (e) => {
    e.preventDefault()

    let {dateFrom, dateTo, numPeople} = document.forms[0]

    let params = createSearchParams({dateFrom: dateFrom.value, dateTo: dateTo.value, numPeople: numPeople.value})

    navigate({
      pathname: '/find-room',
      search: `?${params}`,
    })
  }

  return (
    <form onSubmit={handleSearchSubmit} className='relative'>
      <div className='flex justify-between items-center my-[.5rem]'>
        <label htmlFor='dateFrom'>od</label>
        <input defaultValue={dateFromDefault.toLocaleDateString('en-CA')} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type='date' id='dateFrom' name='dateFrom' />
      </div>
      <div className='flex justify-between items-center my-[.5rem]'>
        <label htmlFor='dateTo'>do</label>
        <input defaultValue={dateToDefault.toLocaleDateString('en-CA')} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type='date' id='dateTo' name='dateTo' />
      </div>
      <div className='flex justify-between items-center my-[.5rem]'>
        <label htmlFor='numPeople'>ilość osób</label>
        <input defaultValue={2} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type='number' min={1} max={6} id='numPeople' name='numPeople' />
      </div>
      <div className='absolute bottom-[-6rem] left-[5.5rem]'>
        <input className='animate-glow w-[10rem] h-[3rem] text-white bg-blue-600 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium p-[.5rem] rounded-lg ease-out duration-100 hover:bg-blue-800' type="submit" id="submitButton" name="submitButton" value="szukaj" />
      </div>
    </form>
  )
}

export default SearchForm