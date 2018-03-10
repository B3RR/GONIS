import React from 'react';
import ApplicationMenu from 'arui-private/application-menu';
import ApplicationMenuGroup from 'arui-private/application-menu-group';
import ApplicationMenuItem from 'arui-private/application-menu-item';
import { Link } from 'react-router-dom';
import Label from 'arui-feather/label';

export default class Menu extends React.Component {

    
    render() {
        return (
            <ApplicationMenu>
                <ApplicationMenuItem disabled={true} >
                    <Link to='/'><Label size='s'>Main</Label></Link>
                </ApplicationMenuItem>
                <ApplicationMenuItem disabled={true}>
                    <Link to='/l1'><Label size='s'>Lesson 1 - Contacts List</Label></Link>
                </ApplicationMenuItem>
                <ApplicationMenuItem disabled={true}>
                    <Link to='/l2'><Label size='s'>Lesson 2 - Timer</Label></Link>
                </ApplicationMenuItem>
                <ApplicationMenuItem disabled={true}>
                    <Link to='/l3'><Label size='s'>Lesson 3 - Notes App</Label></Link>
                </ApplicationMenuItem>
                <ApplicationMenuItem disabled={true}>
                    <Link to='/l4'><Label size='s'>Lesson 4 - Backend</Label></Link>
                </ApplicationMenuItem>
                <ApplicationMenuGroup title={<Link to='/l5'><Label size='s'>Lesson 5 - Router</Label></Link>} disabled={true} onTitleClick={() => { console.log('onTitleClick Lesson 5 open'); }}>
                    <ApplicationMenuItem disabled={true}>
                        <Link to='/l5/inbox'><Label size='s'>Inbox</Label></Link>
                    </ApplicationMenuItem>
                    <ApplicationMenuItem disabled={true}>
                        <Link to='/l5/about'><Label size='s'>About</Label></Link>
                    </ApplicationMenuItem>
                </ApplicationMenuGroup>
                <ApplicationMenuGroup title={<Link to='/l6'><Label size='s'>Lesson 6 - Redux</Label></Link>} disabled={true} onTitleClick={() => { console.log('onTitleClick Lesson 6 open'); }}>
                    <ApplicationMenuItem disabled={true}>
                        <Link to='/l6/todo'><Label size='s'>Todo List</Label></Link>
                    </ApplicationMenuItem>
                </ApplicationMenuGroup>
            </ApplicationMenu>

        );
    }
}