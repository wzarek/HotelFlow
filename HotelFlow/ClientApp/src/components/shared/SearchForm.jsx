import React from 'react'
import SearchInput from './SearchInput'
import SubmitInput from './SubmitInput'

const SearchForm = () => {
  const dateFrom = new Date()
  const dateTo = new Date()
  dateTo.setDate(dateFrom.getDate() + 2)

  return (
    <form action="#" className='relative'>
        <SearchInput name='dateFrom' label='from' type='date' defaultValue={dateFrom.toLocaleDateString('en-CA')} />
        <SearchInput name='dateTo' label='to' type='date' defaultValue={dateTo.toLocaleDateString('en-CA')} />
        <SearchInput name='numPeople' label='' type='number' defaultValue={1} />
        <SubmitInput name='submit' text='submit' />
    </form>
  )
}

export default SearchForm