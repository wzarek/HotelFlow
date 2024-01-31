import React, { useState } from 'react'
import {ReactComponent as LoginImg} from '../../../imgs/Login.svg'
import { useAuth } from '../../../services/auth/AuthProvider'
import { Navigate } from 'react-router-dom'
import { AuthModelToSend, AuthModelToGet } from '../../../models/auth/AuthModels'
import { fetchPOSTJSONData, URL_BASE } from './../../../services/databaseServices'
import { setAuthDataInSessionStorage } from '../../../services/auth/authorizationServices'

const Login = () => {
  const { auth, setAuth } = useAuth()
  const [error, setError] = useState('')

  const handleSubmit = async (e) => {
    e.preventDefault()

    let { email, password } = document.forms[0]

    let authModel = new AuthModelToSend(email.value, password.value)
    try{
      let authJSONdata = await fetchPOSTJSONData(`${URL_BASE}/login`, JSON.stringify(authModel))
      let authData = AuthModelToGet.fromJSON(authJSONdata)

      setAuth({ isAuthenticated: true, token: authData.token, role: authData.role})
      setAuthDataInSessionStorage(JSON.stringify(authData))
    }catch(err){
      console.error(err)
      setError(err.message)
    }
  }

  return (
    !auth.isAuthenticated ?
    <div className='h-[90vh] w-full flex flex-col justify-center gap-[5rem] items-center relative'>
      <div className='flex justify-between items-center gap-[2rem] relative z-10'>
        <div className='w-[30vw] h-[5px] bg-black rounded-lg'></div>
        <h1 className='font-semibold text-[2.5rem] whitespace-nowrap'>logowanie</h1>
        <div className='w-full h-[5px] bg-black rounded-lg'></div>
      </div>
      <form className="w-[25em] mr-[15%]" onSubmit={handleSubmit}>
        <div className="mb-5">
          <label htmlFor="email" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">email</label>
          <input type="email" id="email" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@abc.com" required/>
        </div>
        <div className="mb-5">
          <label htmlFor="password" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">hasło</label>
          <input type="password" id="password" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="password" required/>
        </div>
        <button type="submit" className="text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center">zaloguj</button>
        {
          error &&
          <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
        }
      </form>
      <LoginImg className='absolute -z-10 h-[100%] opacity-[0.3] right-[10%] top-[10%]' />
    </div>
    :
    <Navigate to='/' />
  )
}

export default Login