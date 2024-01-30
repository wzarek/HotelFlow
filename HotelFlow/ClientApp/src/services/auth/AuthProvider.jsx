import React, { createContext, useContext, useEffect, useState } from 'react'
import { authConstants, getAuthDataFromSessionStorage } from './authorizationServices'

const AuthContext = createContext()

export const AuthProvider = ({ children }) => {
    const [auth, setAuth] = useState({ isAuthenticated: false, token: null, role: authConstants.guest})

    useEffect(() =>{
        let authData = getAuthDataFromSessionStorage()
        console.log(authData)
        if (authData !== null) {
            setAuth({ isAuthenticated: authData.token !== null, token: authData.token, role: authData.role})
        }else{
            setAuth({ isAuthenticated: false, token: null, role: authConstants.guest})
        }
    }, [])

    return (
        <AuthContext.Provider value={{auth, setAuth}}>
            {children}
        </AuthContext.Provider>
    )
}

export const useAuth = () => useContext(AuthContext)

export const AUTH_DEFAULT = { isAuthenticated: false, token: null, role: authConstants.guest}