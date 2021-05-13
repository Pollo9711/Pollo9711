import './Home.css';
import PostHome from "../../../components/PostHome/PostHome"
import Bacheca from "../../Bacheca/Bacheca";
const Home = () => {

    return (
        <>
            <div className={"homeBg"}>
                <div className={"homeBacheca"}>
                    <Bacheca/>
                </div>

                <PostHome/>

            </div>
        </>
    );
}

export default Home;