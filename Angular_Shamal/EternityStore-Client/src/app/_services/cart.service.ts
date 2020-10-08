import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import {Product} from '../_models/product';
import { ElementSchemaRegistry } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  items = [];
  itemsCount: number;
  products: Product[];
  productList: Product[] = [];
  cartItemSubject = new BehaviorSubject<Product[]>(this.items);
  shippingCost: number;
  taxcost: number;
  grandTotal: number;


constructor() { }

// ////////////////////////addToCart(product) {
 //////////////////////// //////////// this.items.push(product);
////////////////////////  // if (localStorage.getItem('items')){
 ////////////////////////   // this.items = JSON.parse(localStorage.getItem('items'));
////////////////////////  // }
 //////////////////////// // this.items.push(product);
 //////////////////////// // localStorage.setItem('items', JSON.stringify(this.items));
 //////////////////////// // this.items = JSON.parse(localStorage.getItem('items'));



// ////////////////////////}
// ////////////////////////clearCart() {
////////////////////////  // this.items = [];
////////////////////////  // return this.items;
// ////////////////////////}



/////////////////////////////////WORKING BUT OLD///////////////////////////////
addToCart(product: Product): boolean {
  this.productList = [];
  const localCartList = JSON.parse(localStorage.getItem('items'));
  if (localCartList != null)
  {
  for (let i = 0; i < localCartList.length; i++ )
  {
    this.productList.push({
      id: localCartList[i].id,
      name: localCartList[i].name,
      photoUrl: localCartList[i].photoUrl,
      description: localCartList[i].description,
      qty: localCartList[i].qty,
      unitPrice: localCartList[i].unitPrice,
      selectedProductQty: localCartList[i].selectedProductQty,
      productCategoryId: localCartList[i].productCategoryId
    });
}
}
  if (!this.productList.find(x => x.id === product.id))
{
this.items.push(product);
this.productList.push({
  id: product.id,
  name: product.name,
  photoUrl: product.photoUrl,
  description: product.description,
  qty: product.qty,
  unitPrice: product.unitPrice,
  selectedProductQty: product.selectedProductQty,
  productCategoryId: product.productCategoryId
});
this.cartItemSubject.next(this.productList);
this.localStorageSet();
return true;
}
return false;
}
//////////////////////////////////////////////////////////////////////////
// addToCart(product: Product){
//   this.productList = [];
//   const localCartList = JSON.parse(localStorage.getItem('items'));
//   if (localCartList != null)
//     {
//     for (let i = 0; i < localCartList.length; i++ )
//     {
//       this.productList.push({
//         id: localCartList[i].id,
//         name: localCartList[i].name,
//         photoUrl: localCartList[i].photoUrl,
//         description: localCartList[i].description,
//         qty: localCartList[i].qty,
//         unitPrice: localCartList[i].unitPrice,
//         selectedProductQty: localCartList[i].selectedProductQty,
//         productCategoryId: localCartList[i].productCategoryId
//       });
//   }
//   }
// }

////////////////////////////////////////////////////////////////////////

        // this.productList.push({
//   id: product.id,
//   name: product.name,
//   photoUrl: product.photoUrl,
//   description: product.description,
//   qty: product.qty,
//   unitPrice: product.unitPrice,
//   selectedProductQty: product.selectedProductQty,
//   productCategoryId: product.productCategoryId
// });
  // this.localStorageSet();
    // this.cartItemSubject.next(this.cartItems);
  //}

localStorageSet(){
  localStorage.setItem('items', JSON.stringify(this.productList));
}

// setSelectedQty(product:Product){
//   const localCartList = JSON.parse(localStorage.getItem('items'));
//   if (localCartList != null)
//       {
//       for (let i = 0; i < localCartList.length; i++ )
//       {

//       }

// }
// }

clearCart(){
  this.productList = [];
  this.cartItemSubject.next(this.productList);
  this.localStorageSet();
}

removeCartItem(id: number){
this.productList.splice(this.productList.findIndex(x => x.id === id), 1);
this.cartItemSubject.next(this.productList);
this.localStorageSet();
}

removeCartItems(){
  this.productList.length = 0;
  this.cartItemSubject.next(this.productList);
  this.localStorageSet();
  }

updateCartState(){
  this.productList = [];
  const localCartList =  JSON.parse(localStorage.getItem('items'));
  if (localCartList != null){
    for(let i = 0; i< localCartList.length; i++)
    {
      this.productList.push({
        id: localCartList[i].id,
        name: localCartList[i].name,
        photoUrl: localCartList[i].photoUrl,
        description: localCartList[i].description,
        qty: localCartList[i].qty,
        unitPrice: localCartList[i].unitPrice,
        selectedProductQty: localCartList[i].selectedProductQty,
        productCategoryId: localCartList[i].productCategoryId
      });
    }
    this.cartItemSubject.next(this.productList);
  }


}

getItems() {
  return this.items;
}



cartItemCount(){
 this.itemsCount = length;
 return this.itemsCount;
}

getSubTotalOfItems(){

  let total = 0;
  if (this.items == null)
  {
    return total;
  }
  else {
 for(let i =0; i< this.productList.length; i++){
    if (this.productList[i].unitPrice){
       total +=  this.productList[i].unitPrice * this.productList[i].selectedProductQty;
    }
  }
 return total;
}
}
getSubTotalOfAnItem(item: Product){
  let subTotalOfAnItem = 0;
  subTotalOfAnItem = item.unitPrice * item.selectedProductQty;
  return subTotalOfAnItem;
}

getGrandTotal()
{
  let subTotal = 0;
  let total = 0;
  subTotal = this.getSubTotalOfItems();
  this.shippingCost = 0;
  this.taxcost = 0;
  total = subTotal + this.shippingCost  +  this.taxcost;

  return total;

}

}
