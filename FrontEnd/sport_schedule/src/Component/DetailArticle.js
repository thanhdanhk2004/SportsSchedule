import { useContext, useEffect, useState } from "react"
import { useSearchParams } from "react-router-dom"
import api, { authApis, endpoints } from "../Services/Apis"
import { Container, Image, Form, Button, Tabs, Tab, Card, Row, Col } from "react-bootstrap"
import { AuthContext } from "../Context/AuthContext"
import Login from "./Login"

const DetailArticle = () => {
    const [searchParams] = useSearchParams()
    const articleId = searchParams.get("articleId")
    const [article, setArticle] = useState(null)
    const { isLogin } = useContext(AuthContext)
    const [showLogin, setShowLogin] = useState(false)
    const [showRegister, setShowRegister] = useState(false)
    const [valueContentReply, setValueContentReply] = useState("")
    const [flagReply, setFlagReply] = useState(false)


    /*Lay thong tin bai bao*/ 
    const getInfoArticle = async () => {
        try {
            var res = await api.get(endpoints.getArticle(articleId))
            if (res.status === 200)
                setArticle(res.data)
        } catch (err) {
            console.log(err)
        }
    }

    /*Xu ly comment (them binh luan)*/
    const [comment, setComment] = useState({ postId: articleId, content: "", commentReplyId: null });


    const addComment = async (data) => {
        try {
            var res = authApis().post(endpoints.addComment, data);
            alert("Binh luan thanh cong")
            setComment(prev => ({
                ...prev,
                content: "",
                commentReplyId: null
            }))

            if(flagReply === true){
                setValueContentReply("")
                setReplyingTo(-1)
                setFlagReply(false)
            }            
        } catch (err) {
            console.log(err)
        }
    }

    const handleSubmit = (data) => {
        if (isLogin === false) {
            if (window.confirm("Vui long dang nhap de binh luan")) {
                setShowLogin(true)
            }
        }
        else {
            addComment(data)
            getComments()
        }
    };

    /*Xu ly comment (Xem binh luan)*/
    const [comments, setComments] = useState(null);

    const getComments = async () => {
        try {
            var res = await api.get(endpoints.getComments(articleId))
            if (res.status === 200)
                setComments(res.data)
        } catch (err) {
            console.log(err)
        }
    }

    /*Xu ly tra loi comment*/
    const [replyingTo, setReplyingTo] = useState(null);

    const handleCommentId = (commentId, contentReply) =>{
        const commentReply ={
            ...comment,
            content: contentReply,
            commentReplyId: commentId,
        }
        handleSubmit(commentReply)
    }   

    /*Xem phan hoi*/
    const [commentsReply, setCommentReply] = useState(null)
    const getCommentReply = async (commentId) =>{
        var res = await api.get(endpoints.getCommentsReply(commentId))
        if(res.status === 200)
        {
            setCommentReply(res.data)
            console.log(commentsReply)
        }

    }

    /*Load trang*/
    useEffect(() => {
        getInfoArticle()
        getComments()
    }, [])

    return (
        <>
            <Container style={{ width: "1000px" }}>
                {
                    article && (
                        <div>
                            <div>
                                <strong>Tác giả: {article.authorName} | {article.createdDate}</strong>
                            </div>
                            <div>
                                <h4 className="text-center">{article.title}</h4>
                            </div>
                            <div>
                                <Image style={{ width: "100%", height: "400px" }} src={article.image} />
                            </div>
                            <div className="mt-5">
                                <p style={{ fontSize: "20px" }}>
                                    {article.description}
                                </p>
                            </div>
                        </div>

                    )
                }
            </Container>
            <hr style={{ margin: "40px 270px", border: "1px solid #575050ff", width: "1000px" }} />
            <div style={{ width: "700px", marginLeft: "270px", marginTop: '100px', marginBottom: "50px" }}>
                <h5>Bình luận ({comments && comments.length})</h5>
                <Form>
                    <Form.Group controlId="commentBox">
                        <Form.Control
                            value={comment.content}
                            as="textarea"
                            rows={3}
                            name="content"
                            placeholder="Để lại bình luận của bạn..."
                            onChange={(e) => setComment({ ...comment, [e.target.name]: e.target.value })}
                        />
                    </Form.Group>
                    <Button className="mt-2" variant="danger" onClick={() => handleSubmit(comment)}>
                        Gửi bình luận
                    </Button>
                    <Login show={showLogin} onHide={() => setShowLogin(false)} switchToRegister={() => { setShowLogin(false); setShowRegister(true); }} />

                </Form>

                <Tabs defaultActiveKey="hot" className="mt-4">
                    <Tab eventKey="hot" title="Các bình luận">
                        <div style={{ maxHeight: "350px", overflowY: "auto" }}>
                            {comments && comments.map((c, index) => (
                                <Card key={index} className="mt-3 p-3">
                                    <Row>
                                        <Col xs={12}>
                                            <strong>{c.authorNameComment} ({c.timeComment})</strong>
                                            <p className="mt-2">{c.content}</p>
                                            <div>
                                                 <span style={{cursor:"pointer"}} onClick={() => getCommentReply(c.commentId)}>Xem {c.totalCommentReply} phản hồi </span>
                                            </div>
                                            <div className="d-flex text-muted">
                                                <span className="mt-3" style={{ cursor: "pointer", color:"blue" }} onClick={() => {setReplyingTo(index); setFlagReply(true)}}>Trả lời</span>
                                            </div>
                                        </Col>
                                    </Row>
                                    {replyingTo === index && (
                                        <div className="mt-2">
                                            <Form.Control as="textarea" rows={2} placeholder="Nhập câu trả lời..." value={valueContentReply} name="content"
                                            onChange={(e) => setValueContentReply(e.target.value)} />
                                            <Button className="mt-2" size="sm" variant="primary" onClick={() => {handleCommentId(c.commentId, valueContentReply)}}>
                                                Gửi trả lời
                                            </Button>
                                        </div>
                                    )}
                                </Card>
                            ))}
                        </div>
                    </Tab>
                </Tabs>
            </div>
        </>

    );
}

export default DetailArticle
