import { TestBed } from '@angular/core/testing';

import { LocalNewsServiceService } from './local-news-services.service';

describe('LocalNewsServicesService', () => {
  let service: LocalNewsServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LocalNewsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
