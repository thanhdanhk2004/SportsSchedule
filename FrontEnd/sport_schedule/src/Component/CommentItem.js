
import { useState } from "react";
import { Form, Button, Card, Row, Col } from "react-bootstrap"

function CommentItem({ comments, getCommentReply, handleCommentId, replyingTo, setReplyingTo, setFlagReply, flagReply, valueContentReply, setValueContentReply, commentsReply, setCommentReply, commentIdExpend, setCommentIdExpend }) {
    return (
        <>
            {comments && comments.map((c, index) => (
                <Card key={index} className="mt-3 p-3">
                    <Row>
                        <Col xs={12}>
                            <strong>{c.authorNameComment} ({c.timeComment})</strong>
                            <p className="mt-2">{c.content}</p>
                            <div>
                                {c.totalCommentReply > 0 && <span style={{ cursor: "pointer" }} onClick={() => getCommentReply(c.commentId)}>Xem {c.totalCommentReply} phản hồi </span>}
                            </div>
                            <div className="d-flex text-muted">
                                <span className="mt-3" style={{ cursor: "pointer", color: "blue" }} onClick={() => { setReplyingTo(c.commentId); setFlagReply(true); setValueContentReply("") }}>Trả lời</span>
                            </div>
                        </Col>
                    </Row>
                    {replyingTo === c.commentId && (
                        <div className="mt-2">
                            <Form.Control as="textarea" rows={2} placeholder="Nhập câu trả lời..." value={valueContentReply} name="content"
                                onChange={(e) => setValueContentReply(e.target.value)} />
                            <Button className="mt-2" size="sm" variant="primary" onClick={() => { handleCommentId(c.commentId, valueContentReply); setValueContentReply("") }}>
                                Gửi trả lời
                            </Button>
                        </div>
                    )}

                    {c.totalCommentReply > 0 && commentIdExpend === c.commentId && commentsReply && (
                        <div className="ms-4 mt-2">
                            {commentsReply.map((r, idx) => (
                                <Card key={idx} className="mt-2 p-2 bg-light">
                                    <Row>
                                        <Col xs={12}>
                                            <strong>{r.authorNameComment} ({r.timeComment})</strong>
                                            <p className="mt-2">{r.content}</p>
                                        </Col>
                                    </Row>
                                </Card>
                            ))}
                        </div>
                    )}
                </Card>
            ))}
        </>
    )
}

export default CommentItem