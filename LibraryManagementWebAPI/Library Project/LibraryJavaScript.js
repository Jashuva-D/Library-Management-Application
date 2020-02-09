//Function To add the list of books to the table
            function addBooks(books){
                $.each(books,function(index,book){
                    addBookRow(book);
                })
            }
            
            //Function to add the book record to the table
            function addBookRow(book){
               
               var rowspan=book.Repositories.length;
               
               var row="";
                
                    row += "<tr>";
                    row += "<td rowspan='"+rowspan+"'>"+book.ID+"</td>";
                    row += "<td rowspan='"+rowspan+"'>"+book.Title+"</td>";
                    row += "<td rowspan='"+rowspan+"'>"+book.Genre+"</td>";
                    row += "<td rowspan='"+rowspan+"'>"+returnAuthors(book.Authors)+"</td>";
                    row += "<td rowspan='"+rowspan+"'>"+book.Publisher.Name+"</td>";
                    row += returnRecords(book.ID,book.Repositories);
                    row += "</tr>";
                
                
                $('#bookstable tbody#bookbody').append(row);
                
            }
            
            //Function to return the all editions of the book
            function returnRecords(bookID,records){
                    var recordrow="";
                    $.each(records,function(index,record){
                        if(index>0){
                            recordrow += "</tr><tr>";
                        }
                        recordrow += "<td>"+record.Edition+"</td><td>"+record.Price+"</td><td>"+record.NumberOfCopies+"</td>";
                        recordrow +="<td name='update'><a href='Update.html'><button type='button' onclick='Update(this);'value='"+bookID+"' data-id='"+record.Edition+"'><span class='glyphicon glyphicon-edit' /></button></a></td>";
                        
                    });
                     
                    return recordrow;
            }
            
            //Function to return the authors to the table row
            function returnAuthors(authors){
                    var authorsrow="";
                    $.each(authors,function(index,author){
                        authorsrow += (index+1)+". "+author.Name+"<br />";//+"<button type='button' class='btn btn-xs pull-right'>Details</button><br />";
                    })
                    return authorsrow;
            }
            
            //Function for To display No data Found
            function NoDataFound(){
                    alert("No Data Found for the data that you have entered");
                    $("#NoDataFoundDiv").show();
                    $("#BooksTableDiv").hide();
                }

            //Function for ajax call for Get method
            function GetData(url){
                                
                      return  $.ajax({
                                       method: "GET",
                                       url: url,
                                       dataType: "json"
                                      }).done(function(data){
                                            if(data==null){
                                                NoDataFound();
                                            }
                                        })
                                       .fail(function (msg){
                                            alert("Operation Failed");
                                        })
                                        .always(function(){
                                            
                                        });
                   
                }
            
            //Function to update the book
            function Update(obj) {
                $.when($("#updatediv").load("AddBook.html")).done(function () {
                    alert(obj.value);
                    alert($(obj).attr("data-id"));
                    $("#inputTitle").val("Hi");
                });

            }
        
            //Adding Authors to the select list
            function addAuthors(authors){
                    $(authors).each(function(index,author){
                        var authorOption="<option value='"+author.Name+"'>"+author.Name+"</option>";
                        $("#selectAuthors").append(authorOption);
                    });
                }
                    
            //Adding Publishers to the select list
            function addPublishers(publishers){
                    $(publishers).each(function(index,publisher){
                         var publisherOption="<option value='"+publisher.Name+"'>"+publisher.Name+"</option>";
                        $("#selectPublisher").append(publisherOption);
                    });
                   
                }

            //Function validating the inputs from the user
            function validatingInputs(){
                    //validating Title
                   var title=$('#inputTitle').val();
                   if(title==""){
                        alert("INVALID TITLE");
                        return false;
                   }
                   
                   //validating Genre
                   var genre=$('#selectGenre').val();
                   if(genre==""){
                       alert("INVALID GENRE");
                       return false;
                   }
                   
                  //validating Authors
                  var authors = $("#selectAuthors").val();                
                   if(authors === null || authors.length <1){
                       alert("INVALID AUTHORS");
                       return false;
                   }
                   
                   
                   //validating Publishers
                   var publisher=$('#selectPublisher').val();
                   if(publisher==""){
                       alert("INVALID PUBLISHER");
                       return false;
                   }
                   
                   //validating Edition
                   var edition=$("#inputEdition").val();
                   if(edition==""){
                       alert("INVALID EDITION");
                       return false;
                   }
                   
                   //validating Price
                   var price=$("#inputPrice").val();
                   if(!$.isNumeric(price)){
                       alert("INVALID PRICE");
                       return false;
                   }
                    
                   //validating the number of copies
                    var copies=$("#inputCopies").val();
                    if($.isNumeric(copies)&&Math.floor(copies)&&copies<=0){
                        alert("INVALID COPIES");
                        return false;
                    }
                  //return true beacause all are valid inputs
                    return true;
                }
                
            //Function to add the book to the database
            function GetBookJson(){
                    
                    //Creating the Book Object
                       var newBook=new Object();
                       newBook.Authors=[];
                       newBook.Repositories=[] ;
                    
                    //assigning the given values to the NewBook Object
                       newBook.Title=$("#inputTitle").val();
                       newBook.Genre=$("#selectGenre").val();

                    //assigning the authors to the new book object
                        var authors=$("#selectAuthors").val();
                        for(var i in authors){
                             
                             var author=new Object();
                             author.Name=authors[i];
                             newBook.Authors.push(author);
                        }
                    
                    //Assigning the publisher to the new book Object
                        newBook.Publisher=new Object();
                        newBook.Publisher.Name=$("#selectPublisher").val();
                        newBook.Publisher.Contact=34589739875;

                    
                    
                    //Adding editions to the book
                        var bookrepo=new Object();
                        bookrepo.Edition=$("#inputEdition").val();
                        bookrepo.Price=$("#inputPrice").val();
                        bookrepo.NumberOfCopies=$("#inputCopies").val();

                        newBook.Repositories.push(bookrepo);

                   return newBook;
                   
                }   

            //Function to empty the input buttons
            function EmptyInputs(){
                    $("#inputTitle").val("");
                    $("#selectGenre").val("");
                    $("#selectAuthors").val("");
                    $("#selectPublisher").val("");
                    $("#inputPrice").val("");
                    $("#inputEdition").val("");
                    $("#inputCopies").val("");
                }
                
           