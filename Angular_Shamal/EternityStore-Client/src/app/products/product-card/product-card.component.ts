import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { Product } from 'src/app/_models/product';


declare var $: any;


@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input() category: Category;
  @Input() product: Product;

  constructor()
   {
    }

  ngOnInit() {}

}
