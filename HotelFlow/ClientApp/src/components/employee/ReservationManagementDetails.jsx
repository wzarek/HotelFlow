import React, { useEffect, useState } from 'react'
import { reservationStatuses, ReservationToGet } from '../../models/reservation/reservationHelpers'
import RoomCard from '../shared/RoomCard'
import { URL_BASE, fetchGETJSONData, fetchPOSTJSONData } from '../../services/databaseServices'
import { RoomToGet } from '../../models/room/roomHelpers'

const ReservationManagementDetails = ({reservation, goBack}) => {
  const [error, setError] = useState('')
    const [loadingError, setLoadingError] = useState('')
    const [res, setRes] = useState(reservation)
    const [room, setRoom] = useState(null)
    const [loading, setLoading] = useState(false)
    const [review, setReview] = useState(null)
    const [reviewRating, setReviewRating] = useState(5)

    let statusTxtClass = ''
    let cancelable = false
    let confirmable = false
    let checkinable = false
    let checkoutable = false
    let closable = false
    let readyForReview = false
    
    if (res){
        switch (res.status){
            case reservationStatuses.toConfirm:
                statusTxtClass = 'text-amber-800'
                break
            case reservationStatuses.confirmed:
                statusTxtClass = 'text-emerald-800'
                break
            case reservationStatuses.checkedIn:
                statusTxtClass = 'text-green-600'
                break
            case reservationStatuses.checkedOut:
                statusTxtClass = 'text-grey-600'
                break
            case reservationStatuses.closed:
                statusTxtClass = 'text-grey-600'
                break
            default:
                statusTxtClass = 'text-grey-600'
        }

        cancelable = res.status === reservationStatuses.toConfirm || res.status === reservationStatuses.confirmed
        confirmable = res.status === reservationStatuses.toConfirm
        checkinable = res.status === reservationStatuses.confirmed
        checkoutable = res.status === reservationStatuses.checkedIn
        closable = res.status === reservationStatuses.checkedOut
        readyForReview = res.status === reservationStatuses.closed
    }

    let statusClasses = `font-medium ${statusTxtClass}`

    const fetchData = async () => {
        try {
            setLoading(true)
            let JSONdata = await fetchGETJSONData(`${URL_BASE}/rooms/${reservation.roomId}`)
            let roomData = RoomToGet.fromJSON(JSON.stringify(JSONdata))

            setRoom(roomData)
            setLoading(false)
          } catch(err){
            console.error(err)
            setLoadingError(err.message)
            setLoading(false)
          }

        try {
            if (!readyForReview) { return }

            let JSONdata = await fetchGETJSONData(`${URL_BASE}/reviews/getreviewforreservation/${reservation.id}`)

            setReview(JSONdata.comment)
            setReviewRating(JSONdata.rating ?? 5)

          } catch(err){
            console.error(err)
            setError(err.message)
          }
    }

    const handleCancel = async () => {
        try {
            // Id	Name
            // 1	To Confirm
            // 2	Confirmed
            // 3	Checked In
            // 4	Checked Out
            // 5	Closed

            let resToSend = {reservationId: reservation.id, statusId: 5}

            console.log(resToSend)
            let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/reservations/editstatus`, JSON.stringify(resToSend))
            let reservationData = ReservationToGet.fromJSON(JSON.stringify(JSONdata))

            setRes(reservationData)
            setError('Rezerwacja została anulowana.')
          } catch(err){
            console.error(err)
            setError(err.message)
          }
    }

    const handleConfirm = async () => {
      try {
          // Id	Name
          // 1	To Confirm
          // 2	Confirmed
          // 3	Checked In
          // 4	Checked Out
          // 5	Closed

          let resToSend = {reservationId: reservation.id, statusId: 2}

          console.log(resToSend)
          let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/reservations/editstatus`, JSON.stringify(resToSend))
          let reservationData = ReservationToGet.fromJSON(JSON.stringify(JSONdata))

          setRes(reservationData)
          setError('Rezerwacja została potwierdzona.')
        } catch(err){
          console.error(err)
          setError(err.message)
        }
  }

  const handleCheckin = async () => {
    try {
        // Id	Name
        // 1	To Confirm
        // 2	Confirmed
        // 3	Checked In
        // 4	Checked Out
        // 5	Closed

        let resToSend = {reservationId: reservation.id, statusId: 3}

        console.log(resToSend)
        let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/reservations/editstatus`, JSON.stringify(resToSend))
        let reservationData = ReservationToGet.fromJSON(JSON.stringify(JSONdata))

        setRes(reservationData)
        setError('Zameldowano.')
      } catch(err){
        console.error(err)
        setError(err.message)
      }
}

const handleCheckout = async () => {
  try {
      // Id	Name
      // 1	To Confirm
      // 2	Confirmed
      // 3	Checked In
      // 4	Checked Out
      // 5	Closed

      let resToSend = {reservationId: reservation.id, statusId: 4}

      console.log(resToSend)
      let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/reservations/editstatus`, JSON.stringify(resToSend))
      let reservationData = ReservationToGet.fromJSON(JSON.stringify(JSONdata))

      setRes(reservationData)
      setError('Wymeldowano.')
    } catch(err){
      console.error(err)
      setError(err.message)
    }
}

