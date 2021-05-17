import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit {

  @Input() sendParent: string;
  @Output() sendOutParent = new EventEmitter<boolean>();


  constructor() { }

  ngOnInit(): void {
  }

  sendMessageParent(msg: boolean){
    this.sendOutParent.emit(msg);
  }

}
