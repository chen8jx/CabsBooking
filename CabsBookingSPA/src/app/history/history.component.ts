import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../core/services/api.service';
import { HistoryService } from '../core/services/history.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  histories:History[] | undefined;

  createRequest={
    id:0,
    email:'',
    bookingDate:'',
    bookingTime: '',
    pickupAddress: '', 
    landmark:'',
    pickupDate:'',
    pickupTime:'',
    contactNo:'',
    status:'',
    comp_time:'',
    charge:'',
    feedback:'',
    fromPlace:'',
    toPlace:'',
    cabTypeId:''
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
  comp_time = new FormControl(null);
  charge = new FormControl(null);
  feedback = new FormControl(null);
  fromPlace = new FormControl(null);
  toPlace = new FormControl(null);
  cabTypeId = new FormControl(null);

  constructor(private historyService: HistoryService,
    private apiService: ApiService,
    private modalService: NgbModal) { }

    ngOnInit(): void {
      this.historyService.getAllHistory().subscribe(
        h => { console.log(h);
          this.histories = h; })
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
        this.createRequest.comp_time=this.comp_time.value;
        this.createRequest.charge=this.charge.value;
        this.createRequest.feedback=this.feedback.value;
        this.createRequest.fromPlace=this.fromPlace.value;
        this.createRequest.toPlace=this.toPlace.value;
        this.createRequest.cabTypeId=this.cabTypeId.value;
        if(this.createRequest.id==0){
          this.apiService.create('BookingsHistory/history',this.createRequest).subscribe(
            b=>{
              window.location.reload();
          })
        }
        else{
          this.apiService.update('BookingsHistory/history',this.createRequest).subscribe(
            b=>{
              window.location.reload();
          })
        }
      });
    }

    deleteHistory(id:number){
      this.apiService.delete('BookingsHistory',id).subscribe(
        c=>{
          window.location.reload();
        }
      )
    }
}
