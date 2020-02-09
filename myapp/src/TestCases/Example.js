import React from 'react';
import ReactDOM from 'react-dom';

class Example extends React.Component{
    constructor(props){
        super(props);
        alert("in constructor");
    }
    componentDidMount(){
        alert("in Component Did mount");
    }
    componentWillMount(){
        alert("in component will mount")
    }
    componentWillUnmount(){
        alert("In component will Unmount");
    }
    render(){
        alert("in render");
        return (
            <div>
                Hellooooo....!
            </div>
        )
    }
}

export default Example;