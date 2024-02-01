export class RoomToGet {
    constructor(id, number, type, status, isActive, numberOfPeople) {
        this.id = id
        this.number = number
        this.type = type
        this.status = status
        this.isActive = isActive
        this.numberOfPeople = numberOfPeople
    }

    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let roomsArray = []

        parsedJSON.forEach(element => {
            roomsArray.push(
                new RoomToGet(element.id, element.number, element.type, element.status, element.isActive, element.numberOfPeople)
            )
        });
        return roomsArray
    }

    static fromJSON(json) {
        let parsedJSON = JSON.parse(json)

        return new RoomToGet(parsedJSON.id, parsedJSON.number, parsedJSON.type, parsedJSON.status, parsedJSON.isActive, parsedJSON.numberOfPeople)
    }
}