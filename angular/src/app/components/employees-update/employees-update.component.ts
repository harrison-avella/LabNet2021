import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeesI } from '../../models/employees.model';
import { EmployeesService } from '../../services/employees.service';

@Component({
  selector: 'app-employees-update',
  templateUrl: './employees-update.component.html',
  styleUrls: ['./employees-update.component.css']
})

export class EmployeesUpdateComponent implements OnInit {


  form : FormGroup;

  constructor(private readonly fb: FormBuilder,private service: EmployeesService) { }


  ngOnInit(): void {
    this.form = this.fb.group({
      nombre: new FormControl('',Validators.required),
      apellido: new FormControl('',Validators.required),
      direccion: new FormControl('',Validators.required),
      ciudad: new FormControl('',Validators.required),
      id: new FormControl('',Validators.required)
  })
  }
  //Getters
  get firstNameCtrl(): AbstractControl{
    return this.form.get('FirstName');
  }

  get lastNameCtrl(): AbstractControl{
    return this.form.get('LastName');
  }

  get addressCtrl(): AbstractControl{
    return this.form.get('Address');
  }

  get cityCtrl(): AbstractControl{
    return this.form.get('City');
  }

  onUpdate(): void{
    var emp = new EmployeesI();
    /*emp.firstName = this.nombreCtrl.value;
    emp.lastName = this.apellidoCtrl.value;
    emp.address = this.direccionCtrl.value;
    emp.city= this.ciudadCtrl.value;
    this.service.updateEmployee(this.idCtrl.value,emp).subscribe(
      {
        complete: ()=>{
          alert("Empleado modificado");
          this.formUpdate.reset();
        },
        error: (err)=>{
          alert(err.error?.ExceptionMessage ?? err.error);
        }
      }
    );*/
  }
}

