import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { Seminar } from 'src/app/models/seminar.model';
import { SeminarService } from 'src/app/services/seminar.service';
import { SeminarCreateUpdateDto } from 'src/app/models/seminar-create-update-dto.model';


@Component({
  selector: 'seminar-update-modal',
  templateUrl: './seminar-update-modal.component.html',
  styleUrls: ['./seminar-update-modal.component.css']
})
export class SeminarUpdateModalComponent implements OnInit {
  form!: FormGroup;
  seminarToUpdate!: Seminar;

  updateSuccessful: boolean = false;
  updateFailed: boolean = false;

  constructor(public fb: FormBuilder, private httpClient: HttpClient, public activeModal: NgbActiveModal, private seminarService: SeminarService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [this.seminarToUpdate.id],
      name: [this.seminarToUpdate.seminarName],
      startDate: [this.seminarToUpdate.startDate],
      endDate: [this.seminarToUpdate.endDate]
    });

    this.form.controls['id'].disable();
  }

  submitForm() {
    var seminarToUpdateDTO = {} as SeminarCreateUpdateDto;

    seminarToUpdateDTO.seminarName = this.form.get('name')!.value;
    seminarToUpdateDTO.startDate = this.form.get('startDate')!.value;
    seminarToUpdateDTO.endDate = this.form.get('endDate')!.value;

    this.httpClient
      .put(`${API_ENDPOINTS.UPDATE_SEMINAR}/${this.seminarToUpdate.id}`, seminarToUpdateDTO, HTTP_OPTIONS)
      .subscribe({
        next: (response) => {
          this.updateSuccessful = true;

          let updatedSeminarFromServer: Seminar = response as Seminar;

          let updatedSeminarIndex = this.seminarService.allSeminars.findIndex((seminar => seminar.id == updatedSeminarFromServer.id));

          this.seminarService.allSeminars[updatedSeminarIndex].seminarName = updatedSeminarFromServer.seminarName;
          this.seminarService.allSeminars[updatedSeminarIndex].startDate = updatedSeminarFromServer.startDate;
          this.seminarService.allSeminars[updatedSeminarIndex].endDate = updatedSeminarFromServer.endDate;
        },
        error: (error: HttpErrorResponse) => {
          this.updateFailed = true;
          console.log(`Failed to update the seminar! Response from server: "HTTP statuscode: ${error.status}: ${error.message}"`);
        },
      });
  }
}
