import React, { useEffect, useState } from 'react'
import Heading from '../shared/Heading'
import RoomCard from '../shared/RoomCard'
import { useNavigate, useSearchParams } from 'react-router-dom'
import { fetchGETJSONData, fetchPOSTJSONData, URL_BASE } from '../../services/databaseServices'
import { RoomToGet } from '../../models/room/roomHelpers'
import { ReservationToSend, ReservationToGet } from '../../models/reservation/reservationHelpers'

const ReservationCreation = () => {
  const navigate = useNavigate()
  const [searchParams, setSearchParams] = useSearchParams()
  const [dateFrom, setDateFrom] = useState(null)
  const [dateTo, setDateTo] = useState(null)
  const [roomNumber, setRoomNumber] = useState(null)
  const [room, setRoom] = useState(null)
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState('')
  const [success, setSuccess] = useState('')

  useEffect(() => {
    if (!searchParams.get('dateFrom') || !searchParams.get('dateTo') || !searchParams.get('roomNumber')){
      navigate('/not-found')
    }

    setDateFrom(searchParams.get('dateFrom'))
    setDateTo(searchParams.get('dateTo'))
    setRoomNumber(searchParams.get('roomNumber'))

    fetchData(searchParams.get('roomNumber'))
  }, [])

  const fetchData = async (roomNumber) => {
    try{
        setLoading(true)

        let JSONdata = await fetchGETJSONData(`${URL_BASE}/rooms/getroombynumber/${roomNumber}`)
        let roomData = RoomToGet.fromJSON(JSON.stringify(JSONdata))

        setRoom(roomData)
        setLoading(false)
      }catch(err){
        console.error(err)
        setError(err.message)
        setLoading(false)
      }
  } 

  const handleSubmit = async () => {
    setLoading(true)
    let reservationToSend = new ReservationToSend(room.id, dateFrom, dateTo, 0, 1, 0)

    console.log(reservationToSend)

    let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/reservations/add`, JSON.stringify(reservationToSend))
    let reservationData = ReservationToGet.fromJSON(JSON.stringify(JSONdata))

    setLoading(false)
    setSuccess(`Utworzono rezerwację nr ${reservationData.number}`)
    setTimeout(() => {
      navigate('/')
    }, 2000)
  }

  return (
    <main className='min-h-[80vh] w-[90vw] mx-auto flex flex-wrap justify-evenly items-start pt-[12vh]'>
        <Heading text='utwórz rezerwację' />
        {
          loading ?
            <p className='text-red-700 font-medium'>ładowanie...</p>
          : error ?
            <p className='text-red-700 font-medium'>{error}</p>
          : success ?
            <p className='text-green-500 font-medium'>{success}</p>
          :
          <>
            <section className='w-1/3'>
              <h2 className='font-medium pb-2'>Szczegóły rezerwacji:</h2>
              <section className='w-full rounded-xl bg-white shadow p-4 h-[20vh] flex flex-col justify-evenly'>
                <p><span className='font-medium'>Cena:</span> 125zł</p>
                <p><span className='font-medium'>Zameldowanie:</span> {dateFrom}</p>
                <p><span className='font-medium'>Wymeldowanie:</span> {dateTo}</p>
              </section>
            </section>
            <section className='w-1/3 h-[20vh]'>
              {
                room &&
                <>
                  <h2 className='font-medium pb-2'>Rezerwowany pokój:</h2>
                  <RoomCard vertical={true} price={125} numPerson={room.numberOfPeople} name={room.type}/> 
                </>
              }
            </section>
            <div className='w-3/4 flex justify-end'>
              <button onClick={handleSubmit} id="submitButton" className="text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">rezerwuj</button>
            </div>
          </>
        }
    </main>
  )
}

export default ReservationCreation