import React, { Component } from 'react';

class AjaxTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            pageSize: Number(props.pageSize || 25),
            ajaxUrl: props.ajaxUrl,
            searchable: props.searchable || true,
            searchTerms: '',
            columns: [],
            records: [],
            filteredRecords: [],
            currentPage: 0,
            maxResponseRecordLimit: 5000
        };
    }

    handleSearchTerms = (e) => {
        this.setState({ searchTerms: e.target.value }, () => this.renderTable());
    };

    renderTable = () => {

    };
}

export default AjaxTable;