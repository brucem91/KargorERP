import React, { Component } from 'react';

const Button = (props) => {
    return (
        <button className={(props.class || 'btn btn-default')} style={props.style} onClick={props.action}>{props.title}</button>
    )
}

export default Button;