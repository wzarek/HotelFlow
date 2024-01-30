import React from 'react'
import AppRoutesComponent from './components/shared/AppRoutesComponent'
import { Layout } from './components/Layout'
import { AuthProvider, useAuth } from './services/auth/AuthProvider'
import './custom.css'

const App = () => {
    return (
      <Layout>
        <AuthProvider>
          <AppRoutesComponent />
        </AuthProvider>
      </Layout>
    )
}

export default App