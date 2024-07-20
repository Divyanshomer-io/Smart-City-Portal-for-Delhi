import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor() { }

  getWeatherForDelhi(): Observable<any> {
    // Simulating API response (replace with actual API call)
    return of({
      temperature: 12,
      minTemperature: 8,
      maxTemperature: 13,
      weatherDescription: 'Rainy',
      timestamp: new Date('2024-07-20'),
    });
  }
}