import React, { Component } from 'react';

const scaleState = {
    c: 'Celcius',
    f: 'Fahrenheit'
}

function tryConvert(temperature, convert) {
    const input = parseFloat(temperature);

    if (Number.isNaN(input)) {
        return "";
    }
    const output = convert(input);
    const rounded = Math.round(output * 1000) / 1000;
    return rounded;
}

function toCelcius(fahrenheit) {
    return (fahrenheit - 32) * 9 / 5;
}
function toFahrenheit(celcius) {
    return (celcius * 9 / 5) + 32;
}

class TempInput extends React.Component {

    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e) {
        this.props.onTemperatureChange(e.target.value);
    }

    render() {
        const scale = this.props.scale;
        const temperature = this.props.temperature;
        return <div>
                    <fieldset>
                        <legend>Enter temperature in {scaleState[scale]}</legend>
                        <input type="text" value={temperature}
                            onChange={this.handleChange}/>
                    </fieldset>
                </div>
    }
}

export default class Calculator extends React.Component {
    constructor(props) {
        super(props);
        this.state = { scale: "", temperature: "" };
        this.handleCelciusChange = this.handleCelciusChange.bind(this);
        this.handleFahrenheitChange = this.handleFahrenheitChange.bind(this);
        
    }


    handleCelciusChange(temperature) {
        this.setState({ scale: "c", temperature });
    }

    handleFahrenheitChange(temperature) {
        this.setState({ scale: "f",temperature });
    }

    render() {
        const scale = this.state.scale;
        const temperature = this.state.temperature;
        const celcius = scale === "c" ? tryConvert(temperature, toCelcius) : temperature;
        const farenheit = scale === "f" ? tryConvert(temperature, toFahrenheit) : temperature;
        return <div>
                    <TempInput
                        scale="c"
                        temperature={celcius}
                        onTemperatureChange={this.handleCelciusChange} />
                    <TempInput
                        scale="f"
                        temperature={farenheit}
                        onTemperatureChange={this.handleFahrenheitChange} />
                </div>;
    }
}




