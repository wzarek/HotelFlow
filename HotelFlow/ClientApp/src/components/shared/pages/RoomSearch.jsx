import React from 'react'
import RoomSingle from '../../../imgs/tmp/RoomSingle.jpg'
import RoomDouble from '../../../imgs/tmp/RoomDouble.jpg'
import RoomTriple from '../../../imgs/tmp/RoomTriple.jpg'
import RoomQuadruple from '../../../imgs/tmp/RoomQuadruple.jpg'
import RoomCard from '../../shared/RoomCard'
import SearchInput from '../forms/SearchInput'
import SubmitInputSecondary from '../forms/SubmitInputSecondary'
import Heading from '../Heading'

const RoomSearch = () => {
  const dateFrom = new Date()
  const dateTo = new Date()
  dateTo.setDate(dateFrom.getDate() + 2)

  return (
      <main className='min-h-[80vh] w-[90vw] mx-auto flex flex-wrap justify-evenly items-start pt-[12vh]'>
        <Heading text='znajdź pokój' />
        <aside className='sticky top-[15vh] p-[2em] bg-gradient-to-b from-blue-100 to-blue-200 rounded-2xl w-1/5 h-[70vh] z-10 shadow flex flex-col gap-[3em]'>
          <h3 className='text-[1.5rem] font-medium mb-[2rem] text-center'>filtry</h3>
          <form action="" className='flex flex-col justify-start h-full'>
            <SearchInput name='dateFrom' label='dostępny od' type='date' />
            <SearchInput name='dateTo' label='dostępny do' type='date' />
            <SearchInput name='numPeople' label='ilość osób' type='number' />
            <SubmitInputSecondary classes='mt-auto' name='submit' text='filtruj' />
          </form>
        </aside>
        <section className='w-2/3 grid grid-cols-3 gap-3'>
          <RoomCard name='pokój dla singla' img={RoomSingle} price={100} numPerson={1} />
          <RoomCard name='pokój dla pary' img={RoomDouble} price={150} numPerson={2} />
          <RoomCard name='pokój dla trójki' img={RoomTriple} price={230} numPerson={3} />
          <RoomCard name='pokój dla czwórki' img={RoomQuadruple} price={330} numPerson={4} />
          <RoomCard name='pokój dla singla' img={RoomSingle} price={100} numPerson={1} />
          <RoomCard name='pokój dla pary' img={RoomDouble} price={150} numPerson={2} />
          <RoomCard name='pokój dla trójki' img={RoomTriple} price={230} numPerson={3} />
          <RoomCard name='pokój dla czwórki' img={RoomQuadruple} price={330} numPerson={4} />
        </section>
      </main>
  )
}

export default RoomSearch