import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductListComponent } from './product-list/product-list.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  // dummy route which gonna hold child routes
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'products', component: ProductListComponent },
      { path: 'categories', component: CategoryListComponent },
      {path: 'orders', component: CategoryListComponent,  }
    ],
  },
  // { path : 'products', component: ProductListComponent},
  // { path : 'categories', component: CategoryListComponent},
  // { path : 'orders', component: CategoryListComponent, canActivate:[AuthGuard]},
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
