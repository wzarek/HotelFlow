import React, {useState, useEffect} from 'react'
import { URL_BASE, fetchGETJSONData } from '../../services/databaseServices'
import { ContactDetailsToGet } from '../../models/user/ContactDetails'

const EmployeeManagment = () => {
    const [error, setError] = useState('')
    const [users, setUsers] = useState([])
    const [currentUserData, setCurrentUserData] = useState(null)


    const fetchData = async () => {
        try {
            let JSONdata = await fetchGETJSONData(`${URL_BASE}/users/getbyrole/3`)
            let usersData = ContactDetailsToGet.fromJSONList(JSON.stringify(JSONdata.users))
            
            setUsers(usersData)
          } catch(err){
            console.error(err)
            setError(err.message)
          }
    }

    function setCurrent(user){
        setCurrentUserData(user)
    }

  return (
    <>
    <button className='btn' onClick={fetchData}>Wyswietl pracownikow</button>
    <ul>
        {users.length === 0 && "Brak pracownikow do wyswietlnia"}
        {users.map(user =>{
            return <li>
                <button classnName='btn' onClick ={() => setCurrent(user)}>{user.UserName}</button>
            </li>
        })}
    </ul>
    <div>
        Imie: {currentUserData != null && currentUserData.Name}
    </div>
    </>
  )
}

export default EmployeeManagment