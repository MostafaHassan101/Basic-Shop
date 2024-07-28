import { TestBed } from '@angular/core/testing';

import { ApiClientService } from './api-client.service';

describe('CoreServiceService', () => {
  let service: ApiClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
