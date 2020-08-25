import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../_models/category';
import { ProductCategoryService } from '../_services/productCategory.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  // add a property  registerMode
  registerMode = false ;
  values: any;
  categories: Category[];
  constructor(private http: HttpClient, private productCategoryService: ProductCategoryService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.getValues();
    this.loadCategories();
}



registerToggle()
{
  // this.registerMode = !this.registerMode;
  this.registerMode = true;
}
getValues(){
  this.http.get('http://localhost:5000/api/values').subscribe(response => {
    this.values = response;
  }, error => {
    console.log(error);
  });
}
cancelRegisterMode(registerMode : boolean)
{
 this.registerMode = registerMode;
}
loadCategories(){
  this.productCategoryService.getCategories().subscribe((categories: Category[]) => {
    this.categories = categories;
  }, error => {
    this.alertify.error(error);
  });
}
}
