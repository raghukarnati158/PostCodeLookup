import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { LookupRoutingModule } from './lookup-routing.module';
//import { LayoutComponent } from '../users/layout.component';
import {LookupComponent} from './lookup.component'

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        LookupRoutingModule
    ],
    declarations: [
        //LayoutComponent,
        LookupComponent
    ]
})
export class LookupModule { }