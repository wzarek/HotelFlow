import { getJWTTokenFromSessionStorage } from './authorizationServices'

export const fetchGETJSONData = async (url) => {
    try {
        const token = getJWTTokenFromSessionStorage() || 'no-token'

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
        const token = getJWTTokenFromSessionStorage() || 'no-token'

        const response = await fetch(url, {
            method: 'POST', 
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: jsonData,
        })

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`)
        }

        return await response.json()
    } catch (error) {
        console.error('Error sending data:', error)
        throw error
    }
}