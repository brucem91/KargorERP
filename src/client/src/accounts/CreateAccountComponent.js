import React, { Component } from 'react';
// import { BrowserHistory } from 'react-router-dom';

import axios from 'axios';

class CreateAccountComponent extends Component {

    constructor(props) {
        super(props);

        this.Name = React.createRef();
        this.AccountNumber = React.createRef();
        this.AddressLine1 = React.createRef();
        this.AddressLine2 = React.createRef();
        this.AddressLine3 = React.createRef();
    }

    handleFormSubmit = (event) => {
        event.preventDefault();
        var self = this;
        alert(self);
        // BrowserHistory.push('/abc');
        axios.post('/api/accounts', this.account).then((res) => {
            if (res.status === 400) self.setState({ errors: res.data });
            if (res.status == 200) {
                // History.
                //location.pathname = '/accounts/view';
            }
        }).catch((err) => {

        });
    }

    render() {
        return (
            <form onSubmit={this.handleFormSubmit}>
                <div className="form-group">
                    <label htmlFor="Name">Name</label>
                    <input type="text" className="form-control" ref={this.Name}></input>
                </div>
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        );
    }
}

export default CreateAccountComponent;