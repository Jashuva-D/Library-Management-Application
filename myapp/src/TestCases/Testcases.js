import React from 'react';
import ReactDOM from 'react-dom';




class Books extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoaded: false,
            error: null,
            books: []
        }
    }
    componentDidMount() {
        fetch("http://localhost:7070/api/books")
            .then(res => res.json())
            .then(
            (result) => {
                this.setState({
                    isLoaded: true,
                    books: result
                });
            },
 
            (error) => {
                this.setState({
                    isLoaded: true,
                    error
                });
            }
            )
    }

    render() {
        const { error, isLoaded, books } = this.state;
        if (error) {
            return <div>Error</div>;
        } else if (!isLoaded) {
            return <div>Loading....</div>
        } else {

            return (
                <BooksList data={books} />
                )

           /* return (
               <div><h1>Books</h1>
                   <table className="table">
                      <tbody>
                            <tr>
                                <td>{books.map(book => <Book key={book.ID} data={book} />)}</td>
                            </tr>
                            {books.map(book => <TableRow key={book.ID} data = { book } />)}
                        </tbody>
                    </table>
                </div>
            );*/
        }      
    }
}
class LibraryHeader extends React.Component {
    render() {
        return <div className="navbar navbar-inverse navbar-static-top">
                <div className="container">
                    <h1>LibraryManageSystem</h1>
                    <button className="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                        <span className="icon-bar"></span>
                        <span className="icon-bar"></span>
                        <span className="icon-bar"></span>
                    </button>
                    <div className="collapse navbar-collapse navHeaderCollapse">
                        <ul className="nav navbar-nav">
                            <li className="nav active"><a href="#">Home</a></li>
                            <li className="nav"><a href="#">Book</a></li>
                            <li className="nav"><a href="#">Author</a></li>
                            <li className="nav"><a href="#">Publisher</a></li>
                        </ul>
                        <ul className="nav navbar-nav navbar-right">
                            <li className="nav"><a href="#">About</a></li>
                            <li className="nav"><a href="#">Contact</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        
    }
}
class TableRow extends React.Component {
    render() {
        return <tr>
                <td>{this.props.data.ID}</td>
                <td>{this.props.data.Title}</td>
                <td>{this.props.data.Genre}</td>
                <td>{this.props.data.Publisher.Name}</td>
              </tr>
            
    }
}
class Book extends React.Component {
    render() {
        var divStyle = {
            display: "inline-block",
            marginLeft: 50
        }
        var headingStyle = {
            color: "red",
            marginTop:20,
            fontSize: 20
        }
        var dataStyle = {
            display: "inline-block",
            margingLeft: 10,
            fontSize: 15,
            color: "green"
        }
        
        return <div>
                        <img src='http://placehold.it/75' height="250px" />
                        <div style={divStyle}>
                            <p style={headingStyle}>ID : <span style={dataStyle} > {this.props.data.ID}</span> </p>
                            <p style={headingStyle}>Title : <span style={dataStyle} > {this.props.data.Title}</span> </p>
                            <p style={headingStyle}>Genre : <span style={dataStyle} > {this.props.data.Genre}</span> </p>
                            <p style={headingStyle}>Authors:<span style={dataStyle} > <Authors data={this.props.data.Authors} /></span></p>
                            <p style={headingStyle}>Publisher:<span style={dataStyle}>{this.props.data.Publisher.Name}</span></p>
                      
                          </div>
                     </div>
    }
}
class Authors extends React.Component {
    render() {
        return (
            <span>
                {this.props.data.map(author => <span>{ author.Name },</span>)}
            </span>
            )
    }
}
class BooksList extends React.Component {
    render() {
        return <div>
            {this.props.data.map(book => <Book data={book} />)};
            </div>;
    }
}