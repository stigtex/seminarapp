import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import API_ENDPOINTS from 'src/app/constants/ApiEndpoints';
import HTTP_OPTIONS from 'src/app/constants/HttpOptions';
import { SeminarService } from 'src/app/services/seminar.service';
import { Seminar } from 'src/app/models/seminar.model';


@Component({
  selector: 'seminar-delete-modal',
  templateUrl: './seminar-delete-modal.component.html',
  styleUrls: ['./seminar-delete-modal.component.css']
})
export class SeminarDeleteModalComponent {
  seminarToDelete!: Seminar;

  deleteSuccessful: boolean = false;
  deleteFailed: boolean = false;

  constructor(private httpClient: HttpClient, public activeModal: NgbActiveModal, private seminarService: SeminarService) { }

  onClickBtnDelete() {
    this.httpClient
      .put(`${API_ENDPOINTS.DELETE_SEMINAR}/${this.seminarToDelete.id}`, HTTP_OPTIONS)
      .subscribe({
        next: () => {
          this.deleteSuccessful = true;

          const index = this.seminarService.allSeminars.indexOf(this.seminarToDelete);
          if (index > -1) {
            this.seminarService.allSeminars.splice(index, 1);
          }
        },
        error: (error: HttpErrorResponse) => {
          this.deleteFailed = true;
          console.log('Failed to delete the seminar! Error from server:');
          console.log(error.message);
        },
      });
  }
}

