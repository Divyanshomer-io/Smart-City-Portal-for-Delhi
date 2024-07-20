import { Injectable } from '@angular/core';
import{ HttpClient} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class EmergencyServicesServiceService {
  url="https://localhost:7112/api/CMSwebapi/emergencyservices";
  
  constructor(private http:HttpClient){}
   
  datas(){
    return this.http.get(this.url);
  }

  saveDatas( data: any){
    return this.http.post(this.url,data);
  }
  deleteData(id: string){
    return this.http.delete(`${this.url}/${id}`);
  }
  getServiceById(id: string) {
    return this.http.get(`${this.url}/${id}`);
  }
  
}
