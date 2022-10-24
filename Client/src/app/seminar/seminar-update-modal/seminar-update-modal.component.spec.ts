import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeminarUpdateModalComponent } from './seminar-update-modal.component';

describe('SeminarUpdateModalComponent', () => {
  let component: SeminarUpdateModalComponent;
  let fixture: ComponentFixture<SeminarUpdateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeminarUpdateModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeminarUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
