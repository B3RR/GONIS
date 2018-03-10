import React from 'react';
import { Switch, Route, Link } from 'react-router-dom';
import Helmet from 'react-helmet';
import AboutPage from './Lesson5/AboutPage.jsx';
import InboxPage from './Lesson5/InboxPage.jsx';
import './Lesson5.css';


export default class Lesson5 extends React.Component {
    constructor(props) {
        super(props);
        this.state = { pathWithoutSlash: this.props.match.url };
    }

    componentWillMount() {
        let oldPath = this.props.match.url;
        let newPath = oldPath.charAt(oldPath.length - 1) === '/'
            ? oldPath.slice(0, -1)
            : oldPath
        this.setState({ pathWithoutSlash: newPath });
    }

    render() {
        return (<div><Helmet title='Lesson 5 - Router' />
            <h1>Lesson 5</h1>
            <div className='l5-menu'>
                <ul>
                    <li>
                        <Link to={`${this.state.pathWithoutSlash}/inbox`}>Inbox</Link>
                    </li>
                    <li>
                        <Link to={`${this.state.pathWithoutSlash}/about`}>About</Link>
                    </li>
                </ul>
            </div>
            <Switch>
                <Route exact path={`${this.state.pathWithoutSlash}`} render={() => (<h3>Please select.</h3>)} />
                <Route path={`${this.state.pathWithoutSlash}/inbox`} component={InboxPage} />
                <Route path={`${this.state.pathWithoutSlash}/about`} component={AboutPage} />
            </Switch>
        </div>
        );
    }
}

