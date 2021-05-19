import { Component } from '@angular/core';
import { DataService } from './services/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[DataService],
})
export class AppComponent {
  title = 'angular';

constructor(private dataSvc: DataService){}

ngOnInit(){
  this.dataSvc.getAll().subscribe((res)=> {
    console.log('Res', res);
  });
}


}
