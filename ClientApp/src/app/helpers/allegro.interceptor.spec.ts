import { TestBed } from '@angular/core/testing';

import { AllegroInterceptor } from './allegro.interceptor';

describe('AllegroInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      AllegroInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: AllegroInterceptor = TestBed.inject(AllegroInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
