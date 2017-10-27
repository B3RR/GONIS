import React from 'react';
import { Switch, Route } from 'react-router-dom'
import Home from './Lessons/HelloWorld/Home.jsx';
import Lesson1 from './Lessons/Lesson1.jsx';
import Lesson2 from './Lessons/Lesson2.jsx';
import Lesson3 from './Lessons/Lesson3.jsx';

export default class Content extends React.Component {
    render() { 
        return (
                <Switch>
                    <Route exact path='/' component={Home} />
                    <Route path='/l1' component={Lesson1} />
                    <Route path='/l2' component={Lesson2} />
                    <Route path='/l3' component={Lesson3} />
                </Switch>
        );
    }
}