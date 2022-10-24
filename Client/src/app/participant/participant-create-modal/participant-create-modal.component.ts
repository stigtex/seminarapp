import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { Participant } from 'src/app/models/participant.model';
import { ParticipantService } from 'src/app/services/participant.service';
import { ParticipantCreateUpdateDto } from 'src/app/models/participant-create-update-dto.model';

@Component({
  selector: 'participant-create-modal',
  templateUrl: './participant-create-modal.component.html',
  styleUrls: ['./participant-create-modal.component.css']
})
export class ParticipantCreateModalComponent {
  form!: FormGroup;

  createSuccessful: boolean = false;
  createFailed: boolean = false;

  constructor(public formBuilder: FormBuilder, private httpClient: HttpClient, public activeModal: NgbActiveModal, private participantService: ParticipantService) {
    this.form = this.formBuilder.group({
      firstName: [],
      lastName: [],
      email: []
    });
  }

  submitForm() {
    var participantToCreate = {} as ParticipantCreateUpdateDto;

    participantToCreate.firstName = this.form.get('firstName')!.value;
    participantToCreate.lastName = this.form.get('lastName')!.value;
    participantToCreate.emailAddress = this.form.get('email')!.value;

    this.httpClient
      .post(API_ENDPOINTS.CREATE_PARTICIPANT, participantToCreate, HTTP_OPTIONS)
      .subscribe({
        next: (createdParticipantFromServer) => {
          this.createSuccessful = true;
          this.participantService.allParticipants.push(createdParticipantFromServer as Participant);
        },
        error: (error: HttpErrorResponse) => {
          this.createFailed = true;
          console.log(`Failed to create participant! Response from server: "HTTP statuscode: ${error.status}: ${error.message}"`);
        },
      });
  }
}

