import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};
  // model is an empty object of type any

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) {}

  ngOnInit() {}

  login() {
    // console.log(this.model);
    this.authService.login(this.model).subscribe(
      (next) => {
        // console.log('Logged in successfully');
        this.alertify.success('Logged in successfully');
      },
      (error) => {
        console.log(error);
        this.alertify.error(error);
      }
    );
  }
  loggedIn()
  {
    // const token = localStorage.getItem('token');
    // console.log(localStorage.getItem('token'));
    //  return !!token;
    // !! = shorthand of if condition , hey if something is there in the varaible
    // return true but if something is not there in it return false
    return this.authService.loggedIn();
  }

  logOut(){
    localStorage.removeItem('token');
    //console.log('logged out');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }
}
