import * as React from "react";
import { IProduct } from "../shared/Interfaces";

class Product extends React.Component<IProduct, {}> {

    constructor(props: IProduct) {
        super(props);      
    }
    
    render() {        
        return (
            <div className="product">
                <div className="product-image">
                    
                </div>
                <h4 className="product-name">{this.props.name}</h4>
                <p className="product-price">{this.props.price}</p>
                <div className="product-action">
                    
                </div>
            </div>
        )
    }
}

export default Product;
