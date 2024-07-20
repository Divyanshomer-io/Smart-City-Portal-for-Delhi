import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { EmergencyServicesServiceService } from '../services/emergency-services-service.service';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-emergency-services',
  templateUrl: './emergency-services.component.html',
  styleUrls: ['./emergency-services.component.css']
})
export class EmergencyServicesComponent {

  emergencyServiceForm = new FormGroup({
    serviceName: new FormControl('', [Validators.required]),
    contactNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]{10}$')]),
    isActive: new FormControl(false),
  });

  getForm = new FormGroup({
    id: new FormControl('')
  });

  datas: any;
  serviceDataList: any[] = []; // To store multiple service data
  successMessage: string = '';
  objectKeys = Object.keys;

  constructor(private emergencyService: EmergencyServicesServiceService, private cdr: ChangeDetectorRef) {
    this.refreshData();
  }

  get serviceName() {
    return this.emergencyServiceForm.get('serviceName');
  }

  get contactNumber() {
    return this.emergencyServiceForm.get('contactNumber');
  }

  get isActive() {
    return this.emergencyServiceForm.get('isActive');
  }

  getValue(data: any) {
    this.emergencyService.saveDatas(data).subscribe((result) => {
      console.warn(result);
      this.successMessage = 'Service data saved successfully!';
      this.refreshData();  // Refresh data to update the view
    });
    console.log(data);
  }

  deleteService(id: string) {
    if (id) {
      this.emergencyService.deleteData(id).subscribe((result) => {
        console.warn(result);
        this.refreshData();
      });
    }
  }

  retrieveService() {
    const id = this.getForm.get('id')?.value?.trim();
    console.log('Retrieved ID:', id);
    if (id) {
      this.emergencyService.getServiceById(id).subscribe(data => {
        this.serviceDataList.push(data); // Add new data without replacing existing data
        console.log('Retrieved Data:', this.serviceDataList);
        this.cdr.detectChanges(); // Manually trigger change detection
      });
    }
  }

  refreshData() {
    this.emergencyService.datas().subscribe((data) => {
      this.datas = data;
    });
  }
}
