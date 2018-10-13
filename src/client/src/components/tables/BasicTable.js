import React, { Component } from 'react';

class BasicTable extends Component {
    constructor(props) {
        super(props);

        this.state = {
            columns: (props.columns || []),
            records: (props.records || [])
        };
    }

    getHeaderColumns = () => {
        return this.state.columns.map((column) => { return (<th>{column.label}</th>) });
    };

    getBodyRows = () => {
        if (this.state.records.length === 0) return (<tr><td>No Records Found</td></tr>);

        return this.state.records.map((record) => {
            let columns = this.columns.map((column) => {
                if (typeof (this.column.data) === typeof ('')) return (<td>{record[this.column.data]}</td>);

                return '';
            });

            return <tr>(columns)</tr>
        });
    };

    render() {
        return (
            <table className="table">
                <thead>
                    <tr>{this.getHeaderColumns()}</tr>
                </thead>
                <tbody>
                    {this.getBodyRows()}
                </tbody>
            </table>
        )
    }
}

export default BasicTable;