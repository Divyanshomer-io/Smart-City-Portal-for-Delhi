import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalNewsComponent } from './local-news.component';

describe('LocalNewsComponent', () => {
  let component: LocalNewsComponent;
  let fixture: ComponentFixture<LocalNewsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LocalNewsComponent]
    });
    fixture = TestBed.createComponent(LocalNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
