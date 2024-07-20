import { TestBed } from '@angular/core/testing';

import { MetroScheduleServicesService } from './metro-schedule-services.service';

describe('MetroScheduleServicesService', () => {
  let service: MetroScheduleServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MetroScheduleServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
