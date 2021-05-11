import {useState} from "react";

// NB CSS DA FARE

const Registrati = () => {

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
            <form onSubmit={handleSubmit}>
                <input type="text"
                       placeholder={'Username'}
                       name={'username'}
                       value={formValue.username}
                       onChange={handleChange}
                />

                <input type="text"
                       placeholder={'Password'}
                       name={'password'}
                       value={formValue.password}
                       onChange={handleChange}
                />

                <button type={'submit'}>Submit</button>
            </form>
        </>
    );
}

export default Registrati;