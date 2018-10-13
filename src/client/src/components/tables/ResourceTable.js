import React, { Component } from 'react';
import BasicTable from './BasicTable';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSearch } from '@fortawesome/free-solid-svg-icons'
import axios from 'axios';
import { NavLink } from "react-router-dom";

class ResourceTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            pageSize: Number(props.pageSize || 50),
            ajaxUrl: props.ajaxUrl,
            searchable: props.searchable || true,
            searchTerms: '',
            columns: (props.columns || []),
            records: [],
            filteredRecords: [],
            maxResponseRecordLimit: 5000,
            currentPage: 0,
            numberOfpages: 1
        };

        this.fetchRecords();
    }

    fetchRecords = () => {
        axios.get(this.state.ajaxUrl).then((results) => {
            this.setState({ records: results.data }, () => this.handleSetPage(0));
        }).catch((err) => {

        });
    }

    handleSearchTerms = (e) => {
        let value = e.target.value;

        while (value.indexOf('  ') > -1) {
            value = value.replace('  ', ' ');
        }

        this.setState({ searchTerms: value }, () => this.handleSetPage(0));
    };

    handleSetPage = (page) => {
        let chunks = [];
        let records = this.state.records;

        // if (this.state.searchTerms !== '') {
        //     records = records.filter((record) => {

        //         var textToSearch = '';

        //         for (var prop of this.state.columns) {
        //             if (record.hasOwnProperty(prop['data'])) {
        //                 if (typeof (record[prop['data']]) === typeof ('')) {
        //                     textToSearch += record[prop['data']];
        //                 }
        //             }
        //         }

        //         while (textToSearch.indexOf('  ') > -1) {
        //             textToSearch.replace('  ', ' ');
        //         }

        //         for (var term of this.state.searchTerms.split(' ')) {
        //             if (textToSearch.indexOf(term) === -1) {
        //                 return false;
        //             }
        //         }

        //         return true;
        //     });
        // }

        while (records.length) {
            chunks.push(records.splice(0, this.state.pageSize));
        }

        this.setState({ filteredRecords: chunks[page] || [], numberOfpages: chunks.length, currentPage: page });
    };

    getPager = () => {
        if (this.state.numberOfpages < 2) {
            return (<div />);
        };

        let pages = [];

        for (var i = 0; i < this.state.numberOfpages; i++) {
            let className = 'page-item';

            if (i === this.state.currentPage) {
                className = 'page-item active';
            }

            // pages.push(<li className={className}><button className="page-link" onClick={this.handleSetPage(i)}>{i + 1}</button></li>)
        }

        return (
            <nav aria-label="Page Navigation">
                <ul className="pagination">
                    {pages}
                </ul>
            </nav>
        )
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
                <BasicTable columns={this.state.columns} records={this.state.filteredRecords} />
                {this.getPager()}
            </div>
        );
    }
}

export default ResourceTable;