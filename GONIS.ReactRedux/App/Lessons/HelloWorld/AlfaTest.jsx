import React from 'react';
import Button from 'arui-feather/button';

export default class AlfaTest extends React.Component {

    render() {
        const buttons = [
            {size: 's', name: 'Применить' },
            {size: 'm', name: 'Применить' },
            {size: 'l', name: 'Применить' },
            {size: 'xl', name: 'Применить' }
        ];

        return (
            <div>
                {buttons.map(({ size, name }) => (
                        <div className='column' key={size}>
                            <Button onClick={() => { alert('eeeee'); }} size={size}>{`${name}`}</Button>
                        </div>
                ))}
            </div >);


    }
}