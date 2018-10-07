import React, { Component } from "react";
import { Route, HashRouter } from "react-router-dom";

class Main extends Component {
    render() {
        return (
            <HashRouter>
                <div>
                    {/* <Menu /> */}
                    <div className="container">
                        <div className="col-md-12">
                            {/* <Route exact path="/" component={Home} /> */}
                            <h2>Hello World</h2>
                            {/* <Route path="/stuff" component={Stuff} />
                            <Route path="/contact" component={Contact} />
                            <Route path="/products" component={Products} />
                            <Route path="/users" component={Users} /> */}
                        </div>
                    </div>
                </div>
            </HashRouter>
        );
    }
}

export default Main;