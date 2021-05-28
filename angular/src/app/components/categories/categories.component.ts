import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { CategoriesI } from '../../models/categories.model';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  public categories: CategoriesI[] = [];
  private suscription: Subscription = new Subscription();

  constructor(
    private service: CategoriesService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getCategories();
  }


  getCategories() {
    this.suscription.add(
      this.service.get().subscribe(res => this.categories = res)
    );
  }

  deleteById(id: number) {
    this.service.delete(id).subscribe(
      () => this.ngOnInit(),
      (error: HttpErrorResponse) => this.toastr.error('Que ha pasao? ' + error.message, 'Ups!')
    )
  }



}
