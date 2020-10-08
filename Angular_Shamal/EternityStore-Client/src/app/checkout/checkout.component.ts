import { Component, OnInit } from '@angular/core';
import { CartService } from '../_services/cart.service';
import { Product } from '../_models/product';
import { BehaviorSubject, Subscription } from 'rxjs';
import { CheckoutService } from '../_services/checkout.service';
import '../../assets/smtp.js';
import { AlertifyService } from '../_services/alertify.service';
import { Input } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import { User } from '../_models/user';
import { AuthService } from '../_services/auth.service';
import { DatePipe } from '@angular/common'

declare let Email: any;

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
  providers: [DatePipe]
})
export class CheckoutComponent implements OnInit {
  @Input() valuesFromCart: any;
  items: Product[];
  localitems = [];
  orderitems = [];
  item: Product;
  user: User;
  subscription: Subscription;
  cartItemsCount: number;
  total: number;
  model: any = {};
  currentUser;
  registerMode: boolean;
  values: any;
  currentdate = new Date();


  constructor(private checkoutService: CheckoutService, private cartService: CartService,
              private alertify: AlertifyService, private authService: AuthService, public datepipe: DatePipe) {

   }

  ngOnInit() {
    this.loadCartDetails();
    this.getUser();
  }

  loadCartDetails(){

    // Load,update cart Details and Cart Items Count
    
    this.model.orderDateAndTime = this.currentdate;
    this.cartService.updateCartState();
    this.subscription = this.cartService.cartItemSubject
                          .subscribe((product: Product[]) => {
                            this.items = product;
                            this.cartItemsCount = product.length;
                            });
   // this.model.orderdetails = this.items;
    
  }
  loadCartItemsToModel()
  {
    for (let i = 0; i < this.items.length; i++)
    {
        // this.model.products[i].subTotal = this.getSubTotalOfAnItem(this.items[i]);
        const orderitemdetail = {
          productId: this.items[i].id,
          productQty: this.items[i].selectedProductQty,
          subTotal: this.getSubTotalOfAnItem(this.items[i])
        };
        this.orderitems.push(orderitemdetail);
    }

    this.model.orderdetails = this.orderitems;
  }

  getSubTotalOfItems()
  {
    let subTotal = 0;
    subTotal = this.cartService.getSubTotalOfItems();
    this.model.orderTotal = subTotal;
    return subTotal;
  }
  getSubTotalOfAnItem(item: Product){
    let subTotalOfAnItem = 0;
    this.item = item;
    subTotalOfAnItem = this.cartService.getSubTotalOfAnItem(item);
    return subTotalOfAnItem;
  }

  checkOutOrder()
  {
    this.loadCartItemsToModel();
    this.checkoutService.addOrder(this.model).subscribe(
      () => {
        // console.log('Registration successful');
        this.alertify.success('Order Placed successful');

      },
      (error) => {
        // console.log(error);
        this.alertify.error(error);
      }
    );
  }



  sendmail(){
    Email.send({
      Host : 'smtp.elasticemail.com',
      Username : 'shamdzsar@gmail.com',
      Password : 'D29E45B5B0E72EFC378EBAFE522124884C84',
      To : 'shamdzsar@gmail.com',
      From : 'shamdzsar@gmail.com',
      Subject : 'testemail',
      Body : '<i>This is sent as a feedback from my resume page</i> <br> <h2><center>Reciept</center></h2> <Br>'
    }).then(message => {this.alertify.success('Message Sent'); });
      }

      getUser(){
        if (localStorage.getItem('currentuser'))
        {
          this.currentUser =  JSON.parse(localStorage.getItem('currentuser'));
          //this.currentUser
          this.checkoutService.getUserDetails(this.currentUser).subscribe((user: User) => {
            this.user = user;
            console.log(this.user);
            this.model.userId = this.user.id;
            this.model.userName = this.user.userName;
            this.model.firstName = this.user.firstName;
            this.model.lastName = this.user.lastName;
            this.model.email = this.user.email;
            this.model.addressLine1 = this.user.addressLine1;
            this.model.addressLine2 = this.user.addressLine2;
            this.model.country  = this.user.country;
            this.model.city  = this.user.city;
            this.model.state = this.user.state;
            this.model.zip = this.user.zip;
          },
        error => {
          this.alertify.error(error);
        }
        );
        }
        else
        {
            //this.registerMode = true;
        }
      }
//       registerToggle()
// {
//        this.registerMode = true;
// }
// cancelRegisterMode(registerMode: boolean)
// {
//  //this.registerMode = registerMode;
 
// }

}


