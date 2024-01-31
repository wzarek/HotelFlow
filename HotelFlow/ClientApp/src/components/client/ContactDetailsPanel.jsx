import React, { useEffect, useState } from 'react'
import { ContactDetailsToGet } from '../../models/user/ContactDetails'
import { URL_BASE, fetchGETJSONData } from '../../services/databaseServices'

const ContactDetailsPanel = () => {
    const [formError, setFormError] = useState('')
    const [error, setError] = useState('')
    const [contactDetails, setContactDetails] = useState(null)

    const fetchData = async () => {
        try{
            let contactJSONdata = await fetchGETJSONData(`${URL_BASE}/users/getcurrentuserinfo`)
            let contactData = ContactDetailsToGet.fromJSON(JSON.stringify(contactJSONdata))
            
            setContactDetails(contactData)
          }catch(err){
            console.error(err)
            setError(err.message)
          }
    }

    useEffect(() => {
        fetchData()
    }, [])


  return (
      <>
        <h2 className='font-medium pb-[3rem] text-[1.5rem]'>zmień informacje</h2>
        {
        error &&
            <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
        }
        {contactDetails &&
            <form className='w-[25vw] mx-auto'>
                <div className="mb-5">
                    <label htmlFor="username" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">nick</label>
                    <input type="username" value={contactDetails.UserName} readOnly disabled id="username" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200" placeholder="JohnKowalsky123" required/>
                </div>
                <div className='flex justify-between'>
                    <div className="mb-5">
                        <label htmlFor="email" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">email</label>
                        <input type="email" value={contactDetails.Email} readOnly disabled id="email" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200" placeholder="name@abc.com" required/>
                    </div>
                    <div className="mb-5">
                        <label htmlFor="phone" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">numer tel.</label>
                        <input type="phone" defaultValue={contactDetails.PhoneNumber} id="phone" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="123456789" required/>
                    </div>
                </div>
                <div className='flex justify-between'>    
                    <div className="mb-5">
                        <label htmlFor="name" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">imię</label>
                        <input type="name" defaultValue={contactDetails.Name} id="name" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="John" required/>
                    </div>
                    <div className="mb-5">
                        <label htmlFor="surname" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">nazwisko</label>
                        <input type="surname" defaultValue={contactDetails.Surname} id="surname" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Kowalsky" required/>
                    </div>
                </div>
                <div className='flex justify-between'>
                    <div className="mb-5">
                        <label htmlFor="password" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">hasło</label>
                        <input type="password" defaultValue='' id="password" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="password" required/>
                    </div>
                    <div className="mb-5">
                        <label htmlFor="passwordRepeat" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">powtórz hasło</label>
                        <input type="password" defaultValue='' id="passwordRepeat" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="password" required/>
                    </div>
                </div>
                <button type="submit" id="submitButton" className="text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center disabled:bg-gray-300">zapisz</button>
                {
                formError &&
                <p className='text-red-700 mt-[2rem] font-medium'>{formError}</p>
                }
            </form>
        }
    </>
  )
}

export default ContactDetailsPanel