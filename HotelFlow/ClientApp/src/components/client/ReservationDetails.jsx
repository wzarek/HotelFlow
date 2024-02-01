import React, { useEffect, useState } from 'react'
import { reservationStatuses, ReservationToGet } from '../../models/reservation/reservationHelpers'
import RoomCard from '../shared/RoomCard'
import { URL_BASE, fetchGETJSONData, fetchPOSTJSONData } from '../../services/databaseServices'
import { RoomToGet } from '../../models/room/roomHelpers'

const ReservationDetails = ({reservation, goBack}) => {
    const [error, setError] = useState('')
    const [loadingError, setLoadingError] = useState('')
    const [res, setRes] = useState(reservation)
    const [room, setRoom] = useState(null)
    const [loading, setLoading] = useState(false)
    const [review, setReview] = useState(null)
    const [reviewRating, setReviewRating] = useState(5)

    let statusTxtClass = ''
    let managable = false
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

        managable = res.status === reservationStatuses.toConfirm || res.status === reservationStatuses.confirmed
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

            let { 
                reviewText,
                reviewRatingNum,
                submitButton
            } = document.forms[0]
            reviewText.disabled = true
            reviewRatingNum.disabled = true
            submitButton.disabled = true

            let JSONdata = await fetchGETJSONData(`${URL_BASE}/reviews/getreviewforreservation/${reservation.id}`)

            setReview(JSONdata.comment)
            setReviewRating(JSONdata.rating ?? 5)
            reviewText.disabled = false
            reviewRatingNum.disabled = false
            submitButton.disabled = false
          } catch(err){
            console.error(err)
            setError(err.message)
          }
    }

    const handleCancel = async () => {
        try {
            let JSONdata = await fetchGETJSONData(`${URL_BASE}/reservations/cancel/${reservation.id}`)
            let reservationData = ReservationToGet.fromJSON(JSON.stringify(JSONdata))

            setRes(reservationData)
            setError('Rezerwacja została anulowana.')
          } catch(err){
            console.error(err)
            setError(err.message)
          }
    }

    const handleAddReview = async (e) => {
        e.preventDefault()

        try {
            setLoading(true)

            let { 
                reviewText,
                reviewRatingNum,
                submitButton
            } = document.forms[0]
            reviewText.disabled = true
            reviewRatingNum.disabled = true
            submitButton.disabled = true

            let reviewModel = {
                ReservationId: res.id,
                Rating: reviewRatingNum.value,
                Comment: reviewText.value
            }

            let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/reviews/add`, JSON.stringify(reviewModel))
            console.log('comm', JSONdata)

            fetchData()
            setLoading(false)
        } catch(err){
            console.error(err)
            setError(err.message)
            setLoading(false)
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
                        managable ?
                            <div>
                                <button onClick={handleCancel} className="text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">zrezygnuj</button>
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </div>
                        : readyForReview ?
                            <form onSubmit={handleAddReview}>
                                <div className="mb-2 w-[20vw]">
                                    <label htmlFor="reviewText" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">opinia</label>
                                    <input type="number" defaultValue={reviewRating} disabled={review} id="reviewRatingNum" min={1} max={5} className="bg-gray-50 resize-none border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200 mb-[.25em]" />
                                    <textarea disabled={review} defaultValue={review} required id="reviewText" className="bg-gray-50 resize-none border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200" placeholder="Podobało mi się..." />
                                </div>
                                {
                                    !review &&
                                    <button type="submit" id="submitButton" className="text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">dodaj opinię</button>
                                }
                                {
                                    error &&
                                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                                }
                            </form>
                        : <div></div>
                    }
                    <p>utworzono: {res.dateCreated}</p>
                </div>
            </div>
        }
    </div>
  )
}

export default ReservationDetails