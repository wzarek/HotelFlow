import { getAuthDataFromSessionStorage } from './auth/authorizationServices'

export const URL_BASE = 'https://localhost:44429/api'

export const fetchGETJSONData = async (url) => {
    try {
        const authData = getAuthDataFromSessionStorage()
        const token = authData?.token ?? 'no-token'

        const response = await fetch(url, {
            method: 'GET', 
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
        
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`)
        }
        
        return await response.json()
    } catch (error) {
        console.error('Error fetching data:', error)
        throw error
    }
}

export const fetchPOSTJSONData = async (url, jsonData) => {
    try {
        const authData = getAuthDataFromSessionStorage()
        const token = authData?.token ?? 'no-token'

        const response = await fetch(url, {
            method: 'POST', 
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: jsonData,
        })

        if (!response.ok) {
            let res = await response.json()
            throw new Error(`[${response.status}] ${res.message}`)
        }

        return await response.json()
    } catch (error) {
        console.error('Error sending data:', error)
        throw error
    }
}