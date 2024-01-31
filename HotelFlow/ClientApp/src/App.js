import React from 'react'
import AppRoutesComponent from './components/shared/AppRoutesComponent'
import { Layout } from './components/Layout'
import { AuthProvider } from './services/auth/AuthProvider'
import './custom.css'

const App = () => {

    return (
      <AuthProvider>
        <Layout>
          <AppRoutesComponent />
        </Layout>
      </AuthProvider>
    )
}

export default App