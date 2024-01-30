import React from 'react'
import { Navigate } from 'react-router-dom'
import { useAuth } from './AuthProvider'
import { authConstants } from './authorizationServices'

const EmployeeProtectedRoute = ({ element }) => {
    const { auth } = useAuth()

    if (auth.role !== authConstants.admin || auth.role !== authConstants.employee) {
        return <Navigate to="/not-found" />
    }

    return element
};

export default EmployeeProtectedRoute