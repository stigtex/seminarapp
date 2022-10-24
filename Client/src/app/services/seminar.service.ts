import { Injectable } from '@angular/core';
import { Seminar } from '../models/seminar.model';

@Injectable({
  providedIn: 'root'
})
export class SeminarService {

  constructor() { }

  allSeminars!: Seminar[];
}
