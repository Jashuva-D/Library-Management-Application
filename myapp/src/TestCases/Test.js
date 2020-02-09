import React from 'react';
import ReactDOM from 'react-dom';
import registerServiceWorker from './registerServiceWorker';


class Test extends React.Component {
    render() {
        return <div><h1>Testing new javascript file</h1></div>;
    }
}

ReactDOM.render(<Test />, document.getElementById('root'));

class MyComponent extends React.Component {
    render() {
        return React.createElement("div", null, React.createElement("h1", null, "GettingStarted"));
    }
}
class Header extends React.Component {
    render() {
        var myStyle = {
            fontSize: 100,
            color: '#FF0000'
        }
        return <div><h1 style={myStyle}>Header Area</h1></div>;

    }
}