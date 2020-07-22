import { Component, OnInit } from '@angular/core';
import { Category } from '../../_models/category';
import { ProductCategoryService } from '../../_services/productCategory.service';
import { AlertifyService } from '../../_services/alertify.service';


@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories: Category[];
  constructor(private productCategoryService: ProductCategoryService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadCategories();
  }

  loadCategories(){
    this.productCategoryService.getCategories().subscribe((categories: Category[]) => {
      this.categories = categories;
    }, error => {
      this.alertify.error(error);
    });
  }
}
