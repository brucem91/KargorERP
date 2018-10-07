import React, { Component } from 'react';
import { NavLink } from "react-router-dom";
import './css/navbar-top-fixed.css';

class Menu extends Component {
  render() {
    return (
      <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
        <NavLink className="navbar-brand" to="/">Kargor ERP</NavLink>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarCollapse">
          <ul className="navbar-nav mr-auto">
            <li className="nav-item">
              <NavLink className="nav-link" to="/">Home</NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/accounts">Accounts</NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/quotes">Quotes</NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/orders">Orders</NavLink>
            </li>
            <li className="nav-item">
              <NavLink className="nav-link" to="/invoices">Invoices</NavLink>
            </li>
          </ul>
          <form className="form-inline mt-2 mt-md-0">
            <input className="form-control mr-sm-2" type="text" placeholder="Search" aria-label="Search" />
            <button className="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
          </form>
        </div>
      </nav>
    );
  }
}

export default Menu;