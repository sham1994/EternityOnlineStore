import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';



import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
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
      CartComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      CarouselModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      BrowserAnimationsModule,
      JwtModule.forRoot({
         config : {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth' ]

         }
})
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
