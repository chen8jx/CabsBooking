import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HttpClientModule  } from '@angular/common/http';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams }  from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CabsComponent } from './cabs/cabs.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { PlacesComponent } from './places/places.component';
import { CabBookingsComponent } from './shared/component/cab-bookings/cab-bookings.component';
import { BookingsComponent } from './bookings/bookings.component';
import { HistoryComponent } from './history/history.component';

@NgModule({
  declarations: [
    AppComponent,
    CabsComponent,
    HeaderComponent,
    PlacesComponent,
    CabBookingsComponent,
    BookingsComponent,
    HistoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
