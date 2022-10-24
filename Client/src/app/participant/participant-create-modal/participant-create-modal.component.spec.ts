import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticipantCreateModalComponent } from './participant-create-modal.component';

describe('ParticipantCreateModalComponent', () => {
  let component: ParticipantCreateModalComponent;
  let fixture: ComponentFixture<ParticipantCreateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParticipantCreateModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParticipantCreateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
