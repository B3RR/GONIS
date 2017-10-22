import React from 'react';
import ReactDOM from 'react-dom';
import Button from 'arui-feather/button';


const buttons = [
    { size: 's', name: 'Применить' },
    { size: 'm', name: 'Применить' },
    { size: 'l', name: 'Применить' },
    { size: 'xl', name: 'Применить' }
];



    function handleClick() {
        alert('eeeee');
    }

ReactDOM.render(
    <div>
        {buttons.map(({ size, name }) => (
            <div className='row'>
                <div className='column' key={size}>
                    <Button onClick={handleClick} size={size}>{`${name}`}</Button>
                </div>
            </div>
        ))}
    </div>,
    document.getElementById('alfatest')
);