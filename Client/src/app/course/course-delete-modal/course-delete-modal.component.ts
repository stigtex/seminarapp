import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { CourseService } from 'src/app/services/course.service';
import { Course } from 'src/app/models/course.model';


@Component({
  selector: 'course-delete-modal',
  templateUrl: './course-delete-modal.component.html',
  styleUrls: ['./course-delete-modal.component.css']
})
export class CourseDeleteModalComponent {
  courseToDelete!: Course;

  deleteSuccessful: boolean = false;
  deleteFailed: boolean = false;

  constructor(private httpClient: HttpClient, public activeModal: NgbActiveModal, private courseService: CourseService) { }

  onClickBtnDelete() {
    this.httpClient
      .put(`${API_ENDPOINTS.DELETE_COURSE}/${this.courseToDelete.id}`, HTTP_OPTIONS)
      .subscribe({
        next: () => {
          this.deleteSuccessful = true;

          const index = this.courseService.allCourses.indexOf(this.courseToDelete);
          if (index > -1) {
            this.courseService.allCourses.splice(index, 1);
          }
        },
        error: (error: HttpErrorResponse) => {
          this.deleteFailed = true;
          console.log('Failed to delete the course! Error from server:');
          console.log(error.message);
        },
      });
  }
}

