import './TopUser.css';


const TopUsers = () => {
    return (

        <>

        <div className={"topUserBox"}>
            <div className={"topUserHead"}>
                <h3>Top Users</h3>

                <ul>
                    <li>
                        <h3>Top User 1</h3>
                        <div className={"userImg"}>AB</div>
                    </li>
                    <li>
                        <h3>Top User 2</h3>
                        <div className={"userImg"}>AB</div>
                    </li>
                    <li>
                        <h3>Top User 3</h3>
                        <div className={"userImg"}>AB</div>
                    </li>
                </ul>
                
            </div>
        </div>

        </>
    );
}

export default TopUsers;