import { Component, OnInit} from '@angular/core';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { CartService } from 'src/app/_services/cart.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  product: Product;

  constructor(private productService: ProductService, private alertify: AlertifyService, private route: ActivatedRoute,
              private cartService: CartService) { }

  ngOnInit() {

    this.loadProduct();

  }

  loadProduct()
  {
     this.productService.getProduct(+this.route.snapshot.params.id).subscribe((product: Product) => {
        this.product = product;
      },
    error => {
      this.alertify.error(error);
    }
    );
  }
  addToCart(product) {
    this.cartService.addToCart(product);
    window.alert('Your product has been added to the cart!');
  }
}


