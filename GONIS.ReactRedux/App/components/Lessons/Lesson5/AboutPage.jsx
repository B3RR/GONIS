import React from 'react';
import Helmet from 'react-helmet';


export default class AboutPage extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (<div><Helmet title='About Page' />
            <h2>About this page</h2>
            <div>
                <p>Something text, something text.</p>
                <p>Hello my darling.</p>
                <p>I'm going to go swimming.</p>
                <p>To be? Or not to be?</p>
            </div>
        </div>);
    }
}