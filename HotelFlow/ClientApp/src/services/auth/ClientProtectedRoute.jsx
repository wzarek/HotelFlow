import React from 'react'
import { Navigate } from 'react-router-dom'
import { useAuth } from './AuthProvider'
import { authConstants } from './authorizationServices'

const ClientProtectedRoute = ({ element }) => {
    const { auth } = useAuth()

    if (auth.role === authConstants.guest) {
        return <Navigate to="/login" />
    }

    return element
};

export default ClientProtectedRoute