import React from 'react';
import Helmet from 'react-helmet';

export default class Lesson4 extends React.Component { 
    constructor(props) {
        super(props);
    }
    
    render() {
        return (<div>
                    <Test url='/Test/GetList' />
                </div>);
    }
}

class Test extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }

    componentWillMount()   {
        let xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            let data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }

    componentWillUnmount() {
        this.setState({ data: [] });
    }

    render() {
        return (<div><Helmet title='Lesson 4 - Backend' />
            <ul>
                {
                    this.state.data.map((el) => {
                        return <li key={el.id}>{el.id} - {el.text}</li>
                    })
                }
            </ul>
        </div>);

    }

}
