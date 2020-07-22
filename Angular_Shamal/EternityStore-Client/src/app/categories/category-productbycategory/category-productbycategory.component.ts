import { Component, OnInit } from '@angular/core';
import { ProductCategoryService } from 'src/app/_services/productCategory.service';
import { Product } from 'src/app/_models/product';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/_models/category';

@Component({
  selector: 'app-category-productbycategory',
  templateUrl: './category-productbycategory.component.html',
  styleUrls: ['./category-productbycategory.component.css']
})
export class CategoryProductbycategoryComponent implements OnInit {

  products: Product[];
  category: Category;
  product: Product;
  categoryname: string;
  constructor(private productCategoryService: ProductCategoryService, private alertify: AlertifyService, private route: ActivatedRoute ) { }

  ngOnInit() {

    this.loadProductsByCategory();
  }

  loadProductsByCategory()
  {
    this.productCategoryService.getProductbyCategoryId(+this.route.snapshot.params.id).subscribe((products: Product[]) => {
      this.products = products;

      this.productCategoryService.getCategory(+this.route.snapshot.params.id).subscribe((category: Category) => {
        this.category = category;
      })


    },
    error => {
      this.alertify.error(error);
    }
    )
  }
}
