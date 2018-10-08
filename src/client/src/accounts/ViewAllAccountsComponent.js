import React, { Component } from 'react';
import { NavLink } from "react-router-dom";
import axios from 'axios';

class AccountRow extends Component {
    render() {
        return (
            <tr>
                <td>{this.props.account.AccountNumber}</td>
                <td>{this.props.account.Name}</td>
            </tr>
        )
    }
}

class AccountRowCollection extends Component {
    render() {
        if ((this.props.accounts || []).length === 0) {
            return (
                <tr>
                    <td colSpan="2">No Account(s) Found</td>
                </tr>
            )
        }

        return ((this.props.accounts || []).map((account) => (<AccountRow key={account.AccountId} account={account} />)));
    }
}

class ViewAllAccountsComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {};
        this.fetchAccounts();
    }

    fetchAccounts = () => {
        var self = this;

        axios.get(`/api/accounts`).then((res) => {
            self.setState({ accounts: res.data });
        }).catch((err) => {

        });
    }

    handleKeywordChange = (event) => {
        this.setState({ searchTerms: event.target.value }, () => this.fetchAccounts());
    }

    render() {
        return (
            <div>
                <input type="text" value={this.state.searchTerms || ''} onChange={this.handleKeywordChange} />
                <NavLink className="btn btn-primary" to="/accounts/create">Create Account</NavLink>
                <table className="table table-striped table-sm">
                    <thead>
                        <tr>
                            <th>Account Number</th>
                            <th>Full Name</th>
                            <th>Product</th>
                        </tr>
                    </thead>
                    <tbody>
                        <AccountRowCollection accounts={(this.state.accounts || [])} />
                    </tbody>
                </table>
            </div>
        );
    };
}

export default ViewAllAccountsComponent