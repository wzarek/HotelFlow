import React, { createContext, useContext, useState } from 'react'
import { authConstants } from './authorizationServices'

const AuthContext = createContext()

export const AuthProvider = ({ children }) => {
    const [auth, setAuth] = useState({ isAuthenticated: false, token: null, role: authConstants.guest})

    console.log(auth)

    return (
        <AuthContext.Provider value={{auth, setAuth}}>
            {children}
        </AuthContext.Provider>
    )
}

export const useAuth = () => useContext(AuthContext)