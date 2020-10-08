import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../_services/auth.service';
<<<<<<< Updated upstream
=======
import { AlertifyService } from '../_services/alertify.service';
import {CartService} from '../_services/cart.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/_models/product';
import { User } from '../_models/user';
//import { CartComponent } from '../cart/cart.component';

>>>>>>> Stashed changes


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit, OnDestroy {
  model: any = {};
  subscription: Subscription;
  cartItemsCount: number;
  currentuser: any;
  // model is an empty object of type any

<<<<<<< Updated upstream
  constructor(private authService: AuthService) {}
=======
  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router,
              private cartService: CartService) {}

  ngOnInit() {
      this.loaditemcount();
      //this.cartService.updateCartState();
>>>>>>> Stashed changes

      
  }

  loaditemcount()
  {
    this.subscription = this.cartService.cartItemSubject.subscribe((product: Product[]) => {
      this.cartItemsCount = product.length;
    });
  }
  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

  login() {
    // console.log(this.model);
    this.authService.login(this.model).subscribe(
      (next) => {
<<<<<<< Updated upstream
        console.log('Logged in successfully');
      },
=======
        // console.log('Logged in successfully');
        this.alertify.success('Logged in successfully');
       },
>>>>>>> Stashed changes
      (error) => {
        console.log(error);
      }
    );



  }
  loggedIn()
  {
    const token = localStorage.getItem('token');
    return !!token;
    // !! = shorthand of if condition , hey if something is there in the varaible return true but if something is not there in it return false
  }

  logOut(){
<<<<<<< Updated upstream
    localStorage.removeItem('token');
    console.log('logged out');
=======
    this.authService.logout();
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
>>>>>>> Stashed changes
  }
}
