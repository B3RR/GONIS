import React from 'react';
import './MessagePreview.css';
import { Link } from 'react-router-dom';

export default class MessagePreview extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (<div className='l5-MessagePreview' onClick={this.props.onClick}>
            <Link className='l5-MessagePreview-Link' to={this.props.link}>
            <div className='l5-MessagePreview-Title'> {this.props.subject}</div>
            <div className='l5-MessagePreview-From'> from: {this.props.senderName}</div>
            </Link>
        </div>);
}
}