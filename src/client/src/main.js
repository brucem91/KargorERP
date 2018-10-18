import React, { Component } from "react";
import { Route, HashRouter, NavLink } from "react-router-dom";
import Menu from './menu';
import ViewAllAccountsComponent from './accounts/ViewAllAccountsComponent';
import CreateAccountComponent from './accounts/CreateAccountComponent';
import ViewAccountComponent from './accounts/ViewAccountComponent';

class Main extends Component {
    render() {
        return (
            <HashRouter>
                <div>
                    <Menu />
                    <div className="container-fluid">
                        <div className="col-md-12">
                            <Route exact path="/accounts" component={ViewAllAccountsComponent} />
                            <Route exact path="/accounts/create" component={CreateAccountComponent} />
                            <Route exact path="/accounts/view" component={ViewAccountComponent} />
                        </div>
                    </div>
                </div>
            </HashRouter>
        );
    }
}

export default Main;