export class ContactDetailsToGet {
    constructor(username, email, number, name, surname, id) {
        this.Email = email
        this.UserName = username
        this.Name = name
        this.Surname = surname
        this.PhoneNumber = number
        this.Id = id
    }

    static fromJSON(json) {
        var parsedJSON = JSON.parse(json)
        return new ContactDetailsToGet(parsedJSON.userName, parsedJSON.emailAddress, parsedJSON.phoneNumber, parsedJSON.name, parsedJSON.surname, parsedJSON.id)
    }

    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let usersArray = []

        parsedJSON.forEach(element => {
            console.log(element)
            usersArray.push(
                new ContactDetailsToGet(element.userName, element.emailAddress, element.phoneNumber, element.name, element.surname, element.id)
            )
        });
        return usersArray
    }
}