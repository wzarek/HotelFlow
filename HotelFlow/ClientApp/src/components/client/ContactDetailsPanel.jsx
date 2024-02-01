import React, { useEffect, useState } from 'react'
import { ContactDetailsToGet, ContactDetailsToSend } from '../../models/user/ContactDetails'
import { URL_BASE, fetchGETJSONData, fetchPOSTJSONData } from '../../services/databaseServices'

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

    const handleSubmit = async (e) => {
        e.preventDefault()
    
        let { 
          username,
          email, 
          phone,
          name,
          surname,
          submitButton
        } = document.forms[0]
        
        submitButton.disabled = true
    
        let registerModel = new ContactDetailsToSend(username.value, email.value, phone.value, name.value, surname.value, 0, true)
        try{
          let JSONdata = await fetchPOSTJSONData(`${URL_BASE}/users/editcurrentuser`, JSON.stringify(registerModel))

          setFormError('Dane zmienione.')
          document.forms[0].reset()
          fetchData()
          submitButton.disabled = false
          setTimeout(() => {
            setFormError('')
          }, 2000);
        }catch(err){
          console.error(err)
          setError(err.message)
          submitButton.disabled = false
        }
      }

  return (
      <>
        <h2 className='font-medium pb-[3rem] text-[1.5rem]'>zmień informacje</h2>
        {
        error &&
            <p className='text-red-700 mt-[2rem] font-medium'>{error}</p>
        }
        {contactDetails &&
            <form onSubmit={handleSubmit} className='w-[25vw] mx-auto'>
                <div className="mb-5">
                    <label htmlFor="username" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">nick</label>
                    <input type="text" value={contactDetails.UserName} readOnly disabled id="username" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200" placeholder="JohnKowalsky123" required/>
                </div>
                <div className='flex justify-between'>
                    <div className="mb-5">
                        <label htmlFor="email" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">email</label>
                        <input type="email" value={contactDetails.Email} readOnly disabled id="email" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 disabled:bg-gray-200" placeholder="name@abc.com" required/>
                    </div>
                    <div className="mb-5">
                        <label htmlFor="phone" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">numer tel.</label>
                        <input type="text" defaultValue={contactDetails.PhoneNumber} id="phone" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="123456789" required/>
                    </div>
                </div>
                <div className='flex justify-between'>    
                    <div className="mb-5">
                        <label htmlFor="name" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">imię</label>
                        <input type="text" defaultValue={contactDetails.Name} id="name" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="John" required/>
                    </div>
                    <div className="mb-5">
                        <label htmlFor="surname" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">nazwisko</label>
                        <input type="text" defaultValue={contactDetails.Surname} id="surname" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Kowalsky" required/>
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