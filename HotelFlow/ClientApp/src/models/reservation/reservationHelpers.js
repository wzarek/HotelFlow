export const reservationStatuses = { toConfirm: 'do zatwierdzenia', 
    confirmed: 'zatwierdzona', 
    checkedIn: 'zameldowano', 
    checkedOut: 'wymeldowano', 
    closed: 'zamknięta' 
}

export class ReservationToGet {
    constructor(id, reservationNumber, roomId, dateFrom, dateTo, status, dateCreated, price) {
        this.id = id
        this.number = reservationNumber
        this.roomId = roomId
        this.dateFrom = dateFrom
        this.dateTo = dateTo
        this.status = status
        this.dateCreated = dateCreated
        this.totalPrice = price
    }

    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let reservationsArray = []

        parsedJSON.forEach(element => {
            reservationsArray.push(
                new ReservationToGet(element.id, element.reservationNumber, element.roomId, element.dateFrom, element.dateTo, element.status, element.dateCreated, element.totalPrice)
            )
        });
        return reservationsArray
    }

    static fromJSON(json) {
        let parsedJSON = JSON.parse(json)

        return new ReservationToGet(parsedJSON.id, parsedJSON.reservationNumber, parsedJSON.roomId, parsedJSON.dateFrom, parsedJSON.dateTo, parsedJSON.status, parsedJSON.dateCreated, parsedJSON.totalPrice)
    }
}

export class ReservationToSend
{
    constructor(roomId, dateFrom, dateTo, statusId, employeeId, customerId) {
        this.RoomId = roomId
        this.DateFrom = dateFrom
        this.DateTo = dateTo
        this.StatusId = statusId
        this.EmployeeId = employeeId
        this.CustomerId = customerId
    }
}