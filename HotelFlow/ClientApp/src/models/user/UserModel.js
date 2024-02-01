export class UserModelToSend {
    constructor(name, surname, number, roleid) {
        this.Name = name
        this.Surname = surname
        this.PhoneNumber = number
        this.RoleId = roleid
        this.IsActive = true
    }
}