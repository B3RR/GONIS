import 'core-js/fn/object/assign'; // for IE
import 'core-js/fn/object/is'; // for IE 
import 'core-js/fn/array/find'; // for IE 


import React from 'react';
import ReactDOM from 'react-dom';
import App from './App.jsx';
import { BrowserRouter } from 'react-router-dom';

ReactDOM.render(
    (<BrowserRouter>
        <App />
    </BrowserRouter>)
        , document.getElementById('App')
);

if (module.hot) {
    module.hot.accept();
}