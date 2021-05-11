import './Navbar.css';
import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faRobot} from "@fortawesome/free-solid-svg-icons";
import {faSearch} from "@fortawesome/free-solid-svg-icons";



const Navbar = () => {
    return (
        <>
            <div id={"navbar"}>
                    <div className="logoInput" >
                        <NavLink id={"logo"} to={"/home"}><FontAwesomeIcon icon={faRobot}/></NavLink>
                        <form className="d-flex">
                                <button className="btn btn-outline-success" type="submit"><FontAwesomeIcon icon={faSearch}/></button>
                                <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
                        </form>
                        <nav>
                            <ul>
                                <li>
                                    <NavLink to={'/'}> Home </NavLink>
                                </li>
                                <li>
                                    <NavLink to={'/post'}> Post </NavLink>
                                </li>
                                <li>
                                    <NavLink to={'/profile'}> Profile </NavLink>
                                </li>
                                <li>
                                    <NavLink to={'/registrati'}> Registrati </NavLink>
                                </li>
                            </ul>
                        </nav>
                    </div>
            </div>

        </>
    );
}
export default Navbar;