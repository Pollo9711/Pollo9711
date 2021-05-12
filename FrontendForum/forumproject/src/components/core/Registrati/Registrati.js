import {useState} from "react";
import './Registrati.css';

const Registrati = () => {

    const [inputValue, setInputValue] = useState('');

    const [formValue, setFormValue] = useState({
        username: '',
        email: '',
        password: ''
    });

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(`Email: ${formValue.email} | Username: ${formValue.username} | Password: ${formValue.password}`)
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
            <h2>Sign In</h2>

            <div className={'formSignIn'}>

                <form onSubmit={handleSubmit} className={'formInput'}>

                    <p>Your Email:</p>
                    <input type="email"
                           placeholder={'Email'}
                           name={'email'}
                           value={formValue.username}
                           onChange={handleChange}
                    />

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

export default Registrati;