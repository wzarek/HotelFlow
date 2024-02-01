import React, {useState, useEffect} from 'react'
import { URL_BASE, fetchGETJSONData, fetchPOSTJSONData} from '../../services/databaseServices'
import { ContactDetailsToGet } from '../../models/user/ContactDetails'
import { Roles } from '../../models/user/Roles'
import { UserModelToSend } from '../../models/user/UserModel'
  
const EmployeeManagment = () => {
    const [error, setError] = useState('')
    const [users, setUsers] = useState([])
    const [currentUserData, setCurrentUserData] = useState(null)
    const [visible, setFormVisible] = useState(false)
    const [formData, setFormData] = useState({
        UserName: '',
        Name: '',
        Surname: '',
        EmailAddress: '',
        PhoneNumber: '',
        RoleId: ''
      });
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

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({
          ...formData,
          [name]: value,
        });
      };

      const handleSubmit = async (e) => {
        e.preventDefault()
        let userModel = new UserModelToSend(formData.UserName, formData.Name, formData.Surname, formData.EmailAddress, formData.PhoneNumber, formData.RoleId)
        try{
            console.log(currentUserData)
            let userJSONdata = await fetchPOSTJSONData(`${URL_BASE}/users/edit/${currentUserData.Id}`, JSON.stringify(userModel))

            console.log(userJSONdata)
        } catch(err){
            console.error(err)
            setError(err.message)
        }
      };

  return (
    <>
    <button className='btn' onClick={fetchData}>Wyswietl pracownikow</button>
    <ul>
        {users.length === 0 && "Brak pracownikow do wyswietlnia"}
        {users.map(user =>{
            return <li key={user.UserName}>
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
            <button className = "flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer border-grey-200 'text-grey-600' hover:bg-blue-100" onClick ={() => setFormVisible(!visible)}>Edit</button>
        </div>
            {
             visible &&
             <div>
                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Imie</label>
                        <input className = "new-item-form" name = 'Name' onChange={handleInputChange} ></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>username</label>
                        <input className = "new-item-form" name = 'UserName' onChange={handleInputChange} ></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Nazwisko</label>
                        <input className = "new-item-form" name ='Surname' onChange={handleInputChange}></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Email</label>
                        <input className = "new-item-form" name = 'EmailAddress' onChange={handleInputChange} ></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Numer</label>
                        <input className = "new-item-form" name='PhoneNumber' onChange={handleInputChange} ></input>
                    </div>
                </form>


                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Rola</label>
                        <select name="RoleId" onChange={handleInputChange}>
                            <option value="3" key ='3'>Użytkownik</option>
                            <option value="2" key ='2'>Pracownik</option>
                            <option value="1" key ='1'>Admin</option>
                        </select> 
                    </div>
                </form>
                <button className = "flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer border-grey-200 'text-grey-600' hover:bg-blue-100" onClick ={handleSubmit}>Submit</button>
            </div>
            }
    </aside>
    </>
  )
}

export default EmployeeManagment

//Address: {currentUserData != null && currentUserData.AddressLine1.concat(' ', currentUserData.AddressLine2) }