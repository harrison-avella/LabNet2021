import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './components/employees/employees.component';
import { EmployeesUpdateComponent } from './components/employees-update/employees-update.component';
import { CategoriesComponent } from './components/categories/categories.component';

const routes: Routes = [
  {
    path: 'employees',
    component: EmployeesComponent
  },
  {
    path: 'employeeUpdate/:id',
    component: EmployeesUpdateComponent
  },
  {
    path: 'categories',
    component: CategoriesComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
