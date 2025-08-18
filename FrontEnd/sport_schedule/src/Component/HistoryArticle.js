import { useEffect, useState } from "react"
import { endpoints, authApis } from "../Services/Apis"
import { Table, Image } from "react-bootstrap"
import UpdateArticle from "./UpdateArticleModal"

const HistoryArticle = () => {

    const [articles, setArticles] = useState(null)
    const [showModal, setShowModal] = useState(false)
    const [articleUpdateSelected, setArticleUpdateSelected] = useState(null)

    const getArticle = async () => {
        try {
            var res = await authApis().get(endpoints.historyArticle)
            setArticles(res.data)
            console.log(articles)
        } catch (err) {
            setArticles(null)
            console.log(err)
        }
    }

    const handleDeleteArticle = async (articleId) => {
        if (window.confirm("Bạn chắc chắn muốn xóa")) {
            try {
                var res = await authApis().delete(endpoints.deleteArticle(articleId))
                if (res.status === 200)
                    getArticle()
            } catch (err) {
                console.log(err)
            }
        }
    }

    useEffect(() => {
        getArticle()
    }, [])

    return (
        <>
            <div>
                <div className="text-center">
                    <h3>Các bài viết của tôi</h3>
                </div>
                <div >
                    <Table className="" style={{ marginLeft: "50px", width: "1300px" }} bordered hover>
                        <thead className="text-center">
                            <tr>
                                <th>STT</th>
                                <th>Tiêu đề</th>
                                <th style={{width: "500px"}}>Nội dung</th>
                                <th>Ngày đăng</th>
                                <th>Ảnh đại diện</th>
                                <th>Trạng thái</th>
                                <th>Quyền hạn</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                articles && articles.map((article, index) => (
                                    <tr>
                                        <td className="text-center">{index + 1}</td>
                                        <td>{article.title}</td>
                                        <td>{article.description}</td>
                                        <td className="text-center">{article.createdDate}</td>
                                        <id className="content-center">
                                            <Image style={{ width: "100px", height: " 70px" }} src={article.image}></Image>
                                        </id>
                                        <td className="text-center">{article.status}</td>
                                        <td>
                                            <div className="d-flex">
                                                <div className="mx-3">
                                                    <button onClick={() => { setArticleUpdateSelected(article); setShowModal(true) }} disabled={article.status === "Đã duyệt"} className="btn btn-primary">Sửa bài</button>
                                                </div>

                                                <div>
                                                    <button className="btn btn-danger" onClick={() => handleDeleteArticle(article.articleId)}>Xóa bài</button>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                ))
                            }
                            <UpdateArticle show={showModal} handleClose={() => { setShowModal(false); getArticle() }} article={articleUpdateSelected} />
                        </tbody>
                    </Table>
                </div>
            </div>
        </>
    );
}

export default HistoryArticle