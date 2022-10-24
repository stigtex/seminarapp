import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeminarCreateModalComponent } from './seminar-create-modal.component';

describe('SeminarCreateModalComponent', () => {
  let component: SeminarCreateModalComponent;
  let fixture: ComponentFixture<SeminarCreateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeminarCreateModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeminarCreateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
