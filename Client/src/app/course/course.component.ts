import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import ApiEndpoints from '../constants/ApiEndpoints';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CourseService } from '../services/course.service';
import { CourseCreateModalComponent } from './course-create-modal/course-create-modal.component';
import { CourseUpdateModalComponent } from './course-update-modal/course-update-modal.component';
import { CourseDeleteModalComponent } from './course-delete-modal/course-delete-modal.component';
import { Course } from '../models/course.model';

@Component({
  selector: 'course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  modalOptions: NgbModalOptions = {
    size: 'lg'
  }

  constructor(private httpClient: HttpClient, public courseService: CourseService, private modalService: NgbModal) {}

  ngOnInit(): void {
    this.httpClient.get<any>(ApiEndpoints.GET_ALL_COURSES)
      .subscribe(result => {
        this.courseService.allCourses = result.courses;
      });
  }

  onClickBtnCreateNewCourse() {
    this.modalService.open(CourseCreateModalComponent, this.modalOptions);
  }

  onClickBtnUpdateCourse(course: Course) {
    const modalRef = this.modalService.open(CourseUpdateModalComponent, this.modalOptions);
    modalRef.componentInstance.courseToUpdate = course;
  }

  onClickBtnDeleteCourse(course: Course) {
    const modalRef = this.modalService.open(CourseDeleteModalComponent, this.modalOptions);
    modalRef.componentInstance.courseToDelete = course;
  }
}