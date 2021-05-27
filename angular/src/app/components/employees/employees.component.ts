import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { EmployeesI } from '../../models/employees.model';
import { EmployeesService } from '../../services/employees.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  public employees: EmployeesI[] =[];
  private suscription: Subscription = new Subscription();

  constructor(
    private service: EmployeesService,
 //   private router: Router,
    private toastr: ToastrService
  ) {}


  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(){
    this.suscription.add(
      this.service.getEmployees().subscribe(res=> this.employees = res)
    );
  }

/*  updateById(id: number){
     this.router.navigate(['employeeUpdate', id]);
  }
  */

  deleteById(id: number){
    this.service.deleteEmployee(id).subscribe(
     ()=> this.ngOnInit(),
     (error: HttpErrorResponse) => this.toastr.error('Que ha pasao? '+error.message,'Ups!')
    )
  }

}
