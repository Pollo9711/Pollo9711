import {useEffect, useState} from "react";


const useFetch = (url) => {

    const [data, setData] = useState([]);
    const [error, setError] = useState(null)
    const [loading, setLoading] = useState(true)


    useEffect(() => {
        async function init(){
            try{
                const response = await fetch(url);
                if (response.ok){
                    const json = await response.json();
                    setData(json)
                }
                else{
                    throw response;
                }
            }
            catch (e){
                setError(e);
                console.error(`Error during ${e}`)
            }finally {
                setLoading(false)
            }
        }
        init();
    }, [])

    return {data, error, loading};
}

export default useFetch;