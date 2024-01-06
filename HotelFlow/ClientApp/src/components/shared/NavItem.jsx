import React from 'react'
import { Link } from 'react-router-dom'

const NavItem = ({to, name}) => {
  return (
    <Link to={to} className='text-gray-800 text-sm font-semibold hover:text-blue-600 mr-4'>{name}</Link>
  )
}

export default NavItem