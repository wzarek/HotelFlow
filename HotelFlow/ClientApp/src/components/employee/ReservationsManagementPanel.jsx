import React, { useEffect, useState } from 'react'
import ReservationManagementListItem from './ReservationManagementListItem'
import { ReservationToGet, reservationStatuses } from '../../models/reservation/reservationHelpers'
import { URL_BASE, fetchGETJSONData } from '../../services/databaseServices'
import ReservationManagementDetails from './ReservationManagementDetails'

const ReservationsManagementPanel = () => {
    const [error, setError] = useState('')
    const [currentReservations, setCurrentReservations] = useState([])
    const [incomingReservations, setIncomingReservations] = useState([])
    const [oldReservations, setOldReservations] = useState([])
    const [zeroReservations, setZeroReservations] = useState(false)
    const [reservationDetailsShown, setReservationDetailsShown] = useState(false)
    const [clickedReservation, setClickedReservation] = useState()

    const fetchData = async () => {
        try {
            let JSONdata = await fetchGETJSONData(`${URL_BASE}/reservations/all`)
            let reservationsData = ReservationToGet.fromJSONList(JSON.stringify(JSONdata))
            
            sortReservations(reservationsData)
          } catch(err){
            console.error(err)
            setError(err.message)
          }
    }

    const sortReservations = (reservations) => {
        if (!Array.isArray(reservations) || reservations.length === 0) {
            setZeroReservations(true)
            return 
        }

        let currentRes = reservations.filter((r) => r.status === reservationStatuses.checkedIn || r.status === reservationStatuses.checkedOut)
        let incomingRes = reservations.filter((r) => r.status === reservationStatuses.confirmed || r.status === reservationStatuses.toConfirm)
        let oldRes = reservations.filter((r) => r.status === reservationStatuses.closed)

        setCurrentReservations(currentRes)
        setIncomingReservations(incomingRes)
        setOldReservations(oldRes)
    }

    const showReservationDetails = (reservation) => {
        setReservationDetailsShown(true)
        setClickedReservation(reservation)
    }

    const hideReservationDetails = () => {
        setReservationDetailsShown(false)
        setClickedReservation(null)

        fetchData()
    }

    useEffect(() => {
        fetchData()
    }, [])

    return (
        <>
            <h2 className='font-medium pb-[3rem] text-[1.5rem]'>rezerwacje</h2>
            {
                error ?
                    <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
                : zeroReservations ? 
                    <p>brak rezerwacji</p>
                : reservationDetailsShown ?
                    <ReservationManagementDetails goBack={() => hideReservationDetails()} reservation={clickedReservation} />
                : <>
                    {Array.isArray(currentReservations) && currentReservations.length > 0 && 
                        <>
                            <h3 className='font-medium text-[1.1rem] pb-[1rem]'>obecne</h3>
                            {
                                currentReservations.map(
                                    res => <ReservationManagementListItem key={res.number} onClick={() => showReservationDetails(res)} number={res.number} dateFrom={res.dateFrom} dateTo={res.dateTo} status={res.status} />
                                )
                            }
                        </>
                    }
                    {Array.isArray(incomingReservations) && incomingReservations.length > 0 && 
                        <>
                            <h3 className='font-medium text-[1.1rem] pb-[1rem]'>nadchodzące</h3>
                            {
                                incomingReservations.map(
                                    res => <ReservationManagementListItem key={res.number} onClick={() => showReservationDetails(res)} number={res.number} dateFrom={res.dateFrom} dateTo={res.dateTo} status={res.status} />
                                )    
                            }
                        </>
                    }
                    {Array.isArray(oldReservations) && oldReservations.length > 0 && 
                        <>
                            <h3 className='font-medium text-[1.1rem] pb-[0.5rem]'>stare</h3>
                            {
                                oldReservations.map(
                                    res => <ReservationManagementListItem key={res.number} onClick={() => showReservationDetails(res)} number={res.number} dateFrom={res.dateFrom} dateTo={res.dateTo} status={res.status} />
                                )
                            }
                        </>
                    }
                </>
            }
            
        </>
    )
}

export default ReservationsManagementPanel