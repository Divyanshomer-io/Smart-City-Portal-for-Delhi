import { TestBed } from '@angular/core/testing';

import { EmergencyServicesServiceService } from './emergency-services-service.service';

describe('EmergencyServicesServiceService', () => {
  let service: EmergencyServicesServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmergencyServicesServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
