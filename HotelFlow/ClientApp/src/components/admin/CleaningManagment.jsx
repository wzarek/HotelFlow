import React, {useState, useEffect} from 'react'
import { URL_BASE, fetchGETJSONData, fetchPOSTJSONData} from '../../services/databaseServices'
import { CleaningDetailsToGet, CleaningDetailsToSend } from '../../models/cleaning/CleaningDetails'
  
const CleaningManagment = () => {
    const [error, setError] = useState('')
    const [cleanings, setCleanings] = useState([])
    const [formData, setFormData] = useState({
        RoomId : '',
        EmployeeId : '',
        DateToBeCleaned : ''
      });
    const fetchData = async () => {
        try {
            let JSONdata = await fetchGETJSONData(`${URL_BASE}/cleaning/all`)
            let cleaningData = CleaningDetailsToGet.fromJSONList(JSON.stringify(JSONdata))

            setCleanings(cleaningData)
          } catch(err){
            console.error(err)
            setCleanings(err.message)
          }
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
        let cleaningModel = new CleaningDetailsToSend(formData.RoomId, formData.EmployeeId, formData.DateToBeCleaned)
        try{
            console.log(cleaningModel)
            let cleaningJSONdata = await fetchPOSTJSONData(`${URL_BASE}/cleaning/add`, JSON.stringify(cleaningModel))

            console.log(cleaningJSONdata)
        } catch(err){
            console.error(err)
            setError(err.message)
        }
      };

  return (
    <>
    <button className='btn' onClick={fetchData}>Wyswietl sprzatania</button>
    <ul>
        {cleanings.length === 0 && "Brak sprzatan do wyswietlnia"}
        {cleanings.map(cleaning =>{
            return <li key={cleaning.RoomId}>
                <button className = "flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer border-grey-200 'text-grey-600' hover:bg-blue-100" >sprzatanie: {cleaning.RoomId} kto: {cleaning.EmployeeId} kiedy: {cleaning.DateToBeCleaned}</button>
            </li>
        })}
    </ul>
    <aside className='sticky right-[15vh] p-[2rem] bg-gradient-to-b from-blue-100 to-blue-200 rounded-2xl z-10 shadow flex flex-col gap-[3em]'>
        <h3 className='text-[1.5rem] font-medium mb-[2rem] text-center'>Dodaj sprzatanie</h3>
             <div>
                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>RoomId</label>
                        <input className = "new-item-form" name = 'RoomId' onChange={handleInputChange} ></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>Pracownik id</label>
                        <input className = "new-item-form" name = 'EmployeeId' onChange={handleInputChange} ></input>
                    </div>
                </form>

                <form className = 'new-item-from'>
                    <div className ='form-row'>
                        <label>data sprzatania</label>
                        <input className = "new-item-form" name ='DateToBeCleaned' onChange={handleInputChange}></input>
                    </div>
                </form>

                <button className = "flex justify-between items-center border-2 rounded-xl p-[.75rem] cursor-pointer border-grey-200 'text-grey-600' hover:bg-blue-100" onClick ={handleSubmit}>Submit</button>
            </div>
    </aside>
    </>
  )
}

export default CleaningManagment

//Address: {currentUserData != null && currentUserData.AddressLine1.concat(' ', currentUserData.AddressLine2) }