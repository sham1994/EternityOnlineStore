import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
<<<<<<< Updated upstream
=======
import { Category } from '../_models/category';
import { ProductCategoryService } from '../_services/productCategory.service';
import { AlertifyService } from '../_services/alertify.service';
import { CartService } from '../_services/cart.service';

>>>>>>> Stashed changes

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  // add a property  registerMode
  registerMode = false ;
  values: any;
<<<<<<< Updated upstream
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }
=======
  categories: Category[];
  constructor(private http: HttpClient, private productCategoryService: ProductCategoryService, private alertify: AlertifyService, private cartService: CartService) { }

  ngOnInit() {
    this.getValues();
    this.loadCategories();
    this.cartService.updateCartState();
}



>>>>>>> Stashed changes
registerToggle()
{
  //this.registerMode = !this.registerMode;
  this.registerMode = true;
}
getValues(){
  this.http.get('http://localhost:5000/api/values').subscribe(response => {
    this.values = response;
  }, error => {
    console.log(error);
  });
}
cancelRegisterMode(registerMode: boolean)
{
 this.registerMode = registerMode;
}
}
