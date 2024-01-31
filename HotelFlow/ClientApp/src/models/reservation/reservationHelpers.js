export const reservationStatuses = { toConfirm: 'do zatwierdzenia', 
    confirmed: 'zatwierdzona', 
    checkedIn: 'zameldowano', 
    checkedOut: 'wymeldowano', 
    closed: 'zamknięta' 
}

export class ReservationToGet {
    constructor(id, reservationNumber, roomId, dateFrom, dateTo, status, dateCreated) {
        this.id = id
        this.number = reservationNumber
        this.roomId = roomId
        this.dateFrom = dateFrom
        this.dateTo = dateTo
        this.status = status
        this.dateCreated = dateCreated
    }

    static fromJSONList(json) {
        let parsedJSON = JSON.parse(json)
        let reservationsArray = []

        parsedJSON.forEach(element => {
            reservationsArray.push(
                new ReservationToGet(element.id, element.reservationNumber, element.roomId, element.dateFrom, element.dateTo, element.status, element.dateCreated)
            )
        });
        return reservationsArray
    }
}