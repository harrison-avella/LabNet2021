import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeesI } from '../../models/Employees';
import { EmployeesService } from '../../services/employees.service';

@Component({
  selector: 'app-employees-update',
  templateUrl: './employees-update.component.html',
  styleUrls: ['./employees-update.component.css']
})

export class EmployeesUpdateComponent implements OnInit {


  formUpdate : FormGroup;

  constructor(private readonly fb: FormBuilder,private service: EmployeesService) { }


  ngOnInit(): void {
    this.formUpdate = this.fb.group({
      nombre: new FormControl('',Validators.required),
      apellido: new FormControl('',Validators.required),
      direccion: new FormControl('',Validators.required),
      ciudad: new FormControl('',Validators.required),
      id: new FormControl('',Validators.required)
  })
  }
  //Getters
  get nombreCtrl(): AbstractControl{
    return this.formUpdate.get('nombre');
  }

  get apellidoCtrl(): AbstractControl{
    return this.formUpdate.get('apellido');
  }

  get direccionCtrl(): AbstractControl{
    return this.formUpdate.get('direccion');
  }

  get ciudadCtrl(): AbstractControl{
    return this.formUpdate.get('ciudad');
  }

  get idCtrl(): AbstractControl{
    return this.formUpdate.get('id');
  }

  onUpdate(): void{
    var emp = new EmployeesI();
    emp.firstName = this.nombreCtrl.value;
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
    );
  }
}

