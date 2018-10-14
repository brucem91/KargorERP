import React, { Component } from 'react';

class BasicTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            headers: this.getHeaderColumns(props.columns || []),
            rows: this.getBodyRows(props.columns || [], props.records || []),
            primaryKey: (props.primaryKey || '')
        };
    }

    getHeaderColumns = (columns) => {
        return columns.map((column) => { return (<th key={column.label}>{column.label}</th>) });
    };

    getBodyRows = (columns, records) => {
        if (records.length === 0) return (<tr><td>No Records Found</td></tr>);

        return records.map((record) => {
            let _columns = this.columns.map((column) => {
                if (typeof (this.column.data) === typeof ('')) return (<td>{record[this.column.data]}</td>);

                return '';
            });

            return <tr key={record[this.state.primaryKey]}>(_columns)</tr>
        });
    };

    render() {
        return (
            <table className="table">
                <thead>
                    <tr>{this.state.headers}</tr>
                </thead>
                <tbody>
                    {this.state.rows}
                </tbody>
            </table>
        )
    }
}

export default BasicTable;