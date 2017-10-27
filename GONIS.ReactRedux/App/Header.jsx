import React from 'react';
import { Link } from 'react-router-dom'

export default class Header extends React.Component{
    render() {
        return (
            <header>
                <nav>
                    <ul>
                        <li><Link to='/'>Home</Link></li>
                        <li><Link to='/l1'>Lesson 1 - Contacts List</Link></li>
                        <li><Link to='/l2'>Lesson 2 - Timer</Link></li>
                        <li><Link to='/l3'>Lesson 3 - Notes App</Link></li>
                    </ul>
                </nav>
            </header>
        );
    }
}