export class CleaningDetailsToGet {
    constructor(roomId, employeeId, dateToBeCleaned) {
        this.RoomId = roomId
        this.EmployeeId = employeeId
        this.DateToBeCleaned = dateToBeCleaned
    }

    static fromJSON(json) {
        var parsedJSON = JSON.parse(json)
        return new CleaningDetailsToGet(parsedJSON.roomId, parsedJSON.employeeId, parsedJSON.dateToBeCleaned)
    }

    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let array = []

        parsedJSON.forEach(element => {
            console.log(element)
            array.push(
                new CleaningDetailsToGet(element.roomId, element.employeeId, element.dateToBeCleaned)
            )
        });
        return array
    }
}

export class CleaningDetailsToSend {
    constructor(roomId, employeeId, dateToBeCleaned) {
        this.RoomId = roomId
        this.EmployeeId = employeeId
        this.DateToBeCleaned = dateToBeCleaned
    }

    static fromJSON(json) {
        var parsedJSON = JSON.parse(json)
        return new CleaningDetailsToSend(parsedJSON.roomId, parsedJSON.employeeId, parsedJSON.dateToBeCleaned)
    }
}