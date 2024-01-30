import React, { useEffect, useState } from 'react'
import { Navigate } from 'react-router-dom'
import {ReactComponent as LogoutImg} from '../../../imgs/Bye.svg'
import { clearAuthDataInSessionStorage, getAuthDataFromSessionStorage } from '../../../services/auth/authorizationServices'
import { AUTH_DEFAULT, useAuth } from '../../../services/auth/AuthProvider'

const Logout = () => {
  const { auth, setAuth } = useAuth()
  const [redirect, setRedirect] = useState(false)

  useEffect(() => {
    if (auth && auth.isAuthenticated){
      clearAuthDataInSessionStorage()
      setAuth(AUTH_DEFAULT)
      setInterval(() => {
        setRedirect(true)
      }, 2000)
    } else{
      setRedirect(true)
    }
  }, [])

  return (
    !redirect ?
    <div className='h-[80vh] flex justify-center items-center'>
      <LogoutImg className='w-[50%]' />
    </div>
    :
    <Navigate to='/' />
  )
}

export default Logout