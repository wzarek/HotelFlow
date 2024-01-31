import React from 'react'
import { NavMenu } from './shared/navigation/NavMenu'
import Footer from './shared/Footer'
import { useAuth } from '../services/auth/AuthProvider'

export const Layout = ({ children }) => {
  const {auth} = useAuth()

    return (
      auth &&
      <>
        <NavMenu />
        {children}
        <Footer />
      </>
    )
}
