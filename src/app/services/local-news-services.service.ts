import { Injectable } from '@angular/core';
import{ HttpClient} from '@angular/common/http'
//import { LocalNewsApiResponse } from './local-news.component';
@Injectable({
  providedIn: 'root'
})
export class LocalNewsServiceService {

  url="https://localhost:7112/api/CMSwebapi/localnews";
 
 
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
  
  getDataById(id: string) {
    return this.http.get(`${this.url}/${id}`);
  }


}
