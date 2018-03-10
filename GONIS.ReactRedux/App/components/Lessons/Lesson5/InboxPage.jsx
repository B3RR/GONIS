import React from 'react';
import Helmet from 'react-helmet';
import MessagePreview from './MessagePreview.jsx';
import Message from './Message.jsx';
import MESSAGES from './MESSAGES.jsx';
import { Switch, Route } from 'react-router-dom';
import './InboxPage.css';

export default class InboxPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            messages: MESSAGES,
            pathWithoutSlash: this.props.match.url
        };
    }

    componentWillMount() {
        let oldPath = this.props.match.url;
        let newPath = oldPath.charAt(oldPath.length - 1) === '/'
            ? oldPath.slice(0, -1)
            : oldPath
        this.setState({ pathWithoutSlash: newPath });
    }
    render() {

        return (<div className='l5-InboxPage'>
            <Helmet title='Inbox' />
            <div className='l5-messages'>
                {
                    this.state.messages.map(message =>
                        <MessagePreview key={message.id}
                            subject={message.subject}
                            senderName={message.senderName}
                            link={this.state.pathWithoutSlash + '/' + message.id}
                        />)
                }
            </div>
            <div className='l5-message-container'>
                <Switch>
                    <Route exact path={`${this.state.pathWithoutSlash}`} render={() => (<h6>Click on message</h6>)} />
                    <Route path={`${this.state.pathWithoutSlash}/:messageId`} component={Message} />
                </Switch>
            </div>
        </div>);
    }
}