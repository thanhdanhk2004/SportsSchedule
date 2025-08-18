import { useEffect, useState } from "react"
import api, { endpoints } from "../Services/Apis"
import { Container, Image } from "react-bootstrap"
import { Pagination } from "react-bootstrap"

const News = () => {
    const [articles, setArticles] = useState(null)
    const [page, setPage] = useState(1)
    const [totalPage, setTotalPage] = useState()
    const [pageSelected, setPageSelected] = useState(1)

    const getArticles = async () => {
        try {
            var res = await api.get(endpoints.getArticle(page))
            setArticles(res.data)
            setTotalPage(articles && articles[0].totalPage)
        } catch (err) {
            console.log(err)
        }
    }
    useEffect(() => {
        getArticles()
    }, [articles])


    return (
        <Container className="mt-4">
            <div className="d-flex flex-wrap gap-3 mb-4" style={{ marginLeft: "30px" }}>
                {articles && articles.map((article) => (
                    <div key={article.articleId} style={{ width: "30%", backgroundColor: "light", borderRadius: "5px", boxShadow: "0 4px 8px rgba(0,0,0,0.1)", padding: "10px", margin: "10px", border: "1px solid #ddd" }}>
                        <div>
                            <Image
                                src={article.image}
                                style={{ height: "200px", objectFit: "cover", width: "100%", borderRadius: "5px" }}
                            />
                        </div>
                        <div>
                            <h5 className="text-center mt-3" style={{ fontWeight: "500" }}>
                                {article.title}
                            </h5>
                        </div>
                    </div>
                ))}
            </div>
            <div className="" style={{ marginLeft: "500px" }}>
                <Pagination>
                    <Pagination.First onClick={() => { setPage(1); getArticles(); setPageSelected(1) }} />
                    <Pagination.Prev onClick={() => { setPage(page - 1); getArticles(); setPageSelected(page-1) }} />
                    {totalPage && [...Array(totalPage)].map((_, index) => (
                        <div className={`${pageSelected === index+1 ? "bg-primary" : ""}`}>
                            <Pagination.Item key={index} onClick={() => { setPage(index + 1); getArticles(); setPageSelected(index+1) }}>
                                {index + 1}
                            </Pagination.Item>
                        </div>
                    ))}
                    <Pagination.Next onClick={() => { setPage(page + 1); getArticles(); setPageSelected(page+1) }} />
                    <Pagination.Last onClick={() => { setPage(totalPage); getArticles(); setPageSelected(totalPage) }} />
                </Pagination>
            </div>
        </Container>

    );
}

export default News