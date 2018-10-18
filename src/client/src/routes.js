import React, { Component } from 'react';
import { Route } from "react-router-dom";
import AccountController from './controllers/accounts.controller';

const routes = [
    { path: '/accounts', component: AccountController }
];

class RoutesComponent extends Component {
    render() {
        return <div>
            {routes.map((route, idx) => {
                return <Route key={route.path + idx.toString()} exact={route.exact || false} path={route.path} component={route.component} />;
            })}
        </div>
    }
}

export default RoutesComponent;