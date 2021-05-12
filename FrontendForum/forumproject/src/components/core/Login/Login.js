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
        const user = e.target.name;
        console.log(user);
        setFormValue({
            ...formValue,
            [user]: e.target.value
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
                
            </form>

            <div className={'buttonDiv'}>
                <button type={'submit'} class="btn btn-dark">Submit</button>
            </div>

            </div>

        </>
    );
}

export default Login;