import 'bootstrap';
import * as React from "react";
import * as ReactDOM from "react-dom";


class App extends React.Component<{}> {
    constructor(props: any) {
        super(props);
        this.state = {
            products: [],
            cart: [],
            totalItems: 0,
            totalAmount: 0,                        
            modalActive: false
        };        
    }

    public render() {
        return (
            <div>
                Hello
            </div>
        );
    }
}

ReactDOM.render(
    <App />,
    document.getElementById('cart-app') as HTMLElement
);
