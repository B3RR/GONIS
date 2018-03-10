import React from 'react';
import Helmet from 'react-helmet';
import messages from './messages.jsx';

export default class Message extends React.Component {
    constructor(props) {
        super(props);
        
    }

    render() {
        const { messageId } = this.props.match.params;
        let message = messages.find(message => message.id === messageId)
        if (message) {
            return (<div><Helmet title={message.subject} />
                <p>From: {message.senderName} ({message.senderEmail})</p>
                <p>To: you</p>
                <p>Subject: {message.subject}</p>
                <hr />
                <p>{message.body}</p>
            </div>);
        }
        else
        {
            return (<div>Message not found.</div>);
        }
    }
}