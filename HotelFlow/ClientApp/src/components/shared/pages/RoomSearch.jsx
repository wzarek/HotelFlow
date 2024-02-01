import React, { useEffect, useState } from 'react'
import RoomCard from '../../shared/RoomCard'
import SubmitInputSecondary from '../forms/SubmitInputSecondary'
import Heading from '../Heading'
import { createSearchParams, useNavigate, useSearchParams } from 'react-router-dom'
import { URL_BASE, fetchPOSTJSONData } from '../../../services/databaseServices'
import { RoomToGet } from '../../../models/room/roomHelpers'

const RoomSearch = () => {
  const navigate = useNavigate()
  const [searchParams, setSearchParams] = useSearchParams()
  const [defaultDateFrom, setDefaultDateFrom] = useState(null)
  const [defaultDateTo, setDefaultDateTo] = useState(null)
  const [defaultNumPeople, setDefaultNumPeople] = useState(null)
  const [rooms, setRooms] = useState([])
  const [error, setError] = useState('')
  const [filterError, setFilterError] = useState('')
  const [loading, setLoading] = useState(false)

  const fetchData = async (data) => {
    try{
        setLoading(true)
        setFilterError('')

        let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/rooms/allfiltered`, JSON.stringify(data))
        let roomsData = RoomToGet.fromJSONList(JSON.stringify(JSONdata))

        setRooms(roomsData)
        setLoading(false)
      }catch(err){
        console.error(err)
        setError(err.message)
        setLoading(false)
      }
  } 

  useEffect(() => {
    setDefaultDateFrom(searchParams.get('dateFrom') ?? null)
    setDefaultDateTo(searchParams.get('dateTo') ?? null)
    setDefaultNumPeople(searchParams.get('numPeople') ?? null)

    let dateFromF = searchParams.get('dateFrom') ? searchParams.get('dateFrom') : null
    let dateToF = searchParams.get('dateTo') ? searchParams.get('dateTo') : null
    let numPeopleF = searchParams.get('numPeople') ? searchParams.get('numPeople') : 0

    fetchData({dateFrom: dateFromF, dateTo: dateToF, numberOfPeople: numPeopleF})
  }, [])

  const handleSearchSubmit = (e) => {
    e.preventDefault()

    let {dateFrom, dateTo, numPeople} = document.forms[0]
    let params = createSearchParams({dateFrom: dateFrom.value, dateTo: dateTo.value, numPeople: numPeople.value})

    navigate({
      pathname: '/find-room',
      search: `?${params}`,
    })

    let dateFromF = dateFrom.value ? dateFrom.value : null
    let dateToF = dateTo.value ? dateTo.value : null
    let numPeopleF = numPeople.value ? numPeople.value : 0

    fetchData({dateFrom: dateFromF, dateTo: dateToF, numberOfPeople: numPeopleF})
  }

  const handleGoToReservation = (number) => {
    if (!defaultDateFrom || !defaultDateTo || !defaultNumPeople){
      setFilterError('Wypełnij filtry, aby przejść do rezerwacji pokoju!')
      return
    }
    let params = createSearchParams({dateFrom: defaultDateFrom, dateTo: defaultDateTo, roomNumber: number})

    navigate({
      pathname: '/client/create-reservation',
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
            <input defaultValue={defaultNumPeople} className='w-[8em] bg-white p-[.5rem] rounded-lg text-black border-blue-600 border-solid border-[1.5px]' type='number' min={1} max={6} id='numPeople' name='numPeople' />
          </div>
            {
                filterError &&
                <p className='text-red-700 font-medium'>{filterError}</p>
            }
            <SubmitInputSecondary classes='mt-auto' name='submit' text='filtruj' />
          </form>
        </aside>
        <section className='w-2/3 grid grid-cols-3 gap-3'>
          {
            loading ?
              <p className='text-red-700 font-medium'>ładowanie...</p>
            : error ?
              <p className='text-red-700 font-medium'>{error}</p>
            : rooms && Array.isArray(rooms) && rooms.length > 0 ?
              rooms.map((r) => <RoomCard onClick={() => handleGoToReservation(r.number)} key={r.number} name={`${r.number}: ${r.type}`} price={r.price} numPerson={r.numberOfPeople} />) 
            :
              <p className='text-red-700 font-medium'>nie znaleziono pokojów spełniających warunki</p>
          }
        </section>
      </main>
  )
}

export default RoomSearch