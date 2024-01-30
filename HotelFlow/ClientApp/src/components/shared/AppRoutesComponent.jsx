import React from 'react'
import { Route, Routes } from 'react-router-dom'
import AppRoutes from '../../AppRoutes'
import AdminProtectedRoute from '../../services/auth/AdminProtectedRoute'
import EmployeeProtectedRoute from '../../services/auth/EmployeeProtectedRoute'
import ClientProtectedRoute from '../../services/auth/ClientProtectedRoute'
import { authConstants } from '../../services/auth/authorizationServices'

const AppRoutesComponent = () => {
  return (
    <Routes>
        {AppRoutes.map((route, index) => {
            const { element, role, ...rest } = route

            let elementComponent = element

            if (role === authConstants.admin) {
                elementComponent = <AdminProtectedRoute element={element} />;
            } else if (role === authConstants.employee) {
                elementComponent = <EmployeeProtectedRoute element={element} />;
            } else if (role === authConstants.client) {
                elementComponent = <ClientProtectedRoute element={element} />;
            }

            return <Route key={index} {...rest} element={elementComponent} />;
        })}
    </Routes>
  )
}

export default AppRoutesComponent