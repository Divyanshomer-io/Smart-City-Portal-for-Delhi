import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { LocalNewsServiceService } from '../services/local-news-services.service';

@Component({
  selector: 'app-local-news',
  templateUrl: './local-news.component.html',
  styleUrls: ['./local-news.component.css']
})
export class LocalNewsComponent {
  localNewsForm= new FormGroup({
    title: new FormControl ('', [Validators.required]),
    content: new FormControl ('', [Validators.required]),
    authorId: new FormControl(null),
  })
  datas: any;
  newsDataList: any[] = []; // Change from single object to list
  result: any;
  isSubmitted = false;
  objectKeys = Object.keys;
  getForm = new FormGroup({
    id: new FormControl('', [Validators.required])
  });

  constructor(private localNewsSer : LocalNewsServiceService){
    this.localNewsSer.datas().subscribe((data)=>{
      this.datas = data;
    })
    this.refreshData();
  }

  get title() {
    return this.localNewsForm.get('title');
  }
  get content() {
    return this.localNewsForm.get('content');
  }
  get authorId() {
    return this.localNewsForm.get('authorId');
  }

  getValue(data: any) {
    this.localNewsSer.saveDatas(data).subscribe((result)=>{
      console.warn(result)
    })
    console.log(data);
    this.isSubmitted = true;
  }

  deleteService(id: string) {
    if (id) {
      this.localNewsSer.deleteData(id).subscribe((result) => {
        console.warn(result);
        this.refreshData();
      });
    }
  }

  retrieveService() {
    const id = this.getForm.get('id')?.value?.trim();
    if (id) {
      this.localNewsSer.getDataById(id).subscribe(data => {
        this.newsDataList.push(data); // Add new data to the list
        console.log('Retrieved Data:', data);
      });
    }
  }

  refreshData() {
    this.localNewsSer.datas().subscribe((data) => {
      this.datas = data;
    });
  }
}
