import React from 'react';
import { Switch, Route } from 'react-router-dom';
import Error from './Error.jsx';
import Home from '../../components/Lessons/HelloWorld/Home.jsx';
import Lesson1 from '../../components/Lessons/Lesson1.jsx';
import Lesson2 from '../../components/Lessons/Lesson2.jsx';
import Lesson3 from '../../components/Lessons/Lesson3.jsx';
import Lesson4 from '../../components/Lessons/Lesson4.jsx';
import Lesson5 from '../../components/Lessons/Lesson5.jsx';
import Lesson6 from '../../components/Lessons/Lesson6.jsx';


export default class AppContent extends React.Component {
    render() {
        return (
            <Switch>
                <Route exact path='/' component={Home} />
                <Route path='/l1' component={Lesson1} />
                <Route path='/l2' component={Lesson2} />
                <Route path='/l3' component={Lesson3} />
                <Route path='/l4' component={Lesson4} />
                <Route path='/l5' component={Lesson5} />
                <Route path='/l6' component={Lesson6} />
                <Route path='*' component={Error} />
            </Switch>
        );
    }
}


