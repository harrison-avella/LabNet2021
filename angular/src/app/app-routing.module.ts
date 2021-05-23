import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegionComponent } from './components/region/region.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { RegionUpdateComponent } from './components/region-update/region-update.component';
import { EmployeesUpdateComponent } from './components/employees-update/employees-update.component';

const routes: Routes = [
  {
    path: 'regions',
    component: RegionComponent
  },
  {
    path: 'regioUpdate',
    component: RegionUpdateComponent
  },
  {
    path: 'employees',
    component: EmployeesComponent
  },
  {
    path: 'employeeUpdate/:id',
    component: EmployeesUpdateComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
