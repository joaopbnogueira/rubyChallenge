import 'bootstrap';
import * as React from "react";
import * as ReactDOM from "react-dom";
import * as ReactLoader from "react-loader";
import { Grid, Row, Col, Jumbotron } from "react-bootstrap";
import Product from "./Product";
import Cart from "./Cart";
import axios from 'axios';
import { IAppState, IProductsResponse, ICartResponse, IProductProps, IPutProductInCartRequest } from "./Interfaces";

class App extends React.Component<any, IAppState> {
    constructor(props: any) {
        super(props);
        this.state = {
            products: null,
            cart: null,
            productsLoaded: false,
            cartLoaded: false
        };
    }

    public getProducts = () => {
        axios.get<IProductsResponse>('/api/products')
            .then(response => {
                this.setState({
                    products: response.data.items.map(productData => {
                        var product: IProductProps = {
                            data: productData,
                            addToCart: this.addToCart
                        };
                        return product;
                    }),                    
                    productsLoaded: true
                });
            }).catch((e) => console.log(e));
    }

    public refreshCart = () => {
        this.setState({
            cartLoaded: false,
        });

        axios.get<ICartResponse>('/api/cart')
            .then(response => {
                this.setState({
                    cartLoaded: true,
                    cart: {
                        emptyCart: this.emptyCart,
                        data: response.data
                    }
                });
            }).catch((e) => console.log(e));
    }
    
    public addToCart = (productId: string, quantity: number): boolean => {
        
        var request: IPutProductInCartRequest = {
            productId: productId,
            quantity: quantity
        }

        axios.put('/api/cart/'+this.state.cart.data.id, request)
            .then(() => this.refreshCart())
            .catch((e) => {
                console.log(e);
                return false;
            });

        return true;
    }

    public emptyCart = () => {
        console.log("emptyCart");
        axios.get('/api/cart')
            .then(_ => {
                this.setState({
                    cartLoaded: true,
                    cart: {
                        emptyCart: this.emptyCart,
                        data: null
                    }
                });
            }).catch((e) => console.log(e));
    }
    

    componentDidMount() {
        this.getProducts();
        this.refreshCart();
    }

    public render() {
        return (
            <Grid>                
                <Row>
                    <Col xs={12} md={12}>
                        <Jumbotron>
                            <p>We are thrilled to have you at the Cabify Store. Checkout our amazing products at great prices!</p>
                        </Jumbotron>
                    </Col>
                </Row>
                <Row>
                    <Col xs={12} md={8}>
                        <ReactLoader loaded={this.state.productsLoaded}>
                            {this.state && this.state.products && this.state.products.map(p => { return (<Product key={p.data.id} {...p} />) })}
                        </ReactLoader>
                    </Col>
                    <Col xs={6} md={4}>
                        <ReactLoader loaded={this.state.cartLoaded}>
                            {this.state && this.state.cart && <Cart {...this.state.cart} />}
                        </ReactLoader>
                    </Col>
                </Row>
            </Grid>
        );
    }
}

ReactDOM.render(
    <App />,
    document.getElementById('cart-app') as HTMLElement
);
