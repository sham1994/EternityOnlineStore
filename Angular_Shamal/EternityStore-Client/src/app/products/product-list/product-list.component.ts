import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
product: Product[];
  constructor() { }

  ngOnInit() {
  }

}
