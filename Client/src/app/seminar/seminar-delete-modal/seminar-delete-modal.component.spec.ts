import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeminarDeleteModalComponent } from './seminar-delete-modal.component';

describe('SeminarDeleteModalComponent', () => {
  let component: SeminarDeleteModalComponent;
  let fixture: ComponentFixture<SeminarDeleteModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeminarDeleteModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeminarDeleteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
