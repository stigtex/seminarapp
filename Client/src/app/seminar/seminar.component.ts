import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SeminarService } from '../services/seminar.service';
import ApiEndpoints from '../constants/ApiEndpoints';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { SeminarCreateModalComponent } from './seminar-create-modal/seminar-create-modal.component';
import { Seminar } from '../models/seminar.model';
import { SeminarUpdateModalComponent } from './seminar-update-modal/seminar-update-modal.component';
import { SeminarDeleteModalComponent } from './seminar-delete-modal/seminar-delete-modal.component';

@Component({
  selector: 'seminar',
  templateUrl: './seminar.component.html',
  styleUrls: ['./seminar.component.css']
})
export class SeminarComponent implements OnInit {
  modalOptions: NgbModalOptions = {
    size: 'lg'
  }

  constructor(private httpClient: HttpClient, public seminarService: SeminarService, private modalService: NgbModal) {}

  ngOnInit(): void {
    this.httpClient.get<any>(ApiEndpoints.GET_ALL_SEMINARS)
      .subscribe(result => {
        this.seminarService.allSeminars = result.seminars;
      });
  }

  onClickBtnCreateNewSeminar() {
    this.modalService.open(SeminarCreateModalComponent, this.modalOptions);
  }

  onClickBtnUpdateSeminar(seminar: Seminar) {
    const modalRef = this.modalService.open(SeminarUpdateModalComponent, this.modalOptions);
    modalRef.componentInstance.seminarToUpdate = seminar;
  }

  onClickBtnDeleteSeminar(seminar: Seminar) {
    const modalRef = this.modalService.open(SeminarDeleteModalComponent, this.modalOptions);
    modalRef.componentInstance.seminarToDelete = seminar;
  }
}
