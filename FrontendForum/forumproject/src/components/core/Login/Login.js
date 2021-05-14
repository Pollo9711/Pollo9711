import {useState} from "react";
import './Login.css';
import {emptyCheckoutLoginData} from "../../../utils/dataModels/emptyCheckoutLoginData";
import {getUser} from "../../../services/user/getUser";


const Login = () => {

    const FORMSTATUS = {
        IDLE: 'IDLE',
        SUBMITTING: 'SUBMITTING',
        SUBMITTED: 'SUBMITTED',
        COMPLETED: 'COMPLETED'
    }

    const [checkoutData, setCheckoutData] = useState(emptyCheckoutLoginData);
    const [formStatus, setFormStatus] = useState(FORMSTATUS.IDLE);
    const [touched, setTouched] = useState({})


    async function handleSubmit (e) {
        e.preventDefault();
        setFormStatus(FORMSTATUS.SUBMITTING)
        if (isFormValid){
            await getUser(checkoutData)
            setFormStatus(FORMSTATUS.COMPLETED)
        }else{
            setFormStatus(FORMSTATUS.SUBMITTED)
        }
        console.log(`Username: ${checkoutData.username} | Password: ${checkoutData.password}`)
    }

    const handleBlur = (e) => {
        setTouched((previousState) => {
            return {...previousState,[e.target.name] : true}
        })
    }

    function handleErrors(data){
        const results = {};

        if (data.username === ''){
            results.username = 'Username is required!'
        }
        if (data.password === ''){
            results.password = 'Password is required!'
        }

        return results;
    }



    const handleChange = (e) => {
        setCheckoutData((previousCheckoutData)=>{
            return {...previousCheckoutData, [e.target.name]: e.target.value}
        })
        console.log(checkoutData)
    }
    const errors = handleErrors(checkoutData);
    const isFormValid = Object.keys(errors).length === 0;

    return (
        <>
        
            <h2>Login</h2>

            <div className={'formLogin'}>
                <form onSubmit={handleSubmit} className={'formInput'}>

                    {
                        !isFormValid && formStatus === FORMSTATUS.SUBMITTED
                            ? <div>
                                <h4>Ricontrolla il form!</h4>
                            </div>
                            : ''
                    }

                    <p>Your Username:</p>

                    <input type="text"
                        placeholder={'Username'}
                        name={'username'}
                        value={checkoutData.username}
                        onChange={handleChange}
                        onBlur={handleBlur}
                    />

                    <h6>
                        {touched.username ? errors.username : ''}
                    </h6>
                
                    <p>Your Password:</p>
                    <input type="password"
                       placeholder={'Password'}
                       name={'password'}
                       value={checkoutData.password}
                       onChange={handleChange}
                       onBlur={handleBlur}
                     />

                    <h6>
                        {touched.password ? errors.password : ''}
                    </h6>

                    <div className={'buttonDiv'}>
                        <button
                            disabled={formStatus === FORMSTATUS.SUBMITTING}
                            type={'submit'}
                            className="btn btn-dark">
                            Submit
                        </button>
                    </div>

            </form>
            </div>

        </>
    );
}

export default Login;