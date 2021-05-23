import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { RegionI } from 'src/app/models/region.model';
import {DataService } from '../../services/data.service'
import {Router} from '@angular/router'

@Component({
  selector: 'app-region',
  templateUrl: './region.component.html',
  styleUrls: ['./region.component.css']
})
export class RegionComponent implements OnInit {

  public regions: RegionI[]= [];
private suscription: Subscription = new Subscription();

  constructor(
    private service: DataService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.getRegions()
  }

  getRegions(){
    this.suscription.add(
      this.service.getRegions().subscribe(res => this.regions = res)
    );
  }


  updateRegion(id: number){
    this.router.navigate(['/see/'+id])
  }
}
