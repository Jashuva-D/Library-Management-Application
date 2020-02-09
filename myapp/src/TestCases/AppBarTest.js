import React from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider'
import AppBar from 'material-ui/AppBar';
import IconMenu from 'material-ui/IconMenu'
import IconButton from 'material-ui/IconButton';
import NavigationClose from 'material-ui/svg-icons/navigation/close';
import MoreVertIcon from 'material-ui/svg-icons/navigation/more-vert';
import Menu from 'material-ui/svg-icons/navigation/menu';
import MenuItem from 'material-ui/MenuItem'
import FlatButton from 'material-ui/FlatButton';

class AppBarExampleIconButton extends React.Component {
    constructor(props) {
        super(props);
        this.state = { isLoaded: true, error: null, Books: [], status: ""};
        this.handleGetBooks = this.handleGetBooks.bind(this);
        this.handleAddBook = this.handleAddBook.bind(this);
        
    }
    handleGetBooks(event) {
        alert('GetBooks Clicked');
        fetch("http://localhost:7070/api/books")
            .then(res => res.json())
            .then(
            (result) => {
                this.setState({
                    status: "GetBooks",
                    isLoaded: true,
                    Books: result
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
    handleAddBook(event) {
        alert("AddBook Clicked");
        this.setState({ status: "AddBook" });
    }
    render() {
        if (this.state.status === "") {
            return (
                <div>
                    <MuiThemeProvider>
                        <AppBar
                            title={<span>Library Management System</span>}
                            iconElementLeft={<MenuLeft GetBooks={this.handleGetBooks} AddBook={this.handleAddBook} />}
                            iconElementRight={<MenuRight />}
                        />
                    </MuiThemeProvider>
                </div>
            );
        }
        else if (this.state.status === "GetBooks") {
            if (this.state.error) {
                return <div>Error</div>
            }
            else if (!this.state.isLoaded) {
                return <div>Loading...</div>
            }
            return (
                <div>
                    <MuiThemeProvider>
                        <AppBar
                            title={<span>Library Management System</span>}
                            iconElementLeft={<MenuLeft GetBooks={this.handleGetBooks} AddBook={this.handleAddBook} />}
                            iconElementRight={<MenuRight />}
                        />
                    </MuiThemeProvider>
                    <table className='table table-bordered table-striped'>
                        <thead>
                            <tr><th>Id</th><th>Title</th><th>Publisher</th><th>Author</th><th>Edition</th><th>Price</th><th>Copies</th></tr>
                        </thead>
                        <BooksList data={this.state.Books} />

                    </table>
                </div>
            );
        }
        else if (this.state.status === "AddBook") {
            return (
                <div>
                    <MuiThemeProvider>
                        <AppBar
                            title={<span>Library Management System</span>}
                            iconElementLeft={<MenuLeft GetBooks={this.handleGetBooks} AddBook={this.handelAddBook} />}
                            iconElementRight={<MenuRight />}
                        />
                    </MuiThemeProvider>
                    <h1>Adding the Book</h1>
                    
                </div>
            );
        }  
        
    }
}

class BooksList extends React.Component {
    render() {
        return <tbody>{this.props.data.map(book => <TableRow data={book} />)}</tbody>
    }
}
class TableRow extends React.Component {
    render() {
        return <tr>
            <td>{this.props.data.ID}</td>
            <td>{this.props.data.Title}</td>
            <td>{this.props.data.Publisher.Name}</td>
            <td>{this.props.data.Authors[0].Name}</td>
            <td>{this.props.data.Repositories[0].Edition}</td>
            <td>{this.props.data.Repositories[0].Price}</td>
            <td>{this.props.data.Repositories[0].NumberOfCopies}</td>
        </tr>

    }
}
class MenuLeft extends React.Component {
    constructor(props) {
        super(props);
        this.handleGetBookClick = this.handleGetBookClick.bind(this);
        this.handleAddBookClick = this.handleAddBookClick.bind(this);
    }
    handleGetBookClick(event) {
        this.props.GetBooks(true);
    }
    handleAddBookClick(event) {
        this.props.AddBook(true);
    }
    render() {
        return (
            <IconMenu
                iconButtonElement={
                    <IconButton><Menu /></IconButton>
                }
            >

                <MenuItem primaryText="GetBooks" onClick={this.handleGetBookClick}></MenuItem>
                <MenuItem primaryText="AddBook" onClick={this.handleAddBookClick} />
            </IconMenu>
        );
    }
}
const MenuRight = (props) => (
    <IconMenu
        {...props}
        iconButtonElement={
            <IconButton><MoreVertIcon /></IconButton>
        }
    >
        <MenuItem primaryText="AboutUs"></MenuItem>
        <MenuItem primaryText="ContactUs" />
    </IconMenu>
)



export default AppBarExampleIconButton;