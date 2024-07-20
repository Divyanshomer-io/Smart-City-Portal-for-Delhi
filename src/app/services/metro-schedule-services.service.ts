import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class MetroScheduleServicesService {
  apiUrl ="https://localhost:7112/api/CMSwebapi/metroschedules";
  constructor(private http:HttpClient ) {}

  getSchedules() {
    return this.http.get<any>(this.apiUrl);
  }

  saveSchedule(data: any){
    return this.http.post<any>(this.apiUrl, data);
  }

  deleteSchedule(id: string) {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }

  getScheduleById(id: string) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
}
