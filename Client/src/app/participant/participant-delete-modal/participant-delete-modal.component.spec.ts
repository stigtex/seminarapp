import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticipantDeleteModalComponent } from './participant-delete-modal.component';

describe('ParticipantDeleteModalComponent', () => {
  let component: ParticipantDeleteModalComponent;
  let fixture: ComponentFixture<ParticipantDeleteModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParticipantDeleteModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParticipantDeleteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
