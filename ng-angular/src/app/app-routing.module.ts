import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ParentComponent } from './comunication/parent/parent.component';

const routes: Routes = [
  {
    path: 'com', //com
    component: ParentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
