import React from 'react';
import ReactDOM from 'react-dom';
import IconMenu from 'material-ui/IconMenu';
import IconButton from 'material-ui/IconButton';
import Menu from 'material-ui/svg-icons/navigation/menu';
import MenuItem from 'material-ui/MenuItem';
import ArrowDropRight from 'material-ui/svg-icons/navigation-arrow-drop-right';


class MenuLeft extends React.Component {
    constructor(props) {
        super(props);
        this.handleGetAllBooksClick = this.handleGetAllBooksClick.bind(this);
        this.handleAddBookClick = this.handleAddBookClick.bind(this);
        this.handleGetBooksByAuthor=this.handleGetBooksByAuthor.bind(this);
        this.handleGetBooksByPublisher=this.handleGetBooksByPusblisher.bind(this);
    }
    handleGetAllBooksClick(event) {
        this.props.GetAllBooks(true);
    }
    handleGetBooksByAuthor(event){
        this.props.GetBooksByAuthor(true);
    }
    handleGetBooksByPusblisher(event){
        this.props.GetBooksByPublisher(true);
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
                <MenuItem 
                    primaryText="GetBooks"
                    rightIcon={<ArrowDropRight />}
                    menuItems={[
                        <MenuItem primaryText="AllBooks" onClick={this.handleGetAllBooksClick}></MenuItem>,
                        <MenuItem primaryText="By Title"></MenuItem>,
                        <MenuItem primaryText="By Author" onClick={this.handleGetBooksByAuthor}></MenuItem>,
                        <MenuItem primaryText="By Publisher" onClick={this.handleGetBooksByPublisher}></MenuItem>
                        
                    ]}
                />
                
                <MenuItem primaryText="AddBook" onClick={this.handleAddBookClick} />
            </IconMenu>
        );
    }
}

export default MenuLeft;