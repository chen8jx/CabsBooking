import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookingsComponent } from './bookings/bookings.component';
import { CabsComponent } from './cabs/cabs.component';
import { HistoryComponent } from './history/history.component';
import { PlacesComponent } from './places/places.component';
import { CabBookingsComponent } from './shared/component/cab-bookings/cab-bookings.component';

const routes: Routes = [
  {path:"",component:CabsComponent},
  {path:"CabTypes",component:CabsComponent},
  {path:"CabTypes/:cabId",component:CabBookingsComponent},
  {path:"Places",component:PlacesComponent},
  {path:"Bookings",component:BookingsComponent},
  {path:"BookingsHistory",component:HistoryComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
