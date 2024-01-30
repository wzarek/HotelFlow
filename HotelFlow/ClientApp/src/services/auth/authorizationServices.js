import { AuthModelToGet } from "../../models/auth/AuthModels"

export const getAuthDataFromSessionStorage = () => {
    const data = sessionStorage.getItem('AuthData')

    if (data === null) {
        console.warn("No auth data found in session storage.")
        return null
    }

    let dataObj = JSON.parse(data)

    return AuthModelToGet.fromSessionData(dataObj.token, dataObj.role)
}

export const setAuthDataInSessionStorage = (authData) => {
    if (!authData) {
        console.error("Cannot set an empty auth data in session storage.")
        return
    }

    sessionStorage.setItem('AuthData', authData)
}

export const authConstants = { guest: 'guest', client: 'client', employee: 'employee', admin: 'admin' }