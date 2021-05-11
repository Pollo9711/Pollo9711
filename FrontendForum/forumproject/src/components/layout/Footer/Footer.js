import "./Footer.css"
import {faRobot} from "@fortawesome/free-solid-svg-icons";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";


const Footer = () => {

    return (
        <>
            <div id={"footer"}>
                <div id={"logo"}>
                    <FontAwesomeIcon icon={faRobot}/>
                </div>
                <p>Copyright ©</p>
            </div>

        </>
    );
}

export default Footer;