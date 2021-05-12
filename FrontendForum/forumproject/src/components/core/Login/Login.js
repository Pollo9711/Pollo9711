import {useState} from "react";
import './Login.css';

// NB CSS DA FARE

const Login = () => {

    const [inputValue, setInputValue] = useState('');

    const [formValue, setFormValue] = useState({
        username: '',
        password: ''
    });

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(`Username: ${formValue.username} | Password: ${formValue.password}`)
    }

    const handleChange = (e) => {
        const name = e.target.name;
        setFormValue({
            ...formValue,
            [name]: e.target.value
        })
    }

    return (
        <>
        
            <h2>Login</h2>

            <div className={'formLogin'}>
                <form onSubmit={handleSubmit} className={'formInput'}>
                
                    <p>Your Username:</p>
                    <input type="text"
                        placeholder={'Username'}
                        name={'username'}
                        value={formValue.username}
                        onChange={handleChange}
                    />
                
                    <p>Your Password:</p>
                    <input type="password"
                       placeholder={'Password'}
                       name={'password'}
                       value={formValue.password}
                       onChange={handleChange}
                     />

                    <div className={'buttonDiv'}>
                        <button type={'submit'} className="btn btn-dark">Submit</button>
                    </div>

            </form>
            </div>

        </>
    );
}

export default Login;