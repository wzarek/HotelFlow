export class Roles {
    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let roles = []

        parsedJSON.forEach(element => {
            usersArray.push(
                element
            )
        });
        return roles
    }
}