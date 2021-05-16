import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent implements OnInit {

  form: FormGroup;

  get nombreCtrl(): AbstractControl {
    return this.form.get('nombre');
  }

  get apellidoCtrl(): AbstractControl {
    return this.form.get('apellido');
  }

  get emailCtrl(): AbstractControl {
    return this.form.get('email');
  }

  get mensajeCtrl(): AbstractControl {
    return this.form.get('mensaje');
  }

  constructor(private readonly fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      mensaje: ['']
    });
  }

  onSubmit(): void {
    console.log(this.form.value);
    console.log(this.form.valid);
  }

  onClickLimpiar(): void {
    if (this.nombreCtrl) {
      this.nombreCtrl.setValue('');
    }
    if (this.apellidoCtrl) {
      this.apellidoCtrl.setValue('');
    }
    if (this.emailCtrl) {
      this.emailCtrl.setValue('');
    }
    if (this.mensajeCtrl) {
      this.mensajeCtrl.setValue('');
    }
  }
}
