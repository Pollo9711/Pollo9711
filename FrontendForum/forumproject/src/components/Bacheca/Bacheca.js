import { Input } from '@material-ui/core';
import './Bacheca.css';

const Bacheca = () => {
    return(
        <>

            <div className={"bachecaBox"}>

                <div className={"bachecaInput"}>
                    <div className={"bachecaImg"}></div>
                    <input type="text" placeholder="Write smothing..." />
                </div>

            </div>

        </>
    );
}
export default Bacheca;