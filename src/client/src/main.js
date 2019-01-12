import React, { Component } from "react";
import { Route, HashRouter, NavLink } from "react-router-dom";
import Menu from './menu';
import Routes from './routes';
import axios from 'axios';

class Main extends Component {
    constructor(props) {
        super(props);

        var currentRoute = window.location.hash.replace('#/', '/').toLowerCase().trim();

        alert(currentRoute);

        axios.get('/api/application/status')
            .then((results) => {
                if (results.data.IsInitialized === false && currentRoute !== '/initialize'){
                    this.props.history.push('/initialize');
                }
            }).catch((err) => {

            });
    }
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