import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeesComponent } from './components/employees/employees.component';
import { EmployeesNewComponent } from './components/employees-new/employees-new.component';
import { EmployeesUpdateComponent } from './components/employees-update/employees-update.component';

import { NgxBootstrapIconsModule, allIcons } from 'ngx-bootstrap-icons';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { CategoriesComponent } from './components/categories/categories.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeesNewComponent,
    EmployeesUpdateComponent,
    CategoriesComponent
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
