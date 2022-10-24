import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticipantUpdateModalComponent } from './participant-update-modal.component';

describe('ParticipantUpdateModalComponent', () => {
  let component: ParticipantUpdateModalComponent;
  let fixture: ComponentFixture<ParticipantUpdateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParticipantUpdateModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParticipantUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
