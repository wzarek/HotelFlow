export class UserModelToSend {
    constructor(name, surname, number, roleid, username, email) {
        this.UserName = username
        this.Name = name
        this.Surname = surname
        this.PhoneNumber = number
        this.RoleId = roleid
        this.EmailAddress = email
        this.IsActive = true
    }
}