export class RoomToGet {
    constructor(id, number, type, status, isActive, numberOfPeople, price) {
        this.id = id
        this.number = number
        this.type = type
        this.status = status
        this.isActive = isActive
        this.numberOfPeople = numberOfPeople
        this.price = price
    }

    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let roomsArray = []

        parsedJSON.forEach(element => {
            roomsArray.push(
                new RoomToGet(element.id, element.number, element.type, element.status, element.isActive, element.numberOfPeople, element.price)
            )
        });
        return roomsArray
    }

    static fromJSON(json) {
        let parsedJSON = JSON.parse(json)

        return new RoomToGet(parsedJSON.id, parsedJSON.number, parsedJSON.type, parsedJSON.status, parsedJSON.isActive, parsedJSON.numberOfPeople, parsedJSON.price)
    }
}