import 'bootstrap';
import * as React from "react";
import * as ReactDOM from "react-dom";
import * as ReactLoader from "react-loader";
import { Grid, Row, Col, Jumbotron } from "react-bootstrap";
import { IAppState } from "./Interfaces";
import Product from "./Product";
import Cart from "./Cart";
import axios from 'axios';


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
        axios.get('/api/products')
            .then(response => {
                this.setState({
                    products: response.data.items,
                    productsLoaded: true
                });
            });
    }

    public getCart = () => {
        axios.get('/api/cart')
            .then(response => {
                this.setState({
                    cart: response.data,
                    cartLoaded: true
                });
            });
    }

    componentDidMount() {
        this.getProducts();
        this.getCart();
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
                            {this.state && this.state.products && this.state.products.map(p => { return (<Product key={p.id} {...p} />) })}
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
