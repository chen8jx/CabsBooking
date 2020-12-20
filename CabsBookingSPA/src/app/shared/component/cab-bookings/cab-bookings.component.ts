import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CabService } from 'src/app/core/services/cab.service';
import { BookingDetail } from '../../models/booking-detail';
import { CabBookings } from '../../models/cab-bookings';

@Component({
  selector: 'app-cab-bookings',
  templateUrl: './cab-bookings.component.html',
  styleUrls: ['./cab-bookings.component.css']
})
export class CabBookingsComponent implements OnInit {

  cabId:number | undefined;
  cabBookings:CabBookings | undefined;
  bookings:BookingDetail[] | undefined;
  constructor(private route: ActivatedRoute, private cabService: CabService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((c) => {
      this.cabId = +c.get('cabId');
      console.log(this.cabId);
      this.cabService.listBookings(this.cabId).subscribe((b) => {
        this.cabBookings = b;
        this.bookings=this.cabBookings.bookings;
      });
    });
  }

}