const handleClose = async () => {
  try {
      // Id	Name
      // 1	To Confirm
      // 2	Confirmed
      // 3	Checked In
      // 4	Checked Out
      // 5	Closed

      let resToSend = {reservationId: reservation.id, statusId: 5}

      console.log(resToSend)
      let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/reservations/editstatus`, JSON.stringify(resToSend))
      let reservationData = ReservationToGet.fromJSON(JSON.stringify(JSONdata))

      setRes(reservationData)
      setError('Zamknięto.')
    } catch(err){
      console.error(err)
      setError(err.message)
    }
}

    useEffect(() => {
        fetchData()
    }, [])

    return (
    <div className='w-full min-h-[55vh] flex items-start gap-[2rem] relative'>
        <span onClick={goBack} className='cursor-pointer font-semibold border-2 border-solid border-blue-900 px-2 py-1 rounded-lg hover:text-blue-600 hover:border-blue-600'>&lt;</span>
        {
            res &&
            <div className='w-full flex flex-wrap justify-between items-center pt-2'>
                <h3 className='font-medium'>Rezerwacja nr {res.number}</h3>
                <p className={statusClasses}>{res.status}</p>
                <div className='w-full flex justify-between'>
                    <p>{res.totalPrice} zł</p>
                    <p>{res.dateFrom} - {res.dateTo}</p>
                </div>
                <div className='mt-4 flex flex-col w-3/5'>
                    <p className='pb-2'>Zarezerwowany pokój:</p>
                    {
                        loading ?
                            <p className='text-red-700 mt-[2rem] font-medium'>ładowanie...</p>
                        : loadingError ?
                            <p className='text-red-700 mt-[2rem] font-medium'>{loadingError}</p>
                        : room ?
                            <RoomCard vertical={true} border={true} price={room.price} numPerson={room.numberOfPeople} name={room.type}/> 
                        : <p className='text-red-700 mt-[2rem] font-medium'>błąd ładowania</p>
                    }
                    
                </div>
                <div className='flex w-full justify-between items-center absolute bottom-0 right-0'>
                    {       
                        cancelable &&
                            <div>
                                <button onClick={handleCancel} className="text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">anuluj</button>
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </div>
                      }
                      {       
                        confirmable &&
                            <div>
                                <button onClick={handleConfirm} className="text-white bg-green-700 hover:bg-green-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">potwierdź</button>
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </div>
                      }
                      {       
                        checkinable &&
                            <div>
                                <button onClick={handleCheckin} className="text-white bg-green-700 hover:bg-green-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">check in</button>
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </div>
                      }
                      {       
                        checkoutable &&
                            <div>
                                <button onClick={handleCheckout} className="text-white bg-green-700 hover:bg-green-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">check out</button>
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </div>
                      }
                      {       
                        closable &&
                            <div>
                                <button onClick={handleClose} className="text-white bg-green-700 hover:bg-green-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">zamknij</button>
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </div>
                      }
                      {
                          review &&
                            <form>
                                  <div className="mb-2 w-[20vw]">
                                      <label htmlFor="reviewText" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">opinia</label>
                                      <input type="number" defaultValue={reviewRating} readOnly id="reviewRatingNum" min={1} max={5} className="bg-gray-50 resize-none border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200 mb-[.25em]" />
                                      <textarea readOnly defaultValue={review} required id="reviewText" className="bg-gray-50 resize-none border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200" placeholder="Podobało mi się..." />
                                  </div>
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </form>
                        }
                    <p>utworzono: {res.dateCreated}</p>
                </div>
            </div>
        }
    </div>
  )
}

export default ReservationManagementDetails