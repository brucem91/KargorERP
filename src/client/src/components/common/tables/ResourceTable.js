import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSearch } from '@fortawesome/free-solid-svg-icons'
import axios from 'axios';
import { NavLink } from "react-router-dom";
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';

import '../../../../node_modules/react-bootstrap-table-next/dist/react-bootstrap-table2.css'
import '../../../../node_modules/react-bootstrap-table2-paginator/dist/react-bootstrap-table2-paginator.css'
import '../../../css/tables.css'

class ResourceTable extends Component {
    constructor(props) {
        super(props);

        let primaryKeyFormatter = (cell, row) => {
            let path = [
                window.location.hash.replace('#/', '/'),
                '/view?',
                this.props.primaryKey,
                '=',
                row[this.props.primaryKey]
            ].join('');

            return (<NavLink to={path}>{cell}</NavLink>);
        };

        let secondaryColumnFormatter = (cell, row, rowIndex, colIndex) => {
            return (colIndex > 0 ? 'column-optional' : '');
        }

        let secondaryHeaderFormatter = (col, colIndex) => {
            return (secondaryColumnFormatter(null, null, null, colIndex));
        }

        this.state = {
            ajaxUrl: this.props.ajaxUrl,
            primaryKey: this.props.primaryKey || '',
            columns: (this.props.columns || []).map((column, idx) => {
                if (column.sort !== false) column.sort = true;
                if (!column.formatter) column.formatter = primaryKeyFormatter;
                if (!column.classes && column.optional !== false) column.classes = secondaryColumnFormatter;
                if (!column.headerClasses && column.optional !== false) column.headerClasses = secondaryHeaderFormatter;
                return column;
            }),
            records: null,
            filteredRecords: [],
            searchTerms: ''
        };

        this.fetchRecords();
    }

    fetchRecords = () => {
        axios.get(this.state.ajaxUrl).then((results) => {
            this.setState({ records: results.data }, () => this.handleSearchTerms());
        }).catch((err) => {

        });
    }

    handleSearchTerms = (event) => {
        if (!event) event = { target: { value: '' } };

        let records = this.state.records;
        let props = this.state.columns.map((c) => { return c.dataField });

        let terms = event.target.value.toLowerCase();
        while (terms.indexOf('  ') > -1) terms.replace('  ', ' ');

        if (terms !== '') {
            records = records.filter((record) => {
                let textToSearch = [];
                for (var prop of props) {
                    if (typeof (record[prop]) === typeof ('')) {
                        textToSearch.push((record[prop] || '').trim());
                    }
                }

                textToSearch = textToSearch.join(' ').toLowerCase();
                for (var term of terms.split(' ')) {
                    if (textToSearch.indexOf(term) === -1) {
                        return false;
                    }
                }
                return true;
            });
        }

        this.setState({ searchTerms: event.target.value, filteredRecords: records });
    };

    render() {
        if (this.state.records === null) return (<div />); // don't render the page until we have some data.
        return (
            <div>
                <div className="row">
                    <div className="col-lg-4">
                        <div className="input-group mb-3">
                            <div className="input-group-prepend">
                                <span className="input-group-text" id="inputGroup-sizing-default"><FontAwesomeIcon icon={faSearch} /></span>
                            </div>
                            <input type="text" value={this.state.searchTerms} onChange={this.handleSearchTerms} className="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
                        </div>
                    </div>
                    <div className="col-md-8 text-right">
                        <NavLink className="btn btn-primary" to="/accounts/create">Create Account</NavLink>
                    </div>
                </div>
                <BootstrapTable keyField={this.state.primaryKey || 'id'} data={this.state.filteredRecords} columns={this.state.columns} pagination={paginationFactory({ sizePerPage: 25 })} bootstrap4={true} loading={true} />
            </div>
        );
    }
}

export default ResourceTable;