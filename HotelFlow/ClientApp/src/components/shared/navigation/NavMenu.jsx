import React from 'react'
import { Link } from 'react-router-dom'
import NavItem from './NavItem'
import { useAuth } from '../../../services/auth/AuthProvider'
import { authConstants } from '../../../services/auth/authorizationServices'
import Logo from '../../../imgs/Logo.png'

export const NavMenu = () => {
    const { auth } = useAuth()

    return (
      <header>
        <div className="bg-blue-100 font-sans w-full m-0 z-[100] fixed">
            <div className="container mx-auto px-4">
              <div className="flex items-center justify-between py-3">
                <Link to="/" className='flex items-center font-bold gap-[.25em]'>
                  <img className='w-[2.5em]' src={Logo} alt="HotelFlow" />
                  HotelFlow
                </Link>
                <div className="hidden sm:flex sm:items-center">
                    <NavItem to="/find-room" name='znajdź pokój' />
                    {
                      auth.isAuthenticated && auth.role === authConstants.client &&
                      <NavItem to="/client/panel" name='panel klienta' />
                    }
                    {
                      auth.isAuthenticated && auth.role === authConstants.employee &&
                      <NavItem to="/employee/panel" name='panel pracownika' />
                    }
                    {
                      auth.isAuthenticated && auth.role === authConstants.admin &&
                      <NavItem to="/admin/panel" name='panel administratora' />
                    }
                    <div className='w-[1em] h-[1em] border-black border-l-[1px]'></div>
                    {
                      auth.isAuthenticated ?
                        <Link to="/logout" className="text-gray-800 text-sm font-semibold border-2 border-solid border-blue-900 px-4 py-2 rounded-lg hover:text-blue-600 hover:border-blue-600">wyloguj</Link>
                      :
                        <div className="hidden sm:flex sm:items-center">
                          <Link to="/login" className="text-gray-800 text-sm font-semibold hover:text-blue-600 mr-4">logowanie</Link>
                          <Link to="/register" className="text-gray-800 text-sm font-semibold border-2 border-solid border-blue-900 px-4 py-2 rounded-lg hover:text-blue-600 hover:border-blue-600">rejestracja</Link>
                        </div>
                    }
                </div>
            </div>
          </div>
        </div>
      </header>
    )
}
