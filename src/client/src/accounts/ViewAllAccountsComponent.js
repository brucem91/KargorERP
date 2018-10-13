import React, { Component } from 'react';
import ResourceTable from '../components/tables/ResourceTable';

class ViewAllAccountsComponent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            ajaxUrl: '/api/accounts',
            columns: [
                { 'data': 'Name', 'label': 'Account' },
                { 'data': 'AccountNumber', 'label': 'Account Number' }
            ]
        }
    }

    render() {
        return (<ResourceTable ajaxUrl={this.state.ajaxUrl} columns={this.state.columns} />);
    }
}

export default ViewAllAccountsComponent