import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
<<<<<<< Updated upstream

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent
=======
import { ProductListComponent } from './products/product-list/product-list.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { appRoutes } from './routes';
import { OrderListComponent } from './order-list/order-list.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CategoryCardComponent } from './categories/category-card/category-card.component';
import { CategoryProductbycategoryComponent } from './categories/category-productbycategory/category-productbycategory.component';
import { FooterComponent } from './footer/footer.component';
import { ProductCardComponent} from './products/product-card/product-card.component';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';



export function tokenGetter(){
   return localStorage.getItem('token');
}


@NgModule({
   declarations: [			
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      ProductListComponent,
      CategoryListComponent,
      OrderListComponent,
      CategoryCardComponent,
      CategoryProductbycategoryComponent,
      FooterComponent,
      ProductCardComponent,
      ProductDetailComponent,
      CartComponent,
      CheckoutComponent
>>>>>>> Stashed changes
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      // AuthService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
