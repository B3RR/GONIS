import React from 'react';
import Header from './Header.jsx';
import Content from './Content.jsx';

export default class App extends React.Component { 
    render() {
        return (<div>
                    <Header />
                    <Content />
                </div>);
    }
}
