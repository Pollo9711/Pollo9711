export async function getUser(userData) {
    return await fetch(`https://localhost:5001/api/user/${user.id}`, {
        method: 'GET',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(userData)
    }).then(()=> {
        window.location.href = 'profile'
    })
}