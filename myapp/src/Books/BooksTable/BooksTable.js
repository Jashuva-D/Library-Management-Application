import React from 'react';
import ReactDOM from 'react-dom';
import BooksList from './BooksList';

class BooksTable extends React.Component{
    render(){
        return (
            <table className='table table-bordered table-striped'>
                        <thead style={{backgroundColor : "aqua"}}>
                            <tr><th>Id</th><th>Title</th><th>Publisher</th><th>Author</th><th>Edition</th><th>Price</th><th>Copies</th></tr>
                        </thead>
                        <BooksList data={this.props.data} />

            </table>
        );
    }
}

export default BooksTable;