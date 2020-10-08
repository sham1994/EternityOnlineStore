import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../_models/product';


@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  currentUser;
  baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }




getUserDetails(userName): Observable<User>
{
  try {
  const reqheaders = new HttpHeaders({
    'Content-Type': 'application/json',
    Authorization: 'Bearer ' + localStorage.getItem('token')
  });

  return this.http.get<User>(this.baseUrl + 'Users/gubu/' + userName, {headers: reqheaders});

}
catch (err)
{
  console.log("Error on parsing string", err);
}


}

addOrder(model: any){
  
  return this.http.post(this.baseUrl + 'Orders/AddOrder', model);
}

}
