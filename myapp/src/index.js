import React from 'react';
import ReactDOM from 'react-dom';
//import $ from "jquery";
//import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
//import '../node_modules/bootstrap/dist/js/bootstrap.min';
import './index.css';
import AppBarIcon from './AppBar/AppBarIcon';
import LibraryApplication from './LibraryApplication/LibraryApplication';
import registerServiceWorker from './registerServiceWorker';
import Example from './TestCases/Example';




ReactDOM.render(<LibraryApplication />, document.getElementById('root'));
//ReactDOM.render(<Example />,document.getElementById('root'));
registerServiceWorker();
