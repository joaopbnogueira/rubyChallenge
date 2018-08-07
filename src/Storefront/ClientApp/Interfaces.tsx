export interface IPutProductInCartRequest {
    productId: string;
    quantity: number;
}

export interface IProductsResponse {
    items?: IProductData[];
}

export interface ICartResponse {    
    total: string;
    items?: IProductData[];
}

export interface IProductData {
    id: string;
    name: string;
    price: string;
    promoPrice: string;    
}

export interface IAppState {
    products?: IProductProps[];
    productsLoaded: boolean;
    cart: ICartProps;
    cartLoaded: boolean;    
}

export interface IProductState {
    quantity: number;
}
export interface IProductProps {    
    data: IProductData;
    addToCart(productId: string, quantity: number): boolean;
}

export interface ICartProps {
    data: ICartResponse;
    emptyCart(): any;    
}