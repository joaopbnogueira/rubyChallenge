import * as React from "react";
import { Col, Button, Thumbnail, FormControl, FormGroup, Form, InputGroup } from "react-bootstrap";
import { IProductProps, IProductState } from "./Interfaces";

class Product extends React.Component<IProductProps, IProductState> {

    constructor(props: IProductProps) {
        super(props);
        this.state = {
            quantity: 1
        };
    }

    public updateQuantity = (evt: any) => {
        console.log(evt);
        let target = evt.target as HTMLInputElement;
        this.setState({
            quantity: parseInt(target.value, 10)
        });
    }

    public addToCart = () => {
        this.props.addToCart(this.props.data.id, this.state.quantity);
    }

    render() {
        return (
            <Col xs={12} sm={6} md={4}>
                <Thumbnail src={"/images/" + this.props.data.id+".jpg"}>
                    <h5>{this.props.data.name}</h5>
                    <p>{this.props.data.price}</p>
                    <FormGroup>
                        <InputGroup>
                            <FormControl type="number" min="1" max="100" value={this.state.quantity} placeholder="Enter text" onChange={this.updateQuantity} />
                            <InputGroup.Button>
                                <Button bsStyle="primary" onClick={this.addToCart}>Add to cart</Button>
                            </InputGroup.Button>
                        </InputGroup>
                    </FormGroup>
                </Thumbnail>
            </Col>
        );
    }
}

export default Product;
