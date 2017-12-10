import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Error from './Error.jsx';
import Home from './Lessons/HelloWorld/Home.jsx';
import Lesson1 from './Lessons/Lesson1.jsx';
import Lesson2 from './Lessons/Lesson2.jsx';
import Lesson3 from './Lessons/Lesson3.jsx';
import Lesson4 from './Lessons/Lesson4.jsx';
import Lesson5 from './Lessons/Lesson5.jsx';


export default class Content extends React.Component {
    render() {
        return (
            <Switch>
                <Route exact path='/' component={Home} />
                <Route path='/l1' component={Lesson1} />
                <Route path='/l2' component={Lesson2} />
                <Route path='/l3' component={Lesson3} />
                <Route path='/l4' component={Lesson4} />
                <Route path='/l5' component={Lesson5} />
                <Route path='*' component={Error} />
            </Switch>
        );
    }
}


