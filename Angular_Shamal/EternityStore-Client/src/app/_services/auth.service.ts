import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
<<<<<<< Updated upstream
=======
import {JwtHelperService} from '@auth0/angular-jwt';
import { tokenName } from '@angular/compiler';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../_models/user';
>>>>>>> Stashed changes

@Injectable({
  providedIn: 'root',
})
export class AuthService {
<<<<<<< Updated upstream
  baseUrl = 'http://localhost:5000/api/auth/';
  constructor(private http: HttpClient) {}
=======
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  user = null;
  
  
  constructor(private http: HttpClient) {
    //localStorage.clear();
  }
>>>>>>> Stashed changes

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
    .pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
<<<<<<< Updated upstream
=======
          //can set weather a user is there
          localStorage.setItem('currentuser', JSON.stringify(model.username));
          console.log(this.decodedToken);
>>>>>>> Stashed changes
        }
      })
    );
  }
  register(model: any){
    return this.http.post(this.baseUrl + 'register', model);
<<<<<<< Updated upstream

  }
=======
  }  
loggedIn(){
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
// if not expired returns true if expired returns false
  }

  logout(){

    localStorage.removeItem('token');
    localStorage.removeItem('currentuser');
    // console.log('logged out');
  }


>>>>>>> Stashed changes
}
