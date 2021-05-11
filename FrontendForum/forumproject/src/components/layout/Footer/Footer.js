import "./Footer.css"
import {faRobot} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {NavLink} from "react-router-dom";

const Footer = () => {

    return (
        <>
            <div id={"footer"}>
                <div id={"logo"}>
                <NavLink id={"logoRobot"} to={"/home"}><FontAwesomeIcon icon={faRobot}/></NavLink>
                </div>
                <p>Copyright ©</p>
            </div>

        </>
    );
}

export default Footer;