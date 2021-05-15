import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'The Northwind API';
  numero = '1';
  mostrar = true;
  frase: any = {
    mensaje: '¡El doc esta vivo!',
    autor: 'Marty'
  }

  personajes: string[] = ['Marty', 'Doc', 'Biff']
}
