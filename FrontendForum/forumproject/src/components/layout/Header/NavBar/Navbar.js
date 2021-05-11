import './Navbar.css';
import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faRobot} from "@fortawesome/free-solid-svg-icons";
import {faBars} from "@fortawesome/free-solid-svg-icons";
import {faSearch} from "@fortawesome/free-solid-svg-icons";
import React from 'react';
import Button from '@material-ui/core/Button';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';



const Navbar = () => {

    const [anchorEl, setAnchorEl] = React.useState(null);

    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    return (
        <>
            <div id={"navbar"}>
                    <div className="logoInput" >
                        <NavLink id={"logo"} to={"/home"}><FontAwesomeIcon icon={faRobot}/></NavLink>
                        <form className="d-flex">
                                <button className="btn btn-outline-success" type="submit"><FontAwesomeIcon icon={faSearch}/></button>
                                <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                                <h1>FORUM</h1>
                        </form>
                        <div className={"menu"}>
                            <button id={"login"} className="btn btn-outline-success" type="submit">Login</button>
                            <Button aria-controls="simple-menu" aria-haspopup="true" onClick={handleClick}>
                                <FontAwesomeIcon id={"bars"} icon={faBars}/>
                            </Button>
                            <Menu
                                id="simple-menu"
                                anchorEl={anchorEl}
                                keepMounted
                                open={Boolean(anchorEl)}
                                onClose={handleClose}
                            >
                                <MenuItem onClick={handleClose}><NavLink to={'/'}> Home </NavLink></MenuItem>
                                <MenuItem onClick={handleClose}><NavLink to={'/post'}> Post </NavLink></MenuItem>
                                <MenuItem onClick={handleClose}><NavLink to={'/profile'}> Profile </NavLink></MenuItem>
                                <MenuItem onClick={handleClose}><NavLink to={'/registrati'}> Registrati </NavLink></MenuItem>
                            </Menu>
                        </div>
                    </div>
            </div>


        </>
    );
}
export default Navbar;