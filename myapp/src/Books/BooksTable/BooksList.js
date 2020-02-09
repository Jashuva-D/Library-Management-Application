import React from 'react';
import ReactDOM from 'react-dom';
import TableRow from './TableRow';


class BooksList extends React.Component {
    render() {
        return <tbody>{this.props.data.map((book,index) => <TableRow key={index} data={book} />)}</tbody>
    }
}

export default BooksList;