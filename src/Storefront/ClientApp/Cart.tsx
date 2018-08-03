import * as React from "react";
import { Grid, Row, Col, Button, Thumbnail, FormControl, FormGroup, Form, InputGroup, Panel, ListGroup, ListGroupItem } from "react-bootstrap";
import { ICart, ICartState } from "./Interfaces";
import * as ReactLoader from "react-loader";

class Cart extends React.Component<ICart, ICartState> {

    constructor(props: ICart) {
        super(props);
        this.state = {
            loaded: true
        };
    }
    public emptyCart = () => {
        this.setState({
            loaded: false
        });
    }

    render() {
        return (
            <Panel bsStyle="primary">
                <Panel.Heading >
                    <Panel.Title componentClass="h3">Shopping Cart</Panel.Title>
                </Panel.Heading>
                <ReactLoader loaded={this.state.loaded}>
                    <ListGroup>
                        {this.props && this.props.items && this.props.items.map(p => {
                            return (<ListGroupItem key={p.id}>
                                {p.name}
                            </ListGroupItem>)
                        })}
                    </ListGroup>
                    <Panel.Footer>
                        <div>
                            <Row>
                                <Col xs={6} md={6} className="cartTotal">Total: {this.props.total}</Col>
                                <Col xs={6} md={6}>
                                    <Button bsStyle="primary" onClick={this.emptyCart} className="pull-right">Empty Cart</Button>
                                </Col>
                            </Row>
                        </div>
                    </Panel.Footer>
                </ReactLoader>

            </Panel>
        );
    }
}

export default Cart;
