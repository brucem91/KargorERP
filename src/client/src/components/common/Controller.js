import React, { Component } from 'react';
import { Route } from "react-router-dom";

class ControllerComponent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            mappedRoutes: (props.routes || []).map((route) => {
                return <Route key={route.path} exact={route.exact || true} path={route.path} component={route.component} />;
            })
        };
    }

    render() {
        return <div>{this.state.mappedRoutes}</div>
    }
}

export default ControllerComponent;