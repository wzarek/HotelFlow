import React, { useEffect, useState } from 'react'
import RoomSingle from '../../../imgs/tmp/RoomSingle.jpg'
import RoomDouble from '../../../imgs/tmp/RoomDouble.jpg'
import RoomTriple from '../../../imgs/tmp/RoomTriple.jpg'
import RoomQuadruple from '../../../imgs/tmp/RoomQuadruple.jpg'
import RoomCard from '../../shared/RoomCard'
import SubmitInputSecondary from '../forms/SubmitInputSecondary'
import Heading from '../Heading'
import { createSearchParams, useNavigate, useSearchParams } from 'react-router-dom'

const RoomSearch = () => {
  const navigate = useNavigate()
  const [searchParams, setSearchParams] = useSearchParams()
  const [defaultDateFrom, setDefaultDateFrom] = useState(null)
  const [defaultDateTo, setDefaultDateTo] = useState(null)
  const [defaultNumPeople, setDefaultNumPeople] = useState(null)

  useEffect(() => {
    setDefaultDateFrom(searchParams.get('dateFrom') ?? null)
    setDefaultDateTo(searchParams.get('dateTo') ?? null)
    setDefaultNumPeople(searchParams.get('numPeople') ?? null)
  }, [])

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
      <main className='min-h-[80vh] w-[90vw] mx-auto flex flex-wrap justify-evenly items-start pt-[12vh]'>
        <Heading text='znajdź pokój' />
        <aside className='sticky top-[15vh] p-[2em] bg-gradient-to-b from-blue-100 to-blue-200 rounded-2xl w-1/5 h-[70vh] z-10 shadow flex flex-col gap-[3em]'>
          <h3 className='text-[1.5rem] font-medium mb-[2rem] text-center'>filtry</h3>
          <form onSubmit={handleSearchSubmit} className='flex flex-col justify-start h-full'>
          <div className='flex justify-between items-center my-[.5rem]'>
            <label htmlFor='dateFrom'>od</label>
            <input defaultValue={defaultDateFrom} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type='date' id='dateFrom' name='dateFrom' />
          </div>
          <div className='flex justify-between items-center my-[.5rem]'>
            <label htmlFor='dateTo'>do</label>
            <input defaultValue={defaultDateTo} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type='date' id='dateTo' name='dateTo' />
          </div>
          <div className='flex justify-between items-center my-[.5rem]'>
            <label htmlFor='numPeople'>ilość osób</label>
            <input defaultValue={defaultNumPeople} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type='number' min={1} max={4} id='numPeople' name='numPeople' />
          </div>
            <SubmitInputSecondary classes='mt-auto' name='submit' text='filtruj' />
          </form>
        </aside>
        <section className='w-2/3 grid grid-cols-3 gap-3'>
          <RoomCard name='pokój dla singla' img={RoomSingle} price={100} numPerson={1} />
          <RoomCard name='pokój dla pary' img={RoomDouble} price={150} numPerson={2} />
          <RoomCard name='pokój dla trójki' img={RoomTriple} price={230} numPerson={3} />
          <RoomCard name='pokój dla czwórki' img={RoomQuadruple} price={330} numPerson={4} />
          <RoomCard name='pokój dla singla' img={RoomSingle} price={100} numPerson={1} />
          <RoomCard name='pokój dla pary' img={RoomDouble} price={150} numPerson={2} />
          <RoomCard name='pokój dla trójki' img={RoomTriple} price={230} numPerson={3} />
          <RoomCard name='pokój dla czwórki' img={RoomQuadruple} price={330} numPerson={4} />
        </section>
      </main>
  )
}

export default RoomSearch