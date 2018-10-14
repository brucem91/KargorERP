import React from 'react';
import ResourceTable from '../components/tables/ResourceTable';
import { NavLink } from "react-router-dom";

const ajaxUrl = '/api/accounts';
const primaryKey = 'AccountId';
const columns = [
    { dataField: 'Name', text: 'Account' },
    { dataField: 'AccountNumber', text: 'Account Number' },
    { dataField: 'AddressLine1', text: 'Address Line 1' }
];

export default () => <ResourceTable primaryKey={primaryKey} ajaxUrl={ajaxUrl} columns={columns} />