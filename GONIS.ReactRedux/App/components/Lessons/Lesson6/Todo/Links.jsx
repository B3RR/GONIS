import React from 'react';
import PropTypes from 'prop-types';
import Link from 'arui-feather/link';
import Label from 'arui-feather/label';

const Links = ({ active, children, onClick }) => {
    if (active) {
        return <Label>{children}</Label>
    }

    return (
        <Link
            text={children}
            pseudo={true}
            onClick={e => {
                e.preventDefault()
                onClick()
            }}
        />
            

    )
}

Links.propTypes = {
    active: PropTypes.bool.isRequired,
    children: PropTypes.node.isRequired,
    onClick: PropTypes.func.isRequired
}

export default Links