import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeesService } from '../../services/employees.service';
import { EmployeesI } from '../../models/employees.model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-employees-new',
  templateUrl: './employees-new.component.html',
  styleUrls: ['./employees-new.component.css']
})
export class EmployeesNewComponent implements OnInit {
  form : FormGroup;


  constructor(
    private readonly formBuldier: FormBuilder,
    private service: EmployeesService,
    private toastr: ToastrService,
    private route: Router
    ) {}

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

  ngOnInit(): void{
    this.form = this.formBuldier.group({
      FirstName: new FormControl('',Validators.maxLength(20)),
      LastName: new FormControl('',Validators.maxLength(10)),
      Address: new FormControl('',Validators.maxLength(60)),
      City: new FormControl('',Validators.maxLength(15))
    })
  }

  onAdd(): void{
    this.service.postEmployee(this.form.value).subscribe(
      ()=>{
        this.toastr.success('Por fin mi heroe.', 'Se agrego el esclavo'),
        this.clean();
      },
      (error: HttpErrorResponse) => this.toastr.error('No es posible que mal '+error.message,'Me lleva la cachetada')
    );
    }


  onUpdate(): void{
    this.service.patchEmployee(this.form.value.id,this.form.value).subscribe(
      ()=>{
        this.toastr.success('Por fin mi heroe.', 'Se edito el esclavo'),
        this.clean();
      },
      (error: HttpErrorResponse) => this.toastr.error('No es posible que mal '+error.message,'Me lleva la cachetada')
    );
  }

clean(): void{
  this.form.reset();
}
}
