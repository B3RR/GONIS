import React from 'react';
import ReactDOM from 'react-dom';
import { connect } from 'react-redux';
import { addTodo } from './actions/index.jsx';
import Button from 'arui-feather/button';
import Input from 'arui-feather/input';

let AddTodo = ({ dispatch }) => {
    let input;
    const handleClick = () => {
        if (!input.state.value.trim()) {
            return;
        }
        dispatch(addTodo(input.state.value));
        input.setState((prevState, props) => {
            return {
                value: ''
            }
        })
    }

return (
    <div>
        <Input ref={node => {
            input = node
        }}
            placeholder='Input task'
            view='line'
            size='s'
        />
        <Button size='s' onClick={handleClick}>
            Add Task
                </Button>
    </div>
)
}

AddTodo = connect()(AddTodo)

export default AddTodo