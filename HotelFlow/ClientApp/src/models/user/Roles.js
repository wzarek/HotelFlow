export class ContactDetailsToGet {
    constructor(username, email, number, name, surname) {
        this.Email = email
        this.UserName = username
        this.Name = name
        this.Surname = surname
        this.PhoneNumber = number
    }

    static fromJSON(json) {
        var parsedJSON = JSON.parse(json)
        return new ContactDetailsToGet(parsedJSON.userName, parsedJSON.emailAddress, parsedJSON.phoneNumber, parsedJSON.name, parsedJSON.surname)
    }

    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let usersArray = []

        parsedJSON.forEach(element => {
            usersArray.push(
                new ContactDetailsToGet(element.userName, element.emailAddress, element.phoneNumber, element.name, element.surname)
            )
        });
        return usersArray
    }
}