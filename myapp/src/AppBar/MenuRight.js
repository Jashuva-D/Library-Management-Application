import React from 'react';
import ReactDOM from 'react-dom';
import IconMenu from 'material-ui/IconMenu';
import IconButton from 'material-ui/IconButton';
import MoreVertIcon from 'material-ui/svg-icons/navigation/more-vert';
import MenuItem from 'material-ui/MenuItem';



const MenuRight = (props) => (
    <IconMenu
        {...props}
        iconButtonElement={
            <IconButton><MoreVertIcon /></IconButton>
        }
    >
        <MenuItem primaryText="AboutUs"></MenuItem>
        <MenuItem primaryText="ContactUs" />
    </IconMenu>
)

export default MenuRight;