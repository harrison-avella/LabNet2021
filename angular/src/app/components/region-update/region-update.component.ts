import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {  DataService } from '../../services/data.service';
import {RegionI} from '../../models/region.model'


@Component({
  selector: 'app-region-update',
  templateUrl: './region-update.component.html',
  styleUrls: ['./region-update.component.css']
})
export class RegionUpdateComponent implements OnInit {

  form: FormGroup;

  constructor(
    private formBuldier: FormBuilder,
    private service: DataService,
    private route: Router

  ) { }

  ngOnInit(): void {
    this.form = this.formBuldier.group({
      id: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required)
    })
  }

  get idCrl(): AbstractControl{
    return this.form.get('id');
  }

  get descriptionCrtl(): AbstractControl{
    return this.form.get('descripcion');
  }

  onUpdate(): void{
    var region = new RegionI();
    region.RegionID = this.idCrl.value;
    region.RegionDescription = this.descriptionCrtl.value;
    this.service.updateRegion(this.idCrl.value,region).subscribe({
      complete: ()=>{
        alert("Exito!");
        this.form.reset();
      },
      error:(error)=>{
        alert(error.error?.ExeptionMessage ?? error.error);
      }
    });
  }

}
