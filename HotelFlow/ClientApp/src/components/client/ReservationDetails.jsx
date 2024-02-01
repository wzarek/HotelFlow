import React from 'react'
import { reservationStatuses } from '../../models/reservation/reservationHelpers'
import RoomCard from '../shared/RoomCard'

const ReservationDetails = ({reservation, goBack}) => {

    let statusTxtClass = ''
    let managable = false
    
    if (reservation){
        switch (reservation.status){
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

        managable = reservation.status === reservationStatuses.toConfirm || reservation.status === reservationStatuses.confirmed
    }

    let statusClasses = `font-medium ${statusTxtClass}`

    return (
    <div className='w-full min-h-[55vh] flex items-start gap-[2rem] relative'>
        <span onClick={goBack} className='cursor-pointer font-semibold border-2 border-solid border-blue-900 px-2 py-1 rounded-lg hover:text-blue-600 hover:border-blue-600'>&lt;</span>
        {
            reservation &&
            <div className='w-full flex flex-wrap justify-between items-center pt-2'>
                <h3 className='font-medium'>Rezerwacja nr {reservation.number}</h3>
                <p className={statusClasses}>{reservation.status}</p>
                <div className='w-full flex justify-between'>
                    <p>125 zł</p>
                    <p>{reservation.dateFrom} - {reservation.dateTo}</p>
                </div>
                <div className='mt-4 flex flex-col w-3/5'>
                    <p className='pb-2'>Zarezerwowany pokój:</p>
                    <RoomCard vertical={true} border={true} price={125} numPerson={2} name={'Dla pary'}/> 
                </div>
                <div className='flex w-full justify-between items-center absolute bottom-0 right-0'>
                    {       
                        managable ?
                            <button className="text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">zrezygnuj</button>
                        : <div></div>
                    }
                    <p>utworzono: {reservation.dateCreated}</p>
                </div>
            </div>
        }
    </div>
  )
}

export default ReservationDetails