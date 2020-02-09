import React, { Component } from 'react';
export default class Clock extends React.Component {
    constructor(props) {
        super(props);
        this.state = { date: new Date() };
    }
    componentDidMount() {
        this.timerID = setInterval(
            () => this.UpdateTime(),
            1000
        );
    }
    ComponentwillUnMount() {
        clearInterval(this.timerID);
    }
    UpdateTime() {
        this.setState({
            date: new Date()
        });
    }
    render() {
        return<div>
                    <h1>Hi Joshua </h1>
                    <h2>{this.props.text}</h2>
                    <h2>{this.state.date.toLocaleTimeString()}</h2>
                    <button onClick={this.ComponentwillUnMount.bind(this)} > Stop </button>
                </div>;
    }
}