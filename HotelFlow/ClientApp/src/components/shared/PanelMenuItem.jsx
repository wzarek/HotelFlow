import React from 'react'

const PanelMenuItem = ({text, onClick, active}) => {
  return (
    !active ?
        <p onClick={onClick} className='border-2 border-blue-900 p-[.5rem] rounded-lg cursor-pointer hover:text-blue-600 hover:border-blue-600'>{text}</p>
    :
        <p className='border-2 text-white border-blue-600 bg-blue-600 p-[.5rem] rounded-lg'>{text}</p> 
  )
}

export default PanelMenuItem