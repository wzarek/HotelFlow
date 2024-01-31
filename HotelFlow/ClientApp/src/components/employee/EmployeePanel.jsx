import React, { useEffect, useState } from 'react'
import Heading from '../shared/Heading'
import PanelMenuItem from '../shared/PanelMenuItem'

const EmployeePanel = () => {
    const [roomsManagementActive, setRoomsManagementActive] = useState(false)
    const [cleaningManagementActive, setCleaningManagementActive] = useState(false)
    const [reservationsManagementActive, setReservationsManagementActive] = useState(false)
    const [clientsManagementActive, setClientsManagementActive] = useState(false)
    const [myAccountManagementActive, setMyAccountManagementActive] = useState(false)

    useEffect(() => {
        handleRoomsManagementClick()
    }, [])

    const handleRoomsManagementClick = () => {
        setRoomsManagementActive(true)
        setCleaningManagementActive(false)
        setReservationsManagementActive(false)
        setClientsManagementActive(false)
        setMyAccountManagementActive(false)
    }

    const handleCleaningManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(true)
        setReservationsManagementActive(false)
        setClientsManagementActive(false)
        setMyAccountManagementActive(false)
    }

    const handleReservationsManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(false)
        setReservationsManagementActive(true)
        setClientsManagementActive(false)
        setMyAccountManagementActive(false)
    }

    const handleClientsManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(false)
        setReservationsManagementActive(false)
        setClientsManagementActive(true)
        setMyAccountManagementActive(false)
    }

    const handleMyAccountManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(false)
        setReservationsManagementActive(false)
        setClientsManagementActive(false)
        setMyAccountManagementActive(true)
    }

  return (
    <main className='min-h-[80vh] w-[90vw] mx-auto flex flex-wrap justify-evenly items-start pt-[12vh]'>
            <Heading text='panel pracownika' />
            <aside className='sticky top-[15vh] p-[2rem] bg-gradient-to-b from-blue-100 to-blue-200 rounded-2xl w-1/5 h-[70vh] z-10 shadow flex flex-col gap-[3em]'>
                <h3 className='text-[1.5rem] font-medium mb-[2rem] text-center'>menu</h3>
                <div className='flex flex-col gap-[1rem]'>
                    <PanelMenuItem onClick={handleRoomsManagementClick} text='zarządzanie pokojami' active={roomsManagementActive} />
                    <PanelMenuItem onClick={handleCleaningManagementClick} text='zarządzanie sprzątaniem' active={cleaningManagementActive} />
                    <PanelMenuItem onClick={handleReservationsManagementClick} text='zarządzanie rezerwacjami' active={reservationsManagementActive} />
                    <PanelMenuItem onClick={handleClientsManagementClick} text='zarządzanie klientami' active={clientsManagementActive} />
                    <PanelMenuItem onClick={handleMyAccountManagementClick} text='zarządzanie swoim kontem' active={myAccountManagementActive} />
                </div>
            </aside>
            <section className='w-2/3'>
                <div className='w-[90%] min-h-[70vh] mx-auto shadow p-[2rem] rounded-2xl'>
                    {
                        roomsManagementActive ? 
                            <div> </div>
                        : cleaningManagementActive ?
                            <div> </div>
                        : reservationsManagementActive ?
                            <div> </div>
                        : clientsManagementActive ?
                            <div> </div>
                        : myAccountManagementActive ?
                            <div> </div>
                        : <div>Wybierz jedną z opcji</div>
                    }
                </div>
            </section>
        </main>
  )
}

export default EmployeePanel