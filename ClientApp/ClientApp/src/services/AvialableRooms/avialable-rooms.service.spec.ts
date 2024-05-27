import { TestBed } from '@angular/core/testing';

import { AvialableRoomsService } from './avialable-rooms.service';

describe('AvialableRoomsService', () => {
  let service: AvialableRoomsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AvialableRoomsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
