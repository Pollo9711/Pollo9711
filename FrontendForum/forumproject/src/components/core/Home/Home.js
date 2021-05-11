import './Home.css';
import PostHome from "../../../components/PostHome/PostHome"

const Home = () => {

    return (
        <>
            <div className={"homeBg"}>
                <div className={"homeImg"}>
                </div>

                <PostHome/>

            </div>
        </>
    );
}

export default Home;