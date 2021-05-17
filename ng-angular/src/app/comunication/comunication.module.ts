import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ParentComponent } from './parent/parent.component';
import { ChildComponent } from './child/child.component';

import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';


import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    ParentComponent,
    ChildComponent
  ],
  imports: [
    CommonModule,
    MatInputModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule
  ]
})
export class ComunicationModule { }
