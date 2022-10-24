import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { ParticipantService } from 'src/app/services/participant.service';
import { Participant } from 'src/app/models/participant.model';


@Component({
  selector: 'participant-delete-modal',
  templateUrl: './participant-delete-modal.component.html',
  styleUrls: ['./participant-delete-modal.component.css']
})
export class ParticipantDeleteModalComponent {
  participantToDelete!: Participant;

  deleteSuccessful: boolean = false;
  deleteFailed: boolean = false;

  constructor(private httpClient: HttpClient, public activeModal: NgbActiveModal, private participantService: ParticipantService) { }

  onClickBtnDelete() {
    this.httpClient
      .put(`${API_ENDPOINTS.DELETE_PARTICIPANT}/${this.participantToDelete.id}`, HTTP_OPTIONS)
      .subscribe({
        next: () => {
          this.deleteSuccessful = true;

          const index = this.participantService.allParticipants.indexOf(this.participantToDelete);
          if (index > -1) {
            this.participantService.allParticipants.splice(index, 1);
          }
        },
        error: (error: HttpErrorResponse) => {
          this.deleteFailed = true;
          console.log('Failed to delete the participant! Error from server:');
          console.log(error.message);
        },
      });
  }
}

