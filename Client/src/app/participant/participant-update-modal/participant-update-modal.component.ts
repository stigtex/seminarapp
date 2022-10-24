import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { Participant } from 'src/app/models/participant.model';
import { ParticipantService } from 'src/app/services/participant.service';
import { ParticipantCreateUpdateDto } from 'src/app/models/participant-create-update-dto.model';


@Component({
  selector: 'participant-update-modal',
  templateUrl: './participant-update-modal.component.html',
  styleUrls: ['./participant-update-modal.component.css']
})
export class ParticipantUpdateModalComponent implements OnInit {
  form!: FormGroup;
  participantToUpdate!: Participant;

  updateSuccessful: boolean = false;
  updateFailed: boolean = false;

  constructor(public fb: FormBuilder, private httpClient: HttpClient, public activeModal: NgbActiveModal, private participantService: ParticipantService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [this.participantToUpdate.id],
      firstName: [this.participantToUpdate.firstName],
      lastName: [this.participantToUpdate.lastName],
      email: [this.participantToUpdate.emailAddress]
    });

    this.form.controls['id'].disable();
  }

  submitForm() {
    var participantToUpdateDTO = {} as ParticipantCreateUpdateDto;

    participantToUpdateDTO.firstName = this.form.get('firstName')!.value;
    participantToUpdateDTO.lastName = this.form.get('lastName')!.value;
    participantToUpdateDTO.emailAddress = this.form.get('email')!.value;

    this.httpClient
      .put(`${API_ENDPOINTS.UPDATE_PARTICIPANT}/${this.participantToUpdate.id}`, participantToUpdateDTO, HTTP_OPTIONS)
      .subscribe({
        next: (response) => {
          this.updateSuccessful = true;

          let updatedParticipantFromServer: Participant = response as Participant;

          let updatedParticipantIndex = this.participantService.allParticipants.findIndex((participant => participant.id == updatedParticipantFromServer.id));

          this.participantService.allParticipants[updatedParticipantIndex].firstName = updatedParticipantFromServer.firstName;
          this.participantService.allParticipants[updatedParticipantIndex].lastName = updatedParticipantFromServer.lastName;
          this.participantService.allParticipants[updatedParticipantIndex].emailAddress = updatedParticipantFromServer.emailAddress;
        },
        error: (error: HttpErrorResponse) => {
          this.updateFailed = true;
          console.log(`Failed to update the participant! Response from server: "HTTP statuscode: ${error.status}: ${error.message}"`);
        },
      });
  }
}
