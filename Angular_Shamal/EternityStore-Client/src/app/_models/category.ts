import { Photo} from './photo';

export interface Category {
    id: number;
    name: string;
    photoUrl: string;
    categoryphotos?: Photo[];

}
