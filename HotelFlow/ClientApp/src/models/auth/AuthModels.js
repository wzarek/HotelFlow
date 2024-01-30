export class AuthModelToGet {
    constructor({ token, role }) {
        this.token = token
        this.role = role
    }

    static fromJSON(json) {
        return new AuthModelToGet(json)
    }

    static fromSessionData(token, role){
        return new AuthModelToGet({token,role})
    }
}

export class AuthModelToSend {
    constructor(email, password) {
        this.Email = email
        this.Password = password
    }
}