import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {HttpClientModule} from '@angular/common/http';
import { RegionComponent } from './components/region/region.component';
import { RegionUpdateComponent } from './components/region-update/region-update.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeesComponent } from './components/employees/employees.component';
import { EmployeesDeleteComponent } from './components/employees-delete/employees-delete.component';
import { EmployeesNewComponent } from './components/employees-new/employees-new.component';
import { EmployeesUpdateComponent } from './components/employees-update/employees-update.component';

import { NgxBootstrapIconsModule, allIcons } from 'ngx-bootstrap-icons';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    RegionComponent,
    RegionUpdateComponent,
    EmployeesComponent,
    EmployeesDeleteComponent,
    EmployeesNewComponent,
    EmployeesUpdateComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AppRoutingModule,
    NgxBootstrapIconsModule.pick(allIcons),
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
