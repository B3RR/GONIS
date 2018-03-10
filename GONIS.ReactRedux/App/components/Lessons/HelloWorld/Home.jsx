import React from 'react';
import AlfaTest from './AlfaTest.jsx';
import Helmet from 'react-helmet';


export default class Home extends React.Component {
    render() {
        return (<div><Helmet title='Main Page' />Hello world from React <AlfaTest /></div> );
    }
}