import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/_services/cart.service';
import { Subscription } from 'rxjs';
import {Product} from '../_models/product';
import { ProductService } from '../_services/product.service';
import { ProductCategoryService } from '../_services/productCategory.service';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  items: Product[];
  qty: number;
  subscription: Subscription;
  grandTotal;
  subTotalOfAnItem;
  constructor(private cartService: CartService) {
  //   window.onunload = () => {
  //     // Clear the local storage
  //     localStorage.clear();
  //  };
  }

  ngOnInit() {
    //this.items = this.cartService.getItems();
    this.cartService.updateCartState();
    this.subscription = this.cartService.cartItemSubject
                          .subscribe((product: Product[]) => { this.items = product;
                          });
  }

  getGrandTotal()
  {
    this.grandTotal = this.cartService.getGrandTotal();
    return this.grandTotal;
  }
  getSubTotalOfAnItem(item: Product){
     this.subTotalOfAnItem = this.cartService.getSubTotalOfAnItem(item);
     return this.subTotalOfAnItem;
  }
  getSubTotalOfItems(){
    let total = 0;
    total = this.cartService.getSubTotalOfItems();
    return total;
 }
  removeItem(item: Product)
  {
    this.cartService.removeCartItem(item.id);
  }
  removeAllItems()
  {
    this.cartService.removeCartItems();
  }

}
