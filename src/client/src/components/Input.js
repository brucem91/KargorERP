import React, { Component } from 'react';

const InputError = (props) => {
    if (props.errors.length === 1) {
        return (props.errors[0]);
    }

    return (
        <ul>
            {props.errors.map((error) => {
                return (<li>{error}</li>);
            })}
        </ul>
    );
}

const InputErrorWrapper = (props) => {
    if ((props.errors || []).length === 0) {
        return (<div />)
    }

    return (
        <div className="invalid-feedback">
            <InputError errors={props.errors} />
        </div>
    )
}

const getClassName = (props) => {
    let className = 'form-control';

    if ((props.errors || []).length > 0) {
        className += ' is-invalid';
    }

    return className;
}

const Input = (props) => {
    return (
        <div className="form-group">
            <label htmlFor={props.name} className="form-label">{props.title}</label>
            <input className={getClassName(props)} id={props.name} name={props.name} type={props.type} value={props.value} onChange={props.handleChange} placeholder={props.placeholder} />
            <InputErrorWrapper errors={props.errors} />
        </div>
    )
};

export default Input;