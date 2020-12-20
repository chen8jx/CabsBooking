export interface History{
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
    comp_time:string,
    charge?:number,
    feedback:string,
    fromPlace:number,
    toPlace:number,
    cabTypeId:number;
}