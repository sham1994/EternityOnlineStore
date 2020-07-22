import { Photo } from './photo';

export interface Product {

    id: number;
    name: string;
    photoUrl: string;
    unitPrice: any;
    productCategoryId: number;
    productphotos?: Photo[];
}
