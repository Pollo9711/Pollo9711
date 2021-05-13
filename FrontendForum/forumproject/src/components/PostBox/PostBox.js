import {NavLink} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faHeart} from "@fortawesome/free-solid-svg-icons";

const PostBox = () => {

    return(

        <>
            <div className={"postBox"}>
                    
                <div className={"postHead"}>
                    <h3><NavLink to={'/'}>Titolo Post</NavLink></h3>
                    <span className={"postImg"}>AB</span>
                </div>

                <div className={"postFoot"}>
                    <NavLink id={"heart"} to={"/home"}><FontAwesomeIcon icon={faHeart}/></NavLink>
                    <p>Post chiuso o no</p>
                </div>

            </div>

        </>
    );
}

export default PostBox;