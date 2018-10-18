import React, { Component } from "react";
import { Route, HashRouter, NavLink } from "react-router-dom";
import Menu from './menu';
import Routes from './routes';

class Main extends Component {
    render() {
        return (
            <HashRouter>
                <div>
                    <Menu />
                    <div className="container-fluid">
                        <div className="col-md-12">
                            <Routes />
                        </div>
                    </div>
                </div>
            </HashRouter>
        );
    }
}

export default Main;