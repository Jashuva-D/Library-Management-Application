import React from 'react';
import ReactDOM from 'react-dom';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider'
import AutoComplete from 'material-ui/AutoComplete';

class AutoCompleteExample extends React.Component{
    constructor(props){
        super(props);
        this.state={dataSource:[]};
        this.handleChange=this.handleChange.bind(this);
    }
    handleChange(value){
        this.props.autocompletevalue(value);
    }
    componentDidMount(){
        fetch(this.props.url)
            .then(res => res.json())
            .then(
            (result) => {
                var data=[];
                result.map(function(author){
                    data.push(author.Name);
                })
                this.setState({
                    dataSource: data
                });
            },

            (error) => {
                alert("Error");
                this.setState({
                    isLoaded: true,
                    error
                });
            }
            )
    }
    render() {
        return (
            <div>
                <MuiThemeProvider>
                <AutoComplete
                    dataSource={this.state.dataSource}
                    fullWidth={true}
                    filter={AutoComplete.caseInsensitiveFilter}
                    onUpdateInput={this.handleChange}
                />
                </MuiThemeProvider>
            </div>
        )
    }
}

export default AutoCompleteExample;