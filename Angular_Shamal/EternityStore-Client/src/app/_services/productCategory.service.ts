import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';
import { Product } from '../_models/product';


// const httpOptions = {
//   headers : new HttpHeaders(
//     {
//       'Authorization': 'Bearer ' + localStorage.getItem('token');
//     }
//   )
// };

@Injectable({
  providedIn: 'root',
})
export class ProductCategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'productcategories');
    // return this.http.get<Category[]>(this.baseUrl + 'productcategories', httpoptions);
    // http options to pass the bearer token
  }
  getCategory(id): Observable<Category> {
    return this.http.get<Category>(this.baseUrl + 'productcategories/' + id);
  }

  getProductbyCategoryId(id): Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl + 'productcategories/pbc/' + id);

  }
}
