import React, { useEffect, useState } from 'react'
import Heading from '../shared/Heading'
import ClientPanelMenuItem from './ClientPanelMenuItem'
import MyReservationsPanel from './MyReservationsPanel'
import ContactDetailsPanel from './ContactDetailsPanel'

const ClientPanel = () => {
    const [contactInfoActive, setContactInfoActive] = useState(false)
    const [myReservationsActive, setMyReservationsActive] = useState(false)

    useEffect(() => {
        setContactInfoActive(true)
    }, [])

    const handleContactInfoClick = () => {
        setContactInfoActive(true)
        setMyReservationsActive(false)
    }

    const handleMyReservationsClick = () => {
        setContactInfoActive(false)
        setMyReservationsActive(true)
    }

    return (
        <main className='min-h-[80vh] w-[90vw] mx-auto flex flex-wrap justify-evenly items-start pt-[12vh]'>
            <Heading text='panel klienta' />
            <aside className='sticky top-[15vh] p-[2rem] bg-gradient-to-b from-blue-100 to-blue-200 rounded-2xl w-1/5 h-[70vh] z-10 shadow flex flex-col gap-[3em]'>
                <h3 className='text-[1.5rem] font-medium mb-[2rem] text-center'>menu</h3>
                <div className='flex flex-col gap-[1rem]'>
                    <ClientPanelMenuItem onClick={handleContactInfoClick} text='informacje kontaktowe' active={contactInfoActive} />
                    <ClientPanelMenuItem onClick={handleMyReservationsClick} text='moje rezerwacje' active={myReservationsActive} />
                </div>
            </aside>
            <section className='w-2/3'>
                <div className='w-[90%] min-h-[70vh] mx-auto shadow p-[2rem] rounded-2xl'>
                    {
                        contactInfoActive ? 
                            <ContactDetailsPanel />
                        : myReservationsActive ?
                            <MyReservationsPanel />
                        : <div>Wybierz jedną z opcji</div>
                    }
                </div>
            </section>
        </main>
    )
}

export default ClientPanel