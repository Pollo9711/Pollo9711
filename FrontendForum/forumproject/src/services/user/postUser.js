
export async function postUser(userData) {
    return await fetch('https://localhost:5001/user', {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(userData)
    }).then(()=> {
        window.location.href = 'home'
    })
}