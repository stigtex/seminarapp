import { Injectable } from '@angular/core';
import { Participant } from '../models/participant.model';

@Injectable({
  providedIn: 'root'
})
export class ParticipantService {

  constructor() { }

  allParticipants!: Participant[];
}
