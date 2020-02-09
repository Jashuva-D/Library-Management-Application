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
        alert(this.props.url);
        fetch(this.props.url)
            .then(res => res.json())
            .then(
            (result) => {
                var data=[];
                result.map(function(item){
                    var dataItem={textKey: item.ID, valueKey: item.Name}
                    data.push(dataItem);
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
        const dataSourceConfig = {
            text: 'textKey',
            value: 'valueKey',
          };
        return (
            <div>
                <MuiThemeProvider>
                <AutoComplete
                    dataSource={this.state.dataSource}
                    fullWidth={true}
                    filter={AutoComplete.caseInsensitiveFilter}
                    onUpdateInput={this.handleChange}
                    dataSourceConfig={dataSourceConfig}
                />
                </MuiThemeProvider>
            </div>
        )
    }
}

export default AutoCompleteExample;