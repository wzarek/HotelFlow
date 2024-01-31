import React from 'react'
import { reservationStatuses } from '../../models/reservation/reservationHelpers'

const ReservationListItem = ({dateFrom, dateTo, number, status, onClick}) => {
    let statusClass = ''
    let statusTxtClass = ''
    
    switch (status){
        case reservationStatuses.toConfirm:
            statusClass = 'border-amber-200'
            statusTxtClass = 'text-amber-800'
            break
        case reservationStatuses.confirmed:
            statusClass = 'border-emerald-600'
            statusTxtClass = 'text-emerald-800'
            break
        case reservationStatuses.checkedIn:
            statusClass = 'border-green-200'
            statusTxtClass = 'text-green-600'
            break
        case reservationStatuses.checkedOut:
            statusClass = 'border-grey-200'
            statusTxtClass = 'text-grey-600'
            break
        case reservationStatuses.closed:
            statusClass = 'border-grey-200'
            statusTxtClass = 'text-grey-600'
            break
        default:
            statusClass = 'border-grey-200'
            statusTxtClass = 'text-grey-600'
    }

    let classes = `flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer ${statusClass} hover:bg-blue-100`
    let statusTextClasases = `font-medium ${statusTxtClass}`

  return (
    <div onClick={onClick} className='flex flex-col mb-[2rem]'>
        <div className={classes} >
            <h4 className='font-medium'>Rezerwacja nr {number}</h4>
            <div className='flex flex-col items-end'>
                <span className={statusTextClasases} >{status}</span>
                <p>{dateFrom} - {dateTo}</p>
            </div>
        </div>
    </div>
  )
}

export default ReservationListItem