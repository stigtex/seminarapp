import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { CourseCreateUpdateDto } from 'src/app/models/course-create-update-dto.model';
import { Course } from 'src/app/models/course.model';
import { CourseService } from 'src/app/services/course.service';


@Component({
  selector: 'course-update-modal',
  templateUrl: './course-update-modal.component.html',
  styleUrls: ['./course-update-modal.component.css']
})
export class CourseUpdateModalComponent implements OnInit {
  form!: FormGroup;
  courseToUpdate!: Course;

  updateSuccessful: boolean = false;
  updateFailed: boolean = false;

  constructor(public fb: FormBuilder, private httpClient: HttpClient, public activeModal: NgbActiveModal, private courseService: CourseService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [this.courseToUpdate.id],
      courseName: [this.courseToUpdate.courseName],
      instFirstName: [this.courseToUpdate.instructorFirstName],
      instLastName: [this.courseToUpdate.instructorLastName],
      room: [this.courseToUpdate.roomName],
      startDate: [this.courseToUpdate.startDate],
      endDate: [this.courseToUpdate.endDate],
    });

    this.form.controls['id'].disable();
  }

  submitForm() {
    var courseToUpdateDTO = {} as CourseCreateUpdateDto;

    courseToUpdateDTO.courseName = this.form.get('courseName')!.value;
    courseToUpdateDTO.instructorFirstName = this.form.get('instFirstName')!.value;
    courseToUpdateDTO.instructorLastName = this.form.get('instLastName')!.value;
    courseToUpdateDTO.roomName = this.form.get('room')!.value;
    courseToUpdateDTO.startDate = this.form.get('startDate')!.value;
    courseToUpdateDTO.endDate = this.form.get('endDate')!.value;

    this.httpClient
      .put(`${API_ENDPOINTS.UPDATE_COURSE}/${this.courseToUpdate.id}`, courseToUpdateDTO, HTTP_OPTIONS)
      .subscribe({
        next: (response) => {
          this.updateSuccessful = true;

          let updatedCourseFromServer: Course = response as Course;

          let updatedCourseIndex = this.courseService.allCourses.findIndex((course => course.id == updatedCourseFromServer.id));

          this.courseService.allCourses[updatedCourseIndex].courseName = updatedCourseFromServer.courseName;
          this.courseService.allCourses[updatedCourseIndex].instructorFirstName = updatedCourseFromServer.instructorFirstName;
          this.courseService.allCourses[updatedCourseIndex].instructorLastName = updatedCourseFromServer.instructorLastName;
          this.courseService.allCourses[updatedCourseIndex].roomName = updatedCourseFromServer.roomName;
          this.courseService.allCourses[updatedCourseIndex].startDate = updatedCourseFromServer.startDate;
          this.courseService.allCourses[updatedCourseIndex].endDate = updatedCourseFromServer.endDate;
        },
        error: (error: HttpErrorResponse) => {
          this.updateFailed = true;
          console.log(`Failed to update the course! Response from server: "HTTP statuscode: ${error.status}: ${error.message}"`);
        },
      });
  }
}
