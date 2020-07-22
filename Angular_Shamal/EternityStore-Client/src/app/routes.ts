import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { CategoryProductbycategoryComponent } from './categories/category-productbycategory/category-productbycategory.component';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  // dummy route which gonna hold child routes
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
     
      //{ path: 'categories', component: CategoryListComponent },
      {path: 'orders', component: CategoryListComponent,  }
    ],
  },
  // { path : 'products', component: ProductListComponent},
  { path : 'categories', component: CategoryListComponent},
  { path : 'categories/pbc/:id', component: CategoryProductbycategoryComponent},
  { path: 'products', component: ProductListComponent },
  {path: 'productdetails/:id', component: ProductDetailComponent},
  // { path : 'orders', component: CategoryListComponent, canActivate:[AuthGuard]},
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
