import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/_models/product';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
products: Product[];
product: Product;
  constructor(private productService: ProductService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts()
  {
    this.productService.getProducts().subscribe((poducts: Product[]) => {
      this.products = poducts;
    }, error => {
      this.alertify.error(error);
    });
  }
}
