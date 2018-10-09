import React, { Component } from 'react';
import { NavLink } from "react-router-dom";
import axios from 'axios';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSearch } from '@fortawesome/free-solid-svg-icons'

class AccountRow extends Component {
    render() {
        return (
            <tr>
                <td>{this.props.account.Name}</td>
                <td>{this.props.account.AccountNumber}</td>
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
                <div className="row">
                    <div className="col-md-3">
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="inputGroup-sizing-default"><FontAwesomeIcon icon={faSearch} /></span>
                            </div>
                            <input type="text" value={this.state.searchTerms || ''} onChange={this.handleKeywordChange} className="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
                        </div>
                    </div>
                    <div className="col-md-9 text-right">
                        <NavLink className="btn btn-primary" to="/accounts/create">Create Account</NavLink>
                    </div>
                </div>

                <div className="row">
                    <div className="col-md-12">
                        <table className="table">
                            <thead>
                                <tr>
                                    <th>Account</th>
                                    <th>Account Number</th>
                                </tr>
                            </thead>
                            <tbody>
                                <AccountRowCollection accounts={(this.state.accounts || [])} />
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        );
    };
}

export default ViewAllAccountsComponent