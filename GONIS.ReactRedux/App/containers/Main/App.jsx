import React from 'react';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import todoApp from '../../components/Lessons/Lesson6/Todo/reducers/index.jsx';

import Header from 'arui-private/header';
import Menu from './Menu.jsx';
import Content from 'arui-private/content';
import AppContent from './AppContent.jsx';
import Page from 'arui-private/page';
import Footer from 'arui-private/footer';
import ApplicationMenu from 'arui-private/application-menu';
import ApplicationMenuGroup from 'arui-private/application-menu-group';
import ApplicationMenuItem from 'arui-private/application-menu-item';
import User from 'arui-private/user';
import Modal from 'arui-private/modal';




const store = createStore(todoApp);


export default class App extends React.Component {
    render() {
        return (
            <Provider store={store}>
                <Page>
                    <Header menu={<Menu />} rightContent={<User url='/' onClick={() => <Modal />} text='User Name' />} />
                    <Content>
                        <AppContent />
                    </Content>
                    <Footer />
                </Page>
            </Provider>
        );
    }
}
