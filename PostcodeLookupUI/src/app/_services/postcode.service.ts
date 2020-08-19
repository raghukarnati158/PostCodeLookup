import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { Delivery } from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class PostcodeService {
  private deliverySubject: BehaviorSubject<Delivery>;
  public delivery: Observable<Delivery>;

  constructor(
        private router: Router,
        private http: HttpClient
  ) {         
        //this.delivery = this.deliverySubject.asObservable();
  }

  getAllDeliveriesForPostcode(postcode: string) {
    return this.http.get<string[]>(`${environment.apiUrl}/PostcodeLookup/${postcode}`);
  }
}
