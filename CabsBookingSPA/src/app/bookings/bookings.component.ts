import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../core/services/api.service';
import { BookingService } from '../core/services/booking.service';
import { Booking } from '../shared/models/booking';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {

  bookings: Booking[] | undefined;

  createRequest = {
    id: 0,
    email: '',
    bookingDate: '',
    bookingTime: '',
    pickupAddress: '',
    landmark: '',
    pickupDate: '',
    pickupTime: '',
    contactNo: '',
    status: '',
    fromPlace: '',
    toPlace: '',
    cabTypeId: ''
  };
  id = new FormControl('0');
  email = new FormControl(null);
  bookingDate = new FormControl(null);
  bookingTime = new FormControl(null);
  pickupAddress = new FormControl(null);
  landmark = new FormControl(null);
  pickupDate = new FormControl('');
  pickupTime = new FormControl(null);
  contactNo = new FormControl(null);
  status = new FormControl(null);
  fromPlace = new FormControl(null);
  toPlace = new FormControl(null);
  cabTypeId = new FormControl(null);

  constructor(private bookingService: BookingService,
    private apiService: ApiService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.bookingService.getAllBookings().subscribe(
      b => { this.bookings = b; })
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.createRequest.id=this.id.value;
      this.createRequest.email=this.email.value;
      this.createRequest.bookingDate=this.bookingDate.value.year+'-'+this.bookingDate.value.month+'-'+this.bookingDate.value.day;
      this.createRequest.bookingTime=this.bookingTime.value;
      this.createRequest.pickupAddress=this.pickupAddress.value;
      this.createRequest.landmark=this.landmark.value;
      this.createRequest.pickupDate=this.pickupDate.value.year+'-'+this.pickupDate.value.month+'-'+this.pickupDate.value.day;
      this.createRequest.pickupTime=this.pickupTime.value;
      this.createRequest.contactNo=this.contactNo.value;
      this.createRequest.status=this.status.value;
      this.createRequest.fromPlace=this.fromPlace.value;
      this.createRequest.toPlace=this.toPlace.value;
      this.createRequest.cabTypeId=this.cabTypeId.value;
      if(this.createRequest.id==0){
        this.apiService.create('Bookings/booking',this.createRequest).subscribe(
          b=>{
            window.location.reload();
        })
      }
      else{
        this.apiService.update('Bookings/booking',this.createRequest).subscribe(
          b=>{
            window.location.reload();
        })
      }
    });
  }

  deleteBooking(id:number){
    this.apiService.delete('Bookings',id).subscribe(
      c=>{
        window.location.reload();
      }
    )
  }
}
