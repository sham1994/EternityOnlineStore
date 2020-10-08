import { Photo } from './photo';

export interface Product {

    id: number;
    name: string;
    photoUrl: string;
    description: string;
    qty: number;
    unitPrice: any;
    productCategoryId: number;
    selectedProductQty: number;
    productphotos?: Photo[];
}
