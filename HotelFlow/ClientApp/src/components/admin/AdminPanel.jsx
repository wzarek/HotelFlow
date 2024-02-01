import React, { useEffect, useState } from 'react'
import Heading from '../shared/Heading'
import PanelMenuItem from '../shared/PanelMenuItem'
import FloorGrid from './FloorGrid'
import EmployeeManagment from './EmployeeManagment'
import CleaningManagment from './CleaningManagment'

const AdminPanel = () => {
    const [roomsManagementActive, setRoomsManagementActive] = useState(false)
    const [cleaningManagementActive, setCleaningManagementActive] = useState(false)
    const [reservationsManagementActive, setReservationsManagementActive] = useState(false)
    const [clientsManagementActive, setClientsManagementActive] = useState(false)
    const [employeesManagementActive, setEmployeesManagementActive] = useState(false)

    useEffect(() => {
        handleRoomsManagementClick()
    }, [])

    const handleRoomsManagementClick = () => {
        setRoomsManagementActive(true)
        setCleaningManagementActive(false)
        setReservationsManagementActive(false)
        setClientsManagementActive(false)
        setEmployeesManagementActive(false)
    }
    
    const handleCleaningManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(true)
        setReservationsManagementActive(false)
        setClientsManagementActive(false)
        setEmployeesManagementActive(false)
    }

    const handleReservationsManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(false)
        setReservationsManagementActive(true)
        setClientsManagementActive(false)
        setEmployeesManagementActive(false)
    }

    const handleClientsManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(false)
        setReservationsManagementActive(false)
        setClientsManagementActive(true)
        setEmployeesManagementActive(false)
    }

    const handleEmployeesManagementClick = () => {
        setRoomsManagementActive(false)
        setCleaningManagementActive(false)
        setReservationsManagementActive(false)
        setClientsManagementActive(false)
        setEmployeesManagementActive(true)
    }

  return (
    <main className='min-h-[80vh] w-[90vw] mx-auto flex flex-wrap justify-evenly items-start pt-[12vh]'>
            <Heading text='panel administratora' />
            <aside className='sticky top-[15vh] p-[2rem] bg-gradient-to-b from-blue-100 to-blue-200 rounded-2xl w-1/5 h-[70vh] z-10 shadow flex flex-col gap-[3em]'>
                <h3 className='text-[1.5rem] font-medium mb-[2rem] text-center'>menu</h3>
                <div className='flex flex-col gap-[1rem]'>
                    <PanelMenuItem onClick={handleRoomsManagementClick} text='zarządzanie pokojami' active={roomsManagementActive} />
                    <PanelMenuItem onClick={handleCleaningManagementClick} text='zarządzanie sprzątaniem' active={cleaningManagementActive} />
                    <PanelMenuItem onClick={handleReservationsManagementClick} text='zarządzanie rezerwacjami' active={reservationsManagementActive} />
                    <PanelMenuItem onClick={handleClientsManagementClick} text='zarządzanie klientami' active={clientsManagementActive} />
                    <PanelMenuItem onClick={handleEmployeesManagementClick} text='zarządzanie pracownikami' active={employeesManagementActive} />
                </div>
            </aside>
            <section className='w-2/3'>
                <div className='w-[90%] min-h-[70vh] mx-auto shadow p-[2rem] rounded-2xl'>
                    {
                        roomsManagementActive ? 
                            <FloorGrid/>
                        : cleaningManagementActive ?
                            <CleaningManagment/>
                        : reservationsManagementActive ?
                            <div> </div>
                        : clientsManagementActive ?
                            <div> </div>
                        : employeesManagementActive ?
                            <EmployeeManagment/>
                        : <div>Wybierz jedną z opcji</div>
                    }
                </div>
            </section>
        </main>
  )
}

export default AdminPanel