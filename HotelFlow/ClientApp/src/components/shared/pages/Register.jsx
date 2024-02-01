import React, {useEffect, useState} from 'react'
import {ReactComponent as LoginImg} from '../../../imgs/Login.svg'
import { useAuth } from '../../../services/auth/AuthProvider'
import { Navigate } from 'react-router-dom'
import { RegisterModelToSend } from '../../../models/auth/RegisterModels'
import { fetchPOSTJSONData, URL_BASE } from './../../../services/databaseServices'

const Register = () => {
  const { auth } = useAuth()
  const [error, setError] = useState('')
  const [redirect, setRedirect] = useState(false)

  useEffect(() => {
    if (auth && auth.isAuthenticated){
      setRedirect(true)
    }
  }, [auth])

  const handleSubmit = async (e) => {
    e.preventDefault()

    let { 
      username,
      email, 
      phone,
      name,
      surname,
      password,
      passwordRepeat,
      submitButton
    } = document.forms[0]

    if (password.value !== passwordRepeat.value){
      setError('Hasła muszą być takie same')
      return
    }

    submitButton.disabled = true

    let registerModel = new RegisterModelToSend(email.value, username.value, password.value, name.value, surname.value, phone.value)
    try{
      let registerJSONdata = await fetchPOSTJSONData(`${URL_BASE}/register`, JSON.stringify(registerModel))

      console.log(registerJSONdata)

      setError('User added. Redirecting to homepage.')

      document.forms[0].reset()

      setTimeout(() => {
        setRedirect(true)
      }, 2000)
    }catch(err){
      console.error(err)
      setError(err.message)
      submitButton.disabled = false
    }
  }

  return (
    !redirect ?
    <div className='h-[100vh] w-full flex flex-col justify-center gap-[5rem] items-center relative'>
      <div className='flex justify-between items-center gap-[2rem] relative z-10'>
        <div className='w-[30vw] h-[5px] bg-black rounded-lg'></div>
        <h1 className='font-semibold text-[2.5rem] whitespace-nowrap'>rejestracja</h1>
        <div className='w-full h-[5px] bg-black rounded-lg'></div>
      </div>
      <form className="w-[25em] mr-[15%]" onSubmit={handleSubmit}>
        <div className="mb-5">
            <label htmlFor="username" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">nick</label>
            <input type="username" id="username" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="JohnKowalsky123" required/>
        </div>
        <div className='flex justify-between'>
            <div className="mb-5">
                <label htmlFor="email" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">email</label>
                <input type="email" id="email" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="name@abc.com" required/>
            </div>
            <div className="mb-5">
                <label htmlFor="phone" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">numer tel.</label>
                <input type="phone" id="phone" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="123456789" required/>
            </div>
        </div>
        <div className='flex justify-between'>    
            <div className="mb-5">
                <label htmlFor="name" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">imię</label>
                <input type="name" id="name" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="John" required/>
            </div>
            <div className="mb-5">
                <label htmlFor="surname" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">nazwisko</label>
                <input type="surname" id="surname" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Kowalsky" required/>
            </div>
        </div>
        <div className='flex justify-between'>
            <div className="mb-5">
                <label htmlFor="password" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">hasło</label>
                <input type="password" id="password" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="password" required/>
            </div>
            <div className="mb-5">
                <label htmlFor="passwordRepeat" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">powtórz hasło</label>
                <input type="password" id="passwordRepeat" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="password" required/>
            </div>
        </div>
        <button type="submit" id="submitButton" className="text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">utwórz konto</button>
        {
          error &&
          <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
        }
      </form>
      <LoginImg className='absolute -z-10 h-[100%] opacity-[0.3] right-[5%] top-[5%]' />
    </div>
    :
    <Navigate to='/' />
  )
}

export default Register