import React from 'react';
import ReactDOM from 'react-dom';

class TableRow extends React.Component {
    render() {
        return <tr>
            <td>{this.props.data.ID}</td>
            <td>{this.props.data.Title}</td>
            <td>{this.props.data.Publisher.Name}</td>
            <td><Authors data={this.props.data.Authors} /></td>
            <td>{this.props.data.Repositories[0].Edition} </td>
            <td>{this.props.data.Repositories[0].Price}</td>
            <td>{this.props.data.Repositories[0].NumberOfCopies}</td>
        </tr>

    }
}
class Authors extends React.Component{
    render(){
        return (
            <span>
                {this.props.data.map(
                    function(author,index){
                        if(index>0){
                            return <span key={index}>,<br />{author.Name}</span>
                        }
                        else{
                            return <span key={index}>{author.Name}</span>
                        }
                        
                })}
            </span>
        )
    }
}
export default TableRow;