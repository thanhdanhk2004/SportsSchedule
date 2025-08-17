import { useEffect, useState } from "react"
import { endpoints, authApis } from "../Services/Apis"

const HistoryArticle = () =>{
    
    const [articles, setArticles] = useState()
    const getArticle = async () =>{
        try{
            var res = await authApis().get(endpoints.historyArticle)
            setArticles(res.data)
            console.log(articles)
        }catch(err){
            console.log(err)
        }
    }

    useEffect(() => {
        getArticle()
    }, [])

    return(
        <>
        <h3>{articles && articles[0].description}</h3>
        </>
    );
}

export default HistoryArticle