import React from "react";
import Helmet from 'react-helmet';

export default class Lesson2 extends React.Component {
    constructor(props) {
        super(props);
        this.state = { seconds: 0 };
    }

    componentWillMount() {
        clearInterval(this.state.intervalId);
    }

    componentDidMount() { 
        var intervalId = setInterval(this.tick.bind(this), 1000);
        this.setState({ intervalId: intervalId });
    }

    componentWillUnmount() {
        clearInterval(this.state.intervalId);
    }

    tick() {
        this.setState({ seconds: this.state.seconds+1 });
    }

    render() {
        return (
            <div><Helmet title="Lesson 2 - Timer" />{this.state.seconds} seconds</div>
            );
    }
}

