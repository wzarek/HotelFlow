import React, {useState, useEffect} from 'react'
import { URL_BASE, fetchGETJSONData } from '../../services/databaseServices'
import { ContactDetailsToGet } from '../../models/user/ContactDetails'

const EmployeeManagment = () => {
    const [error, setError] = useState('')
    const [users, setUsers] = useState([])
    const [currentUserData, setCurrentUserData] = useState(null)
    const [visible, setFormVisible] = useState(false)


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

    useEffect(() => {
        fetchData()
    }, [])

  return (
    <>
    <button className='btn' onClick={fetchData}>Wyswietl pracownikow</button>
    <ul>
        {users.length === 0 && "Brak pracownikow do wyswietlnia"}
        {users.map(user =>{
            return <li>
                <button className = "flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer border-grey-200 'text-grey-600' hover:bg-blue-100" onClick ={() => setCurrent(user)}>{user.UserName}</button>
            </li>
        })}
    </ul>
    <aside className='sticky right-[15vh] p-[2rem] bg-gradient-to-b from-blue-100 to-blue-200 rounded-2xl z-10 shadow flex flex-col gap-[3em]'>
        <h3 className='text-[1.5rem] font-medium mb-[2rem] text-center'>Dane pracownika</h3>
        <div>
            Imie: {currentUserData != null && currentUserData.Name}
            Nazwisko: {currentUserData != null && currentUserData.Surname}
            E-mail: {currentUserData != null && currentUserData.EmailAddress}
            <button className = "flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer border-grey-200 'text-grey-600' hover:bg-blue-100" onClick ={() => setFormVisible(true)}>Edit</button>
        </div>
            {
             visible &&
             <div>
                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Imie</label>
                        <input className = "new-item-form"></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Nazwisko</label>
                        <input className = "new-item-form"></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Email</label>
                        <input className = "new-item-form"></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Rola</label>
                        <input className = "new-item-form"></input>
                    </div>
                </form>
                <button className = "flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer border-grey-200 'text-grey-600' hover:bg-blue-100" onClick ={() => setFormVisible(true)}>Submit</button>
            </div>
            }
    </aside>
    </>
  )
}

export default EmployeeManagment

//Address: {currentUserData != null && currentUserData.AddressLine1.concat(' ', currentUserData.AddressLine2) }