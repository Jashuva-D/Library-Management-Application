import React from 'react';
import ReactDOM from 'react-dom';
import AppBarIcon from '../AppBar/AppBarIcon';
import BooksTable from '../Books/BooksTable/BooksTable';
import BookForm from '../Books/BookForm/BookForm';
import SearchBooks from '../Books/SearchBooks';

class LibraryAplicaion extends React.Component{
    constructor(props) {
        super(props);
        this.state = { isLoaded: true, error: null, Books: [], status: "",searchInput: ""};
        this.handleGetAllBooks = this.handleGetAllBooks.bind(this);
        this.handleAddBook = this.handleAddBook.bind(this);
        this.handleGetBooksByAuthor=this.handleGetBooksByAuthor.bind(this);
        this.handleGetBooksByPublisher=this.handleGetBooksByPublisher.bind(this);
        this.handleSearchInput=this.handleSearchInput.bind(this);
        this.handleSearchGet=this.handleSearchGet.bind(this);
        this.FetchData=this.FetchData.bind(this);
        
    }
    FetchData(url){
        fetch(url)
            .then(res => res.json())
            .then(
            (result) => {
                this.setState({
                    isLoaded: true,
                    Books: result
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
    handleSearchInput(searchInputValue){
        this.setState({searchInput: searchInputValue})
    }
    handleSearchGet(event){
        let url="";
        if(this.state.status==="GetBooksByAuthor"){
            url="http://localhost:7070/api/books/author/"+this.state.searchInput;
        }
        else if(this.state.status==="GetBooksByPublisher"){
            url="http://localhost:7070/api/books/publisher/"+this.state.searchInput;
        }
        this.FetchData(url);
    }
    handleGetAllBooks(event) {
        alert('GetBooks Clicked');
        this.setState({status:"GetAllBooks"});
        this.FetchData("http://localhost:7070/api/books");
    }
    handleGetBooksByAuthor(event){
        this.setState({status:"GetBooksByAuthor"});
    }
    handleGetBooksByPublisher(event){
        this.setState({status:"GetBooksByPublisher"});
    }
    handleAddBook(event) {
        alert("AddBook Clicked");
        this.setState({ status: "AddBook" });
    }

    render(){
        if(this.state.status===""){
            return (
                <AppBarIcon 
                    handleGetAllBooks={this.handleGetAllBooks} 
                    handleAddBook={this.handleAddBook} 
                    handleGetBooksByAuthor={this.handleGetBooksByAuthor}
                    handleGetBooksByPublisher={this.handleGetBooksByPublisher}
                />
            )
        }
        else if(this.state.status==="GetAllBooks"){
            return (
                <div>
                <AppBarIcon 
                    handleGetAllBooks={this.handleGetAllBooks} 
                    handleAddBook={this.handleAddBook} 
                    handleGetBooksByAuthor={this.handleGetBooksByAuthor}
                    handleGetBooksByPublisher={this.handleGetBooksByPublisher}
                />
                <br /><br />
                <BooksTable data={this.state.Books} />
                </div>
            )
        }
        else if(this.state.status==="GetBooksByAuthor"){
            return (
                <div>
                    <AppBarIcon 
                        handleGetAllBooks={this.handleGetAllBooks} 
                        handleAddBook={this.handleAddBook}
                        handleGetBooksByAuthor={this.handleGetBooksByAuthor}
                        handleGetBooksByPublisher={this.handleGetBooksByPublisher}
                    /><br /><br />
                    <SearchBooks label="Enter Author ID" url="http://localhost:7070/api/authors" SearchInput={this.handleSearchInput} GetClick={this.handleSearchGet}/>
                    <br /><br />
                    <BooksTable data={this.state.Books} />
                </div>
            )
        }
        else if(this.state.status==="GetBooksByPublisher"){
            return (
                <div>
                    <AppBarIcon 
                        handleGetAllBooks={this.handleGetAllBooks} 
                        handleAddBook={this.handleAddBook}
                        handleGetBooksByAuthor={this.handleGetBooksByAuthor}
                        handleGetBooksByPublisher={this.handleGetBooksByPublisher}
                    /><br /><br />
                    <SearchBooks label="Enter Publisher ID" url="http://localhost:7070/api/publishers" SearchInput={this.handleSearchInput} GetClick={this.handleSearchGet}/>
                    <br /><br />
                    <BooksTable data={this.state.Books} />
                </div>
            )
        }
        else if(this.state.status==="AddBook"){
            return (
                <div>
                    <AppBarIcon 
                        handleGetAllBooks={this.handleGetAllBooks} 
                        handleAddBook={this.handleAddBook}
                        handleGetBooksByAuthor={this.handleGetBooksByAuthor}
                        handleGetBooksByPublisher={this.handleGetBooksByPublisher}
                    />
                    <BookForm />
                </div>
            )
        }
        
    }
}


export default LibraryAplicaion;