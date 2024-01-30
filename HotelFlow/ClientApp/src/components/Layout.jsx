import React from 'react'
import { NavMenu } from './shared/navigation/NavMenu'
import Footer from './shared/Footer'

export const Layout = ({ children }) => {
    return (
      <>
        <NavMenu />
        {children}
        <Footer />
      </>
    )
}
