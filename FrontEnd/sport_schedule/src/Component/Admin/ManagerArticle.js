import Pagination from 'react-bootstrap/Pagination';
import { endpoints, authApis } from '../../Services/Apis';
import { useEffect, useState } from 'react';
import { Table } from 'react-bootstrap';

const ManagerArticle = () => {
    const [articles, setArticles] = useState();
    const [totalPage, setTotalPage] = useState();
    const [page, setPage] = useState(1);
    const [pageSelected, setPageSelected] = useState(1);

    const getArticles = async () => {
        try {
            const response = await authApis().get(endpoints.getArticlesByPageAdmin(page));
            setArticles(response.data);
            setTotalPage(response.data && response.data[0].totalPage);
        } catch (error) {
            console.error("Error fetching articles:", error);
        }
    };

    const handleDeleteArticle = async (articleId) => {
        try {
            if (window.confirm("Bạn có chắc chắn muốn xóa bài viết này?")) {
                var res = await authApis().delete(endpoints.deleteArticle(articleId));
                if (res.status === 200) {
                    alert("Xóa bài viết thành công");
                    setPage(pageSelected)
                    getArticles();
                }
            }
        } catch (error) {
            console.error("Error deleting article:", error);
        }
    };

    const handleApproveArticle = async (article_id) => {
        try {
            if(window.confirm("Bạn có chắc chắn muốn duyệt bài viết này?")){
                var res = await authApis().patch(endpoints.approveArticle(article_id));
                if(res.status === 200){
                    alert("Duyệt bài viết thành công");
                    setPage(pageSelected)
                    getArticles();
                }
            }
        } catch (error) {
            console.error("Error approving article:", error);
        }
    };

    useEffect(() => {
        getArticles();
    }, [page]);

    return (
        <div>
            <div className="text-center mt-4">
                <h3>Quản lý bài viết</h3>
            </div>
            <div className="mt-5 mx-5">
                <Table className="" style={{ marginLeft: "50px", width: "1350px" }} bordered hover>
                    <thead className="text-center">
                        <tr>
                            <th>STT</th>
                            <th>Tác giả</th>
                            <th>Tiêu đề</th>
                            <th>Nội dung</th>
                            <th>Hình ảnh</th>
                            <th>Ngày tạo</th>
                            <th>Trạng thái</th>
                            <th style={{width: "170px"}}>Chức năng</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            articles && articles.map((article, index) => (
                                <tr>
                                    <td className="text-center">{index + 1}</td>
                                    <td>{article.userName}</td>
                                    <td>{article.title}</td>
                                    <td>{article.description}</td>
                                    <td><img src={article.image} alt={article.title} style={{ width: "100px" }} /></td>
                                    <td>{article.createdDate.split(" ")[0]}</td>
                                    <td className='text-center'>{article.status}</td>
                                    <td>
                                        <button className="btn btn-danger mx-3" onClick={() => handleDeleteArticle(article.articleId)}>Xóa</button>
                                        <button className="btn btn-primary" disabled={article.status === "Đã duyệt"} onClick={() => handleApproveArticle(article.articleId)}>Duyệt</button>
                                    </td>
                                </tr>
                            ))
                        }
                    </tbody>
                </Table>

            </div>
            <div className="" style={{ marginLeft: "700px" }}>
                <Pagination>
                    <Pagination.First onClick={() => { setPage(1); getArticles(); setPageSelected(1) }} />
                    <Pagination.Prev onClick={() => { setPage(page - 1); getArticles(); setPageSelected(page - 1) }} />
                    {totalPage && [...Array(totalPage)].map((_, index) => (
                        <div className={`${pageSelected === index + 1 ? "bg-primary" : ""}`}>
                            <Pagination.Item key={index} onClick={() => { setPage(index + 1); getArticles(); setPageSelected(index + 1) }}>
                                {index + 1}
                            </Pagination.Item>
                        </div>
                    ))}
                    <Pagination.Next onClick={() => { setPage(page + 1); getArticles(); setPageSelected(page + 1) }} />
                    <Pagination.Last onClick={() => { setPage(totalPage); getArticles(); setPageSelected(totalPage) }} />
                </Pagination>
            </div>
        </div>

    );
};

export default ManagerArticle;
