import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//import { EmergencyServicesComponent } from './emergency-services/emergency-services.component';
import { ReactiveFormsModule } from '@angular/forms';
//import { LocalNewsComponent } from './local-news/local-news.component';
import { HttpClientModule } from '@angular/common/http';
import { MetroSchedulesComponent } from './metro-schedules/metro-schedules.component';
import { HeaderComponent } from './header/header.component';
import { LocalNewsComponent } from './local-news/local-news.component';
import { EmergencyServicesComponent } from './emergency-services/emergency-services.component';
import { WeatherComponent } from './weather/weather.component';

@NgModule({
  declarations: [
    AppComponent,
   // EmergencyServicesComponent,
    //LocalNewsComponent,
    MetroSchedulesComponent,
    HeaderComponent,
    LocalNewsComponent,
    EmergencyServicesComponent,
    WeatherComponent
  ],
  imports: [
    BrowserModule,
   // AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
