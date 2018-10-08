import React, { Component } from 'react';
import { NavLink } from "react-router-dom";
import Button from '../components/Button';
import Input from '../components/Input';
import axios from 'axios';

class CreateAccountComponent extends Component {

    constructor(props) {
        super(props);

        this.state = {
            newAccount: {
                Name: '',
                AccountNumber: '',
                AddressLine1: '',
                AddressLine2: '',
                AddressLine3: ''
            }
        };
    }

    handleInput = (e) => {
        let value = e.target.value;
        let name = e.target.name;
        this.setState(prevState => ({ newAccount: { ...prevState.newAccount, [name]: value } }));
    }

    handleFormSubmit = (e) => {
        e.preventDefault();

        let self = this;

        axios.post('/api/accounts', this.state.newAccount).then((res) => {

        }).catch((err) => {
            let res = err.response;
            if (res === undefined) return;

            self.setState({ newAccountErrors: res.data });
        });
    }

    handleClearForm = () => {

    };

    render() {
        return (
            <div className="row">
                <div className="col-lg-4">
                    <h4>Create a new Account</h4>
                    <hr />
                    <form onSubmit={this.handleFormSubmit}>
                        <Input type={'text'} title={'Name'} name={'Name'} value={this.state.newAccount.Name} errors={(this.state.newAccountErrors || {}).Name} handleChange={this.handleInput} />
                        <Input type={'text'} title={'Account Number'} name={'AccountNumber'} value={this.state.newAccount.AccountNumber} errors={(this.state.newAccountErrors || {}).AccountNumber} handleChange={this.handleInput} />
                        <Input type={'text'} title={'Address Line 1'} name={'AddressLine1'} value={this.state.newAccount.AddressLine1} errors={(this.state.newAccountErrors || {}).AddressLine1} handleChange={this.handleInput} />
                        <Input type={'text'} title={'Address Line 2'} name={'AddressLine2'} value={this.state.newAccount.AddressLine2} errors={(this.state.newAccountErrors || {}).AddressLine2} handleChange={this.handleInput} />
                        <Input type={'text'} title={'Address Line 3'} name={'AddressLine3'} value={this.state.newAccount.AddressLine3} errors={(this.state.newAccountErrors || {}).AddressLine3} handleChange={this.handleInput} />
                        <Button class={'btn btn-primary'} title={'Create Account'} />
                        <NavLink className="btn btn-default" to="/accounts">Cancel</NavLink>
                    </form>
                </div>
            </div>
        );
    }
}

export default CreateAccountComponent;