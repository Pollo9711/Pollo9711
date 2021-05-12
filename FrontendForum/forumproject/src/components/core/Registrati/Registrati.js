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
        const name = e.target.name;
        setFormValue({
            ...formValue,
            [name]: e.target.value
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
                           value={formValue.email}
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

                    <div className={'buttonDiv'}>
                        <button type={'submit'} className="btn btn-dark">Submit</button>
                    </div>

                </form>
            </div>

        </>
    );
}

export default Registrati;