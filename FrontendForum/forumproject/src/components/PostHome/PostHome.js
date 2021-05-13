import './PostHome.css';
import TopUsers from "../TopUsers/TopUsers";
import MostLikedPosts from "../MostLikedPosts/MostLikedPosts";
import PostBox from "../PostBox/PostBox";


const PostHome = () => {
    return (
        <>
            <div className={"wrapperBox"}>

                <div className={"multiPostBox"}>
                    <div>
                        <PostBox/>
                    </div>

                    <div>
                        <PostBox/>
                    </div>

                    <div>
                        <PostBox/>
                    </div>
                </div>

                <div className={"sidePostBox"}>

                    <MostLikedPosts/>

                    <TopUsers/>

                </div>

            </div>
        </>
    );
}

export default PostHome;