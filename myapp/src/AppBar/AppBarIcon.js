import React from 'react';
import ReactDOM from 'react-dom';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider'
import AppBar from 'material-ui/AppBar';
import MenuLeft from './MenuLeft';
import MenuRight from './MenuRight';
import BooksTable from '../Books/BooksTable/BooksTable';



class AppBarIcon extends React.Component {
    constructor(props) {
        super(props);
        this.handleGetAllBooks = this.handleGetAllBooks.bind(this);
        this.handleGetBooksByAuthor=this.handleGetBooksByAuthor.bind(this);
        this.handleGetBooksByPublisher=this.handleGetBooksByPublisher.bind(this);
        this.handleAddBook = this.handleAddBook.bind(this);
        
    }
    handleGetAllBooks(event){
        this.props.handleGetAllBooks(true);
    }
    handleAddBook(event){
        this.props.handleAddBook(true);
    }
    handleGetBooksByAuthor(event){
        this.props.handleGetBooksByAuthor(true);
    }
    handleGetBooksByPublisher(event){
        this.props.handleGetBooksByPublisher(true);
    }
    render(){
        return (<MuiThemeProvider>
            <AppBar 
                title={<span>Library Management System </span>}
                iconElementLeft={<MenuLeft 
                                    GetAllBooks={this.handleGetAllBooks} 
                                    AddBook={this.handleAddBook} 
                                    GetBooksByPublisher={this.handleGetBooksByPublisher}
                                    GetBooksByAuthor={this.handleGetBooksByAuthor}
                                  />}
                iconElementRight={<MenuRight />}
            />
        </MuiThemeProvider>);
    }
  
}

export default AppBarIcon;