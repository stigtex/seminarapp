import { NgModule } from '@angular/core';
import { SeminarComponent } from './seminar/seminar.component';
import { RouterModule, Routes } from '@angular/router';
import { CourseComponent } from './course/course.component';
import { ParticipantComponent } from './participant/participant.component';

const routes: Routes = [
  {path: '', redirectTo: '/seminars', pathMatch: 'full'},
  {path: 'seminars', component: SeminarComponent},
  {path: 'courses', component: CourseComponent},
  {path: 'participants', component: ParticipantComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
