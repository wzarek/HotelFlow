import React from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from '../../AppRoutes';
import { useAuth } from '../../services/auth/AuthProvider';
import AdminProtectedRoute from '../../services/auth/AdminProtectedRoute';
import EmployeeProtectedRoute from '../../services/auth/EmployeeProtectedRoute';
import ClientProtectedRoute from '../../services/auth/ClientProtectedRoute';
import { authConstants } from '../../services/auth/authorizationServices';

const AppRoutesComponent = () => {
    const { auth } = useAuth();

  return (
    <Routes>
        {AppRoutes.map((route, index) => {
            const { element, role, ...rest } = route

            let ElementComponent = element

            if (role == authConstants.admin) {
                ElementComponent = <AdminProtectedRoute element={element} />;
            } else if (role == authConstants.employee) {
                ElementComponent = <EmployeeProtectedRoute element={element} />;
            } else if (role == authConstants.client) {
                ElementComponent = <ClientProtectedRoute element={element} />;
            }

            return <Route key={index} {...rest} element={ElementComponent} />;
        })}
    </Routes>
  )
}

export default AppRoutesComponent