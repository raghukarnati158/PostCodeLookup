import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { PostcodeService, AlertService } from '@app/_services';
import { Delivery } from '@app/_models';

@Component({
  selector: 'app-lookup',
  templateUrl: './lookup.component.html',
  styleUrls: ['./lookup.component.less']
})
export class LookupComponent implements OnInit {

  constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private alertService: AlertService,
        private postcodeService: PostcodeService
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      //this.name = params['name'];
    });
  }

  public deliveries = [];

  public GetDeliveryInfo(postcode:string){
    console.log("PostCode:" + postcode);

    this.postcodeService.getAllDeliveriesForPostcode(postcode)
        .subscribe((data) => {
          this.deliveries = data;
        });        
  }

}
