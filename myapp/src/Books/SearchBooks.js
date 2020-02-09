import React from 'react';
import ReactDOM from 'react-dom';
import AutoCompleteSearch from './AutoComplete/AutoCompleteSearch';

class SearchBooks extends React.Component{
    constructor(props){
        super(props);
        this.handleGet=this.handleGet.bind(this);
        this.handleSearchBox=this.handleSearchBox.bind(this);
    }
    handleSearchBox(inputvalue){
        this.props.SearchInput(inputvalue);
    }
    handleGet(event){
        this.props.GetClick(true);
    }
    render(){
        return (
            <div className="form-group">
                    <label className="col-xs-2 col-xs-offset-1 control-label">{this.props.label}</label>
                    <div className="col-xs-5">
                        <div id="inputDataDiv" className="input-group">
                            <AutoCompleteSearch url={this.props.url} autocompletevalue={this.handleSearchBox} />
                        </div>
                    </div>
                    <div className="col-xs-1">
                        <input id='GetButton' type="submit" autocompletevalue="Get" className="btn btn-primary" onClick={this.handleGet} />
                    </div>
            </div>

            
        )
    }
}

export default SearchBooks;