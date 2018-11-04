import React from 'react';

export default (props) => {
    return (
        <div className="form-group">
            <label className="col-md-2" htmlFor={props.name} className="form-label">{props.title}</label>
            <div className="col-md-4" id={props.name}>{props.value}</div>
        </div>
    )
}