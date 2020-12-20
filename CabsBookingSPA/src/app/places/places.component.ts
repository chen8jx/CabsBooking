import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../core/services/api.service';
import { PlaceService } from '../core/services/place.service';
import { Place } from '../shared/models/place';

@Component({
  selector: 'app-places',
  templateUrl: './places.component.html',
  styleUrls: ['./places.component.css']
})
export class PlacesComponent implements OnInit {

  places: Place[] | undefined;

  createRequest={
    placeId:0,
    placeName:''
  };
  placeId=new FormControl('0');
  placeName=new FormControl('');

  constructor(private placeService:PlaceService,
    private apiService:ApiService,
    private modalService: NgbModal) { }

    open(content) {
      this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
        this.createRequest.placeId=this.placeId.value;
        this.createRequest.placeName=this.placeName.value;
        if(this.createRequest.placeId==0){
          this.apiService.create('Places/place',this.createRequest).subscribe(
            p=>{
              window.location.reload()
            })
        }
        else{
          this.apiService.update('Places/place',this.createRequest).subscribe(
            p=>{
              window.location.reload()
            })
        }
      });
    }

    deletePlace(id:number){
      this.apiService.delete('Places',id).subscribe(
        p=>{
          window.location.reload();
        }
      )
    }

  ngOnInit(): void {
    this.placeService.getAllPlaces().subscribe(
      p=>{this.places=p;})
  }

}
