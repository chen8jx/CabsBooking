export interface Booking{
    id:number,
    email:string,
    bookingDate?:Date,
    bookingTime: string,
    pickupAddress: string, 
    landmark:string,
    pickupDate?:Date,
    pickupTime:string,
    contactNo:string,
    status:string,
    fromPlace:number,
    toPlace:number,
    cabTypeId:number;
}