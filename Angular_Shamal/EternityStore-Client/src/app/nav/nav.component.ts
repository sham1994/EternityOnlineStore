import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};
  // model is an empty object of type any

  constructor(private authService: AuthService) {}

  ngOnInit() {}

  login() {
    // console.log(this.model);
    this.authService.login(this.model).subscribe(
      (next) => {
        console.log('Logged in successfully');
      },
      (error) => {
        console.log('Failed to login');
      }
    );
  }
  loggedIn()
  {
    const token = localStorage.getItem('token');
    return !!token;
    // !! = shorthand of if condition , hey if something is there in the varaible return true but if something is not there in it return false
  }

  logOut(){
    localStorage.removeItem('token');
    console.log('logged out');
  }
}
