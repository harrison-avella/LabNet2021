import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { RegionI } from 'src/app/models/region.model';
import {DataService } from '../../services/data.service'

@Component({
  selector: 'app-region',
  templateUrl: './region.component.html',
  styleUrls: ['./region.component.css']
})
export class RegionComponent implements OnInit {

  public regions: RegionI[]= [];
private suscription: Subscription = new Subscription();

  constructor(
    private service: DataService

    ) { }

  ngOnInit(): void {
    this.getRegions()
  }

  getRegions(){
    this.suscription.add(
      this.service.getRegions().subscribe(res => this.regions = res)
    );
  }

}
