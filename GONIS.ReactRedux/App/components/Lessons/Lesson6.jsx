import React from 'react';
import Helmet from 'react-helmet';
import { Switch, Route, Link } from 'react-router-dom';
import Filter from './Lesson6/Todo/Filter.jsx';
import AddTodo from './Lesson6/Todo/AddTodo.jsx';
import VisibleTodoList from './Lesson6/Todo/VisibleTodoList.jsx';
import Tabs from 'arui-feather/tabs';
import TabItem from 'arui-feather/tab-item';



export default class Lesson6 extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            pathWithoutSlash: this.props.match.url,
            page: window.location.pathname
        };
        
    }

    shouldComponentUpdate(nextProps, nextState) {
        if (this.props.location.pathname === nextProps.location.pathname) {
            return true;
        }
        else {
            console.log('location will be change from ' + this.props.location.pathname + ' to ' + nextProps.location.pathname);
            this.setState({ page: nextProps.location.pathname });
            return false;
        } 
    }
    componentWillMount() {
        let oldPath = this.props.match.url;
        let newPath = oldPath.charAt(oldPath.length - 1) === '/'
            ? oldPath.slice(0, -1)
            : oldPath
        this.setState({
            pathWithoutSlash: newPath
        });
    }

    render() {
        const handleClick = (event) => {
            event.preventDefault();
            const url = event.target.getAttribute('href');
            if (url) {
                this.setState({ page: url });
                this.props.history.push(url);          
            }
        }
        return (<div><Helmet title='Lesson 6 - Redux' />
            <h1>Lesson 6</h1>
            <div>
                <Tabs>
                    <TabItem url={`${this.state.pathWithoutSlash}`} checked={this.state.page === this.state.pathWithoutSlash} onClick={handleClick} >
                        Main
                    </TabItem>
                    <TabItem url={`${this.state.pathWithoutSlash}/todo`} onClick={handleClick} checked={this.state.page === this.state.pathWithoutSlash + '/todo'} onClick={handleClick} >
                        Todo List
                    </TabItem>
                </Tabs>
            </div>
            <br />
            <Switch>
                <Route exact path={`${this.state.pathWithoutSlash}`} render={() => (<h3>Please select.</h3>)} />
                <Route path={`${this.state.pathWithoutSlash}/todo`} component={Todo} />
            </Switch>
        </div>
        );
    }

}

const Todo = () => (
    <div>
        <Helmet title='Todo list' />
        <AddTodo />
        <br />
        <Filter />
        <VisibleTodoList />
        
    </div>
)