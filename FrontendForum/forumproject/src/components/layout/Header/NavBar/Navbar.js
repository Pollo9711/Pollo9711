import './Navbar.css';
import {NavLink} from "rect-router-dom";

const Navbar = () => {
    return (
        <>
           <NavLink to={'/'}> Home </NavLink>
            <NavLink to={'/post'}> Post </NavLink>
            <NavLink to={'/profile'}> Profile </NavLink>
            <NavLink to={'/registrati'}> Registrati </NavLink>
        </>
    );
}

export default Navbar;