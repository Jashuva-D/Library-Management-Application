import React from 'react';


export default class ReactForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: "",
            taValue: "Hello",
            selectValue: ""
        }
        this.handleNameChange = this.handleNameChange.bind(this);
    }
    handleNameChange(event) {
        this.setState({ name: event.target.value.toUpperCase() })
    }
    render() {
        return <form>
   
            <div>
                <label>Enter Name</label>
                <input type="text" value={this.state.name} onChange={this.handleNameChange} />
            </div>
            <div>
                <label>Enter your message</label>
                <textarea></textarea>
            </div>
            <div>
            </div>
            </form>
    }
}