import * as React from "react";
import { Row, Col, Button, Panel, ListGroup, ListGroupItem } from "react-bootstrap";
import { ICartProps } from "./Interfaces";

class Cart extends React.Component<ICartProps, {}> {

    constructor(props: any) {
        super(props);
    }

    public emptyCart = () => {
        this.props.emptyCart();
    }

    public renderEmptyCart = () => {
        return (
            <ListGroup>
                <ListGroupItem>
                    Your cart is empty!
                </ListGroupItem>
            </ListGroup>
        );
    }

    public renderCartWithProducts = () => {
        return (
            <div>
                <ListGroup>
                    {this.props && this.props.data.items && this.props.data.items.map((p,i) => {
                        return (<ListGroupItem key={p.id + "-" + i}>
                            <span>{p.name}</span>
                            <div className="pull-right">
                                {p.promoPrice
                                    ? (<p ><span>{p.promoPrice}</span>{' '}<span style={{ textDecorationLine: 'line-through', textDecorationStyle: 'solid', fontSize:14, opacity:0.6 }}>{p.price}</span></p>)
                                    : (<span>{p.price}</span>)}
                            </div>                                                        
                        </ListGroupItem>);
                    })}
                </ListGroup>
                <Panel.Footer>
                    <div>
                        <Row>
                            <Col xs={6} md={6} className="cartTotal">Total: {this.props.data.total}</Col>
                            <Col xs={6} md={6}>
                                <Button bsStyle="primary" onClick={this.emptyCart} className="pull-right">Empty Cart</Button>
                            </Col>
                        </Row>
                    </div>
                </Panel.Footer>
            </div>
        );
    }

    render() {

        let cartWithProducts = (this.props.data && this.props.data.items && this.props.data.items.length) > 0;

        return (
            <Panel bsStyle="primary">
                <Panel.Heading >
                    <Panel.Title componentClass="h3">Shopping Cart</Panel.Title>
                </Panel.Heading>
                {cartWithProducts ? this.renderCartWithProducts() : this.renderEmptyCart()}
            </Panel>
        );
    }
}

export default Cart;
