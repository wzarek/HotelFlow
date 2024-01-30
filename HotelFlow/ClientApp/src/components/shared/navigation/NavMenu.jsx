import React from 'react';
import { Link } from 'react-router-dom';
import NavItem from './NavItem'
import { useAuth } from '../../../services/auth/AuthProvider';

export const NavMenu = () => {
    const { auth } = useAuth()

    return (
      <header>
        <div className="bg-blue-100 font-sans w-full m-0 z-[100] fixed">
            <div className="container mx-auto px-4">
              <div className="flex items-center justify-between py-3">
                <Link to="/">HotelFlow</Link>
                <div className="hidden sm:flex sm:items-center">
                    <NavItem to="/" name='home' />
                    <NavItem to="/find-room" name='znajdź pokój' />
                    <div className='w-[1em] h-[1em] border-black border-l-[1px]'></div>
                    {
                      auth.isAuthenticated ?
                        <Link to="/logout" justLoggedOut={true} className="text-gray-800 text-sm font-semibold border-2 border-solid border-blue-900 px-4 py-2 rounded-lg hover:text-blue-600 hover:border-blue-600">wyloguj</Link>
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
