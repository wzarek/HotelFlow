import React from 'react'
import SearchInput from './SearchInput'
import SubmitInput from './SubmitInput'

const SearchForm = () => {
  const dateFrom = new Date()
  const dateTo = new Date()
  dateTo.setDate(dateFrom.getDate() + 2)

  return (
    <form action="#" className='relative'>
        <SearchInput name='dateFrom' label='od' type='date' defaultValue={dateFrom.toLocaleDateString('en-CA')} />
        <SearchInput name='dateTo' label='do' type='date' defaultValue={dateTo.toLocaleDateString('en-CA')} />
        <SearchInput name='numPeople' label='ilość osób' type='number' defaultValue={1} />
        <SubmitInput name='submit' text='szukaj' />
    </form>
  )
}

export default SearchForm