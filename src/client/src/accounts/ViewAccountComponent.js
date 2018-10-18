import React, { Component } from 'react';
import axios from 'axios';
import query from '../utilities/querystring';
import field from '../components/Field';
import Field from '../components/Field';

class ViewAccountComponent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            account: {
                AccountId: (query().AccountId || 'a'),
                Name: '',
                AccountNumber: '',
                AddressLine1: '',
                AddressLine2: '',
                AddressLine3: ''
            }
        };

        this.fetchAccount();
    }

    fetchAccount = () => {
        axios.get(`/api/accounts/${this.state.account.AccountId || ''}`).then((res) => {
            this.setState({ account: res.data });
        }).catch(err => {

        });
    };

    render() {
        return (
            <div className="row">
                <div className="col-lg-4">
                    <div className="form-horizontal">
                        <Field title={'Name'} value={this.state.account.Name} />
                    </div>
                </div>
            </div>
        );
    }
}

export default ViewAccountComponent;