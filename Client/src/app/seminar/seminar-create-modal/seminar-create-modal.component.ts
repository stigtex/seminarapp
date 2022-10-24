import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { SeminarService } from 'src/app/services/seminar.service';
import { SeminarCreateUpdateDto } from 'src/app/models/seminar-create-update-dto.model';
import { Seminar } from 'src/app/models/seminar.model';

@Component({
  selector: 'seminar-create-modal',
  templateUrl: './seminar-create-modal.component.html',
  styleUrls: ['./seminar-create-modal.component.css']
})
export class SeminarCreateModalComponent {
  form!: FormGroup;

  createSuccessful: boolean = false;
  createFailed: boolean = false;

  constructor(public formBuilder: FormBuilder, private httpClient: HttpClient, public activeModal: NgbActiveModal, private seminarService: SeminarService) {
    this.form = this.formBuilder.group({
      name: [],
      startDate: [],
      endDate: []
    });
  }

  submitForm() {
    var seminarToCreate = {} as SeminarCreateUpdateDto;

    seminarToCreate.seminarName = this.form.get('name')!.value;
    seminarToCreate.startDate = this.form.get('startDate')!.value;
    seminarToCreate.endDate = this.form.get('endDate')!.value;

    this.httpClient
      .post(API_ENDPOINTS.CREATE_SEMINAR, seminarToCreate, HTTP_OPTIONS)
      .subscribe({
        next: (createdSeminarFromServer) => {
          this.createSuccessful = true;
          this.seminarService.allSeminars.push(createdSeminarFromServer as Seminar);
        },
        error: (error: HttpErrorResponse) => {
          this.createFailed = true;
          console.log(`Failed to create seminar! Response from server: "HTTP statuscode: ${error.status}: ${error.message}"`);
        },
      });
  }
}

