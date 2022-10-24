import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { Course } from 'src/app/models/course.model';
import { CourseCreateUpdateDto } from 'src/app/models/course-create-update-dto.model';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'course-create-modal',
  templateUrl: './course-create-modal.component.html',
  styleUrls: ['./course-create-modal.component.css']
})
export class CourseCreateModalComponent {
  form!: FormGroup;

  createSuccessful: boolean = false;
  createFailed: boolean = false;

  constructor(public formBuilder: FormBuilder, private httpClient: HttpClient, public activeModal: NgbActiveModal, private courseService: CourseService) {
    this.form = this.formBuilder.group({
      courseName: [],
      instFirstName: [],
      instLastName: [],
      room: [],
      startDate: [],
      endDate: [],
    });
  }

  submitForm() {
    var courseToCreate = {} as CourseCreateUpdateDto;

    courseToCreate.courseName = this.form.get('courseName')!.value;
    courseToCreate.instructorFirstName = this.form.get('instFirstName')!.value;
    courseToCreate.instructorLastName = this.form.get('instLastName')!.value;
    courseToCreate.roomName = this.form.get('room')!.value;
    courseToCreate.startDate = this.form.get('startDate')!.value;
    courseToCreate.endDate = this.form.get('endDate')!.value;

    this.httpClient
      .post(API_ENDPOINTS.CREATE_COURSE, courseToCreate, HTTP_OPTIONS)
      .subscribe({
        next: (createdCourseFromServer) => {
          this.createSuccessful = true;
          this.courseService.allCourses.push(createdCourseFromServer as Course);
        },
        error: (error: HttpErrorResponse) => {
          this.createFailed = true;
          console.log(`Failed to create course! Response from server: "HTTP statuscode: ${error.status}: ${error.message}"`);
        },
      });
  }
}

