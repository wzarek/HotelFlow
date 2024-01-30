import React from 'react'
import { Navigate } from 'react-router-dom'
import { useAuth } from './AuthProvider'
import { authConstants } from './authorizationServices'

const AdminProtectedRoute = ({ element }) => {
    const { auth } = useAuth()

    if (!auth.isAuthenticated || auth.role !== authConstants.admin) {
        return <Navigate to="/notfound" />
    }

    return element
};

export default AdminProtectedRoute