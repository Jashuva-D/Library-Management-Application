import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import AutoCompleteExample from '../AutoComplete/AutoCompleteExample';

class BookForm extends React.Component {
    constructor(props){
        super(props);
        this.state = {Title:"",Genre:"",Authors:[],Publisher: {Name:"", Contact: 234233244},Repositories:[{Edition:"",Price:"",NumberOfCopies:""}]};
        this.handleTitle=this.handleTitleInput.bind(this);
        this.handleGenre=this.handleGenreInput.bind(this);
        this.handleAuthor=this.handleAuthorsInput.bind(this);
        this.handlePublisher=this.handlePublisherInput.bind(this);
        this.handleEdition=this.handleEditionInput.bind(this);
        this.handlePrice=this.handlePriceInput.bind(this);
        this.handleNumberOfCopies=this.handleNumberOfCopiesInput.bind(this);
        this.handleSaveButton=this.handleSaveButton.bind(this);
    }
    handleTitleInput(event){
        this.setState({Title:event.target.value});
    }
    handleGenreInput(event){
        this.setState({Genre: event.target.value});
    }
    handleAuthorsInput(value){
        this.setState({Authors:[{Name:value}]});
    }
    handlePublisherInput(value){
        this.setState({Publisher:{Name: value,Contact: 2323552324}});
    }
    handleEditionInput(event){
        this.setState({Repositories:[{Edition:event.target.value,Price: this.state.Repositories[0].Price,NumberOfCopies:this.state.Repositories[0].NumberOfCopies}]});
    }
    handlePriceInput(event){
        this.setState({Repositories:[{Price:event.target.value,Edition: this.state.Repositories[0].Edition,NumberOfCopies:this.state.Repositories[0].NumberOfCopies}]});
    }
    handleNumberOfCopiesInput(event){
        this.setState({Repositories:[{NumberOfCopies:event.target.value,Price: this.state.Repositories[0].Price,Edition:this.state.Repositories[0].Edition}]});
    }
    handleSaveButton(event){
        axios.post('http://localhost:7070/api/books', this.state)
          .then(function (response) {
            alert("Book Saved Successfully ");
          })
          .catch(function (error) {
            alert(error);
          });
    }
    render() {
        return <div style={{backgroundColor: 'aqua'}}>
        <center><h1>Adding New Book</h1>
        <h3>Enter Book Details</h3><br />
        </center>
            <div>
                <form className='form-horizontal'>
                    <div className="form-group">
                        <div className='col-xs-2 col-xs-offset-2'>
                            <label>Enter Title</label>
                        </div>
                        <div className=" col-xs-6 input-group">
                            <span className="input-group-addon"><span className="glyphicon glyphicon-book"></span></span>
                            <input type="text" className="form-control" onChange={this.handleTitle} />
                        </div>
                    </div>
                    <div className="form-group">
                        <div className='col-xs-2 col-xs-offset-2'>
                            <label>Enter Genre</label>
                        </div>
                        <div className=" col-xs-6 input-group">
                            <span className="input-group-addon"><span className="glyphicon glyphicon-chevron-down"></span></span>
                            <select id='selectGenre' name="genre"className="form-control" onChange={this.handleGenre}>
                                    <option disabled>--Select Genre--</option>
                                    <option value="Science" >Science</option>
                                    <option value="SoftwareTechnology">SoftwareTechnology</option>
                                    <option value="Romance">Romance</option>
                                    <option value="Literature">Literature</option>
                                    <option value="Biography">Biography</option>
                                    <option value="General">General</option>
                            </select>
                        </div>
                    </div>
                    <div className="form-group">
                        <div className='col-xs-2 col-xs-offset-2'>
                            <label>Enter Authors</label>
                        </div>
                        <div className=" col-xs-6 input-group">
                        <AutoCompleteExample url="http://localhost:7070/api/authors" autocompletevalue={this.handleAuthor}/>
                        </div>
                    </div>
                    <div className="form-group">
                        <div className='col-xs-2 col-xs-offset-2'>
                            <label>Enter Publisher</label>
                        </div>
                        <div className=" col-xs-6 input-group">
                        <AutoCompleteExample url="http://localhost:7070/api/publishers" autocompletevalue={this.handlePublisher}/>
                        </div>
                    </div>
                    <div className="form-group">
                        <div className='col-xs-2 col-xs-offset-2'>
                            <label>Enter Edition</label>
                        </div>
                        <div className=" col-xs-6 input-group">
                            <input type='text' className="form-control" onChange={this.handleEdition}></input>
                        </div>
                    </div>
                    <div className="form-group">
                        <div className='col-xs-2 col-xs-offset-2'>
                            <label>Enter Price</label>
                        </div>
                        <div className=" col-xs-6 input-group">
                            <input type='text' className="form-control" onChange={this.handlePrice}></input>
                        </div>
                    </div>
                    <div className="form-group">
                        <div className='col-xs-2 col-xs-offset-2'>
                            <label>Enter NumberOfCopies</label>
                        </div>
                        <div className=" col-xs-6 input-group">
                           <input type='number' className="form-control" onChange={this.handleNumberOfCopies}></input>
                        </div>
                    </div>
                    <div className="form-group">
                            <div className="col-xs-6 col-xs-offset-4">
                                <input type="button" onClick={this.handleSaveButton} value="Save" className="btn btn-success" />
                                <input type="reset" value="Reset" className="btn btn-warning" />
                            </div>
                        </div>
                </form>
            </div>
        </div>

    }
}

export default BookForm;