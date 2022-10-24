import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SeminarComponent } from './seminar/seminar.component';
import { CourseComponent } from './course/course.component';
import { ParticipantComponent } from './participant/participant.component';
import { AppRoutingModule } from './app-routing.module';
import { SeminarCreateModalComponent } from './seminar/seminar-create-modal/seminar-create-modal.component';
import { SeminarUpdateModalComponent } from './seminar/seminar-update-modal/seminar-update-modal.component';
import { SeminarDeleteModalComponent } from './seminar/seminar-delete-modal/seminar-delete-modal.component';
import { ParticipantDeleteModalComponent } from './participant/participant-delete-modal/participant-delete-modal.component';
import { ParticipantCreateModalComponent } from './participant/participant-create-modal/participant-create-modal.component';
import { ParticipantUpdateModalComponent } from './participant/participant-update-modal/participant-update-modal.component';
import { CourseUpdateModalComponent } from './course/course-update-modal/course-update-modal.component';
import { CourseCreateModalComponent } from './course/course-create-modal/course-create-modal.component';
import { CourseDeleteModalComponent } from './course/course-delete-modal/course-delete-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    SeminarComponent,
    CourseComponent,
    ParticipantComponent,
    SeminarCreateModalComponent,
    SeminarUpdateModalComponent,
    SeminarDeleteModalComponent,
    ParticipantDeleteModalComponent,
    ParticipantCreateModalComponent,
    ParticipantUpdateModalComponent,
    CourseUpdateModalComponent,
    CourseCreateModalComponent,
    CourseDeleteModalComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
