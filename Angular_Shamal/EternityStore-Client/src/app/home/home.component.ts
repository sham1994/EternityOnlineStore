import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
 
  // add a property  registerMode
  registerMode = false ;
  constructor() { }

  ngOnInit() {
  }
registerToggle()
{
  this.registerMode = !this.registerMode;
}
}
