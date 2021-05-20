import {useEffect, useState} from "react";


const useFetchAll = (urls) => {

    const [data,setData] = useState([]);
    const [error,setError] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const promises = urls.map((url) =>
            fetch('http://localhost:4200' + url))
            .then((response) => {
                if(response.ok) return response.json()
                else throw response
            })

        Promise.all(promises)
            .then((json) => setData(json))
            .catch((e) => {
                setError(e);
            })
            .finally(() => setLoading(false))

    }, [])



    return {data,error,loading}

}
export default useFetchAll;