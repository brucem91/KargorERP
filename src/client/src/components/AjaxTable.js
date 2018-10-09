import React, { Component } from 'react';

class AjaxTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            pageSize: Number(props.pageSize || 25),
            searchable: props.searchable || true,
            ajaxUrl: props.ajaxUrl,
            columns: [],
            records: [],
            filteredRecords: [],
            currentPage: 0,
            maxResponseRecordLimit: 5000
        };
    }
}

export default AjaxTable;