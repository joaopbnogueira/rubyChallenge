export interface IProductState {
    quantity: number;
}

export interface ICartState {
    loaded: boolean;
}

export interface IProduct {
    id: string;
    name: string;
    price: string;
    promoPrice: string;
}

export interface ICart {
    id: string;    
    total: string;
    items?: IProduct[];
}

export interface IAppState {
    products?: IProduct[];
    cart?: ICart;
    productsLoaded: boolean;
    cartLoaded: boolean;
}