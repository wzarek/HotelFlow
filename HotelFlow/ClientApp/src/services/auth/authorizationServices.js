export const getJWTTokenFromSessionStorage = () => {
    const token = sessionStorage.getItem('token');

    if (token === null) {
        console.warn("No token found in session storage.");
        return null;
    }

    return token;
}

export const setJWTTokenInSessionStorage = (token) => {
    if (!token) {
        console.error("Cannot set an empty token in session storage.");
        return;
    }

    sessionStorage.setItem('token', token);
}

export const authConstants = { guest: 'guest', client: 'client', employee: 'employee', admin: 'admin' }