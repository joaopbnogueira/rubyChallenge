
export interface IProduct {
    id: string;
    name: string;
    price: number;
    promoPrice: string;
}

export interface IAppState {
    products?: IProduct[];
    cart?: IProduct[];
    totalItems?: number;
    totalAmount?: number;
    productsLoaded: boolean;
}