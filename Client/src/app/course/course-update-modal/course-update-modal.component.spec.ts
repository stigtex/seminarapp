import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseUpdateModalComponent } from './course-update-modal.component';

describe('CourseUpdateModalComponent', () => {
  let component: CourseUpdateModalComponent;
  let fixture: ComponentFixture<CourseUpdateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseUpdateModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
