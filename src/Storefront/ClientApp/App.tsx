import 'bootstrap';
import * as React from "react";
import * as ReactDOM from "react-dom";
import * as ReactLoader from "react-loader";
import { Grid, Row, Col } from "react-bootstrap";
import { IAppState } from "./shared/Interfaces";
import Product from "./components/Product";
import axios from 'axios';


class App extends React.Component<any, IAppState> {
    constructor(props: any) {
        super(props);
        this.state = {
            products: [],
            cart: [],
            totalItems: 0,
            totalAmount: 0,
            productsLoaded: false
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


    componentDidMount() {
        this.getProducts();
    }

    public render() {
        return (
            <Grid>
                <Row>
                    <Col xs={12} md={8}>
                        <ReactLoader loaded={this.state.productsLoaded}>
                            {this.state && this.state.products && this.state.products.map(p => { return (<Product {...p} />) })}
                        </ReactLoader>
                    </Col>
                    <Col xs={6} md={4}>
                        B
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
