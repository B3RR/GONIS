import React from 'react';
import Helmet from 'react-helmet';
import './Lesson1.css';

let CONTACTS = [
    {
        id: 1,
        name: 'Oleg',
        phone: '+79216523442',
        imageULR: 'http://alfa/my/User%20Photos/Profile%20Pictures/u_021l6_MThumb.jpg'
    },
    {
        id: 2,
        name: 'Roma',
        phone: '+7922142432344',
        imageULR: 'http://alfa/my/User%20Photos/Profile%20Pictures/u_m0mus_MThumb.jpg'
    },
    {
        id: 3,
        name: 'Sasha',
        phone: '+7923244244321',
        imageULR: 'http://alfa/my/User%20Photos/Profile%20Pictures/u_m0rjq_MThumb.jpg'
    },
    {
        id: 4,
        name: 'Vika',
        phone: '+793222423421',
        imageULR: 'http://alfa/my/User%20Photos/Profile%20Pictures/u_m0vjd_MThumb.jpg'
    },
]


export default class ContactList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { displayedContacts: CONTACTS };
        this.handleSearch = this.handleSearch.bind(this);
    }

    handleSearch(event) {
        let searchQuery = event.target.value.toLowerCase();
        let displayedContacts = CONTACTS.filter((el) => {
            var searchValue = el.name.toLowerCase();
            return searchValue.indexOf(searchQuery) !== -1;
        });
        // console.log(displayedContacts);
        this.setState({ displayedContacts: displayedContacts });


    }

    render() {
        return (<div className='l1-contacts'><Helmet title="Lesson 1 - Contacts List" />
            <input type='text' className='l1-search-field' onChange={this.handleSearch} />
            <ul className='l1-contacts-list'>
                {
                    this.state.displayedContacts.map((el) => {
                        return <Contact key={el.id}
                            name={el.name}
                            phone={el.phone}
                            imageULR={el.imageULR} />
                    })
                }
            </ul>
        </div>);
    }
}

class Contact extends React.Component {
    render() {
        return (<li className='l1-contact'>
            <img src={this.props.imageULR} className='l1-contact-image'  width='60px' height='60px' />
            <div className='l1-contact-info'>
                <div className='l1-contact-name'>{this.props.name}</div>
                <div className='l1-contact-number'>{this.props.phone}</div>
            </div>
                </li>);
    }
}




  