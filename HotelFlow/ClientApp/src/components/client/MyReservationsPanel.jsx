import React, { useState } from 'react'
import ReservationListItem from './ReservationListItem'
import { reservationStatuses } from '../../models/reservation/reservationHelpers'

const MyReservationsPanel = () => {
    const [currentReservations, setCurrentReservations] = useState(['1'])
    const [incomingReservations, setIncomingReservations] = useState(['2'])
    const [oldReservations, setOldReservations] = useState(['3'])
    const [zeroReservations, setZeroReservations] = useState(false)

  return (
    <>
        <h2 className='font-medium pb-[3rem] text-[1.5rem]'>rezerwacje</h2>
        {
            zeroReservations ? 
                <p>brak rezerwacji</p>
            :
            <>
                {Array.isArray(currentReservations) && currentReservations.length > 0 && 
                    <>
                        <h3 className='font-medium text-[1.1rem] pb-[1rem]'>obecne</h3>
                        <ReservationListItem number='123456' dateFrom='31-01-2024' dateTo='31-01-2024' status={reservationStatuses.checkedIn} />
                        <ReservationListItem number='123456' dateFrom='31-01-2024' dateTo='31-01-2024' status={reservationStatuses.checkedOut} />
                    </>
                }
                {Array.isArray(incomingReservations) && incomingReservations.length > 0 && 
                    <>
                        <h3 className='font-medium text-[1.1rem] pb-[1rem]'>nadchodzące</h3>
                        <ReservationListItem number='123456' dateFrom='31-01-2024' dateTo='31-01-2024' status={reservationStatuses.confirmed} />
                        <ReservationListItem number='123456' dateFrom='31-01-2024' dateTo='31-01-2024' status={reservationStatuses.toConfirm} />
                    </>
                }
                {Array.isArray(oldReservations) && oldReservations.length > 0 && 
                    <>
                        <h3 className='font-medium text-[1.1rem] pb-[0.5rem]'>stare</h3>
                        <ReservationListItem number='123456' dateFrom='31-01-2024' dateTo='31-01-2024' status={reservationStatuses.closed} />
                    </>
                }
            </>
        }
        
    </>
  )
}

export default MyReservationsPanel