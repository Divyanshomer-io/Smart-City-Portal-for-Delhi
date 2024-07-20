import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MetroScheduleServicesService } from '../services/metro-schedule-services.service';
@Component({
  selector: 'app-metro-schedules',
  templateUrl: './metro-schedules.component.html',
  styleUrls: ['./metro-schedules.component.css']
})
export class MetroSchedulesComponent {
  metroSchedulesForm = new FormGroup({
    startTime: new FormControl('', [Validators.required]),
    endTime: new FormControl('', [Validators.required]),
    frequency: new FormControl(null, [Validators.required]),
  });
  getForm = new FormGroup({
    id: new FormControl('', [Validators.required])
  });
  datas: any;
  schedules: any;
  scheduleData: any;
  
  objectKeys = Object.keys;
  constructor(private metroSchedulesService: MetroScheduleServicesService){
    this.metroSchedulesService. getSchedules().subscribe((data)=>{
      this.datas=data;
    })
    this.refreshData();
  }

  get startTime() {
    return this.metroSchedulesForm.get('startTime');
  }

  get endTime() {
    return this.metroSchedulesForm.get('endTime');
  }

  get frequency() {
    return this.metroSchedulesForm.get('frequency');
  }
  addSchedule(data: any) {
    this.metroSchedulesService.saveSchedule(data).subscribe(result => {
      console.warn(result);
      this.refreshData(); // Refresh the list after saving
    });
  }
  deleteSchedule(id: string) {
    if (id) {
      this.metroSchedulesService.deleteSchedule(id).subscribe(result => {
        console.warn(result);
        this.refreshData(); // Refresh the list after deletion
      });
    }
  }
  retrieveSchedule() {
    const id = this.getForm.get('id')?.value?.trim();
    if (id) {
      this.metroSchedulesService.getScheduleById(id).subscribe(data => {
        this.scheduleData = data;
        console.log('Retrieved Data:', data);
      });
    }
  }

  refreshData() {
    this.metroSchedulesService.getSchedules().subscribe(data => {
      this.schedules = data;
    });
  }



}
