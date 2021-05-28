import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeesI } from '../../models/employees.model';
import { EmployeesService } from '../../services/employees.service';

@Component({
  selector: 'app-employees-update',
  templateUrl: './employees-update.component.html',
  styleUrls: ['./employees-update.component.css']
})

export class EmployeesUpdateComponent implements OnInit {

  form = new FormGroup({
    Id: new FormControl(''),
    FirstName: new FormControl('', Validators.required),
    LastName: new FormControl('', Validators.required),
    Address: new FormControl('', Validators.required),
    City: new FormControl('', Validators.required),
  });

  constructor(
      private readonly fb: FormBuilder,
      private service: EmployeesService,
      private toastr: ToastrService,
      private activeRouter: ActivatedRoute,
    ) { }

      //Getters
  get idCtrl(): AbstractControl {
    return this.form.get('Id');
  }

  get firstNameCtrl(): AbstractControl {
    return this.form.get('FirstName');
  }

  get lastNameCtrl(): AbstractControl {
    return this.form.get('LastName');
  }

  get addressCtrl(): AbstractControl {
    return this.form.get('Address');
  }

  get cityCtrl(): AbstractControl {
    return this.form.get('City');
  }

    ngOnInit(): void {
      let employeeId = this.activeRouter.snapshot.paramMap.get('id');
      var id = parseInt(employeeId);
      this.service.getEmployee(id).subscribe((json) => {
        this.idCtrl.setValue(json.Id);
        this.firstNameCtrl.setValue(json.FirstName);
        this.lastNameCtrl.setValue(json.LastName);
        this.cityCtrl.setValue(json.City);
        this.addressCtrl.setValue(json.Address);
      });
    }

    modificar() {
      this.service.putEmployee(this.form.value).subscribe(
        () => {
          this.toastr.success('¡Empleado modificado con exito!', 'Hecho');
        },
        (error: HttpErrorResponse) =>
          this.toastr.error('No se pudo modificar.', 'Error')
      );
    }
}

