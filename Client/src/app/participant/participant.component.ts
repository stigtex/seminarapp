import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import ApiEndpoints from '../constants/ApiEndpoints';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ParticipantService } from '../services/participant.service';
import { Participant } from '../models/participant.model';
import { ParticipantUpdateModalComponent } from './participant-update-modal/participant-update-modal.component';
import { ParticipantCreateModalComponent } from './participant-create-modal/participant-create-modal.component';
import { ParticipantDeleteModalComponent } from './participant-delete-modal/participant-delete-modal.component';

@Component({
  selector: 'participant',
  templateUrl: './participant.component.html',
  styleUrls: ['./participant.component.css']
})
export class ParticipantComponent implements OnInit {
  modalOptions: NgbModalOptions = {
    size: 'lg'
  }

  constructor(private httpClient: HttpClient, public participantService: ParticipantService, private modalService: NgbModal) {}

  ngOnInit(): void {
    this.httpClient.get<any>(ApiEndpoints.GET_ALL_PARTICIPANTS)
      .subscribe(result => {
        this.participantService.allParticipants = result.participants;
      });
  }

  onClickBtnCreateNewParticipant() {
    this.modalService.open(ParticipantCreateModalComponent, this.modalOptions);
  }

  onClickBtnUpdateParticipant(participant: Participant) {
    const modalRef = this.modalService.open(ParticipantUpdateModalComponent, this.modalOptions);
    modalRef.componentInstance.participantToUpdate = participant;
  }

  onClickBtnDeleteParticipant(participant: Participant) {
    const modalRef = this.modalService.open(ParticipantDeleteModalComponent, this.modalOptions);
    modalRef.componentInstance.participantToDelete = participant;
  }
}