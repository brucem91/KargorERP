import React, { Component } from 'react';
// import { BrowserHistory } from 'react-router-dom';
import InputComponent from '../components/InputComponent';
import axios from 'axios';

class CreateAccountComponent extends Component {

    constructor(props) {
        super(props);
    }

    // handleName = (event) => {
    //     this.setState((state) => 
    // }

    handleFormSubmit = (event) => {
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleFormSubmit}>
                <InputComponent type={'text'} title={'Account Name'} name={'Name'} value={this.state.newAccount.Name} handleChange={this.handleName} />
                {/* <div className="form-group">
                    <label htmlFor="Name">Name</label>
                    <input type="text" className="form-control" ref={(input) => this.input = input}></input>
                </div> */}
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        );
    }
}

export default CreateAccountComponent;