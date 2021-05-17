import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements OnInit {

  public form: FormGroup;

  public sendChild: string;

  public sendChildOutput: boolean = false;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      control: new FormControl()
    });

    this.form.controls['control'].valueChanges.subscribe(
      data =>{
        this.sendChild = data;
      });

  }

  recibAlert(data: boolean){
    if(data){
      this.sendChildOutput = data;
    }
  }

}
