import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Cab } from 'src/app/shared/models/cab';
import { ApiService } from '../core/services/api.service';
import { CabService } from '../core/services/cab.service';
import { CabBookings } from '../shared/models/cab-bookings';

@Component({
  selector: 'app-cabs',
  templateUrl: './cabs.component.html',
  styleUrls: ['./cabs.component.css']
})
export class CabsComponent implements OnInit {

  cabs: Cab[] | undefined;
  cabBookings: CabBookings[] | undefined;
  
  createRequest={
    cabTypeId:0,
    cabTypeName:''
  };

  cabTypeId=new FormControl('0');
  cabTypeName=new FormControl('');

  constructor(private cabService:CabService,
    private apiService:ApiService,
    private modalService: NgbModal) { }

    open(content) {
      this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
        this.createRequest.cabTypeId=this.cabTypeId.value;
        this.createRequest.cabTypeName=this.cabTypeName.value;
        if(this.createRequest.cabTypeId==0){
          this.apiService.create('CabTypes/cab',this.createRequest).subscribe(
            c=>{
              window.location.reload()
            })
        }
        else{
          this.apiService.update('CabTypes/cab',this.createRequest).subscribe(
            c=>{
              window.location.reload()
            })
        }
      });
    }

  ngOnInit(): void {
    this.cabService.getAllCabs().subscribe(
      c=>{this.cabs=c;})
  }

  listCabBookings(cabId:number){
    this.cabService.listBookings(cabId).subscribe(
      c=>{
        this.cabBookings=c;
      }
    )
  }

  deleteCab(id:number){
    this.apiService.delete('CabTypes',id).subscribe(
      c=>{
        window.location.reload();
      }
    )
  }
}
