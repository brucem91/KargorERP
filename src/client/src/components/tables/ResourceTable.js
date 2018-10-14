import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSearch } from '@fortawesome/free-solid-svg-icons'
import axios from 'axios';
import { NavLink } from "react-router-dom";
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';

class ResourceTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            ajaxUrl: this.props.ajaxUrl,
            primaryKey: this.props.primaryKey || '',
            columns: (this.props.columns || []).map((column) => {
                if (column.sort !== false) column.sort = true;

                return column;
            }),
            records: [],
            filteredRecords: []
        };

        this.fetchRecords();
    }

    fetchRecords = () => {
        axios.get(this.state.ajaxUrl).then((results) => {
            this.setState({ records: results.data }, () => this.handleSearchTerms());
        }).catch((err) => {

        });
    }

    handleSearchTerms = (e) => {
        let records = this.state.records
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
                            <input type="text" value={this.state.searchTerms} onChange={this.handleSearchTerms} className="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
                        </div>
                    </div>
                    <div className="col-md-9 text-right">
                        <NavLink className="btn btn-primary" to="/accounts/create">Create Account</NavLink>
                    </div>
                </div>
                <BootstrapTable keyField={this.state.primaryKey || 'id'} data={this.state.records} columns={this.state.columns} pagination={paginationFactory()} />
            </div>
        );
    }
}

export default ResourceTable;