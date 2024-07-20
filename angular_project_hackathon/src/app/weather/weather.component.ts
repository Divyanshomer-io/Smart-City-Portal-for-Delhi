import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../services/weather.service'; // Import your weather service

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  city: string = 'Delhi';
  timestamp: Date = new Date();
  weatherDescription: string = '';
  currentTemperature: number = 0;
  minTemperature: number = 0;
  maxTemperature: number = 0;
  weeklyForecast: { day: string, iconClass: string, minTemp: number, maxTemp: number }[] = [];

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.getWeatherData();
  }

  getWeatherData(): void {
    this.weatherService.getWeatherForDelhi().subscribe((data: any) => {
      this.weatherDescription = data.weatherDescription;
      this.currentTemperature = data.temperature;
      this.minTemperature = data.minTemperature;
      this.maxTemperature = data.maxTemperature;
      this.timestamp = data.timestamp;

      // Example of weekly forecast data, adjust as per your actual data structure
      this.weeklyForecast = [
        { day: 'Wed', iconClass: this.getWeatherIconClass('partly cloudy'), minTemp: 9, maxTemp: 18 },
        { day: 'Thu', iconClass: this.getWeatherIconClass('sunny'), minTemp: 12, maxTemp: 23 },
        { day: 'Fri', iconClass: this.getWeatherIconClass('partly cloudy'), minTemp: 14, maxTemp: 24 },
        { day: 'Sat', iconClass: this.getWeatherIconClass('rainy'), minTemp: 15, maxTemp: 23 },
        { day: 'Sun', iconClass: this.getWeatherIconClass('rainy'), minTemp: 15, maxTemp: 22 },
        { day: 'Mon', iconClass: this.getWeatherIconClass('cloudy'), minTemp: 12, maxTemp: 17 }
      ];
    });
  }

  getWeatherIconClass(weatherType: string): string {
    switch (weatherType.toLowerCase()) {
      case 'sunny':
        return 'fas fa-sun';
      case 'rainy':
        return 'fas fa-cloud-showers-heavy';
      case 'cloudy':
        return 'fas fa-cloud';
      case 'partly cloudy':
        return 'fas fa-cloud-sun';
      default:
        return '';
    }
  }
}
