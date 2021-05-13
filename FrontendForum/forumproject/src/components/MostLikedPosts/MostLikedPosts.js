import {NavLink} from "react-router-dom";
import './MostLikedPosts.css';

const MostLikedPosts = () => {
    return (
        <>

            <div className={"mostLikedBox"}>
                <div className={"mostLikedHead"}>
                    <h3>Most Liked Posts
                    </h3>

                    <div className={"mostLikedBody"}>
                        <ul>
                            <li><h4><NavLink to={'/'}>Post Title...</NavLink></h4></li>
                            <li><h4><NavLink to={'/'}>Post Title...</NavLink></h4></li>
                        </ul>
                    </div>

                </div>
            </div>

        </>
    );
}

export default MostLikedPosts;