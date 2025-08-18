import { useEffect, useState } from "react";
import { Modal, Button } from "react-bootstrap";
import { endpoints, authApis } from "../Services/Apis";

function UpdateArticle({ show, handleClose, article }) {
    const [data, setData] = useState({ articleId: -1, title: "", description: "", image: "" })

    const handleChange = (e) => {
        setData({ ...data, [e.target.name]: e.target.value })
    }

    const handleImageUpload = async (e) => {
        const file = e.target.files[0];
        if (!file)
            return;

        const data = new FormData();
        data.append("file", file);
        data.append("upload_preset", "thanhdan");
        data.append("cloud_name", "diqway3wn");

        try {
            const res = await fetch(`https://api.cloudinary.com/v1_1/diqway3wn/image/upload`, {
                method: "POST",
                body: data,
            });
            const result = await res.json();
            setData((prev) => ({
                ...prev,
                image: result.secure_url,
            }));
        } catch (err) {
            console.error("Upload failed", err);
        }
    };

    const handleUpdate = async () => {
        try {
            var res = await authApis().put(endpoints.updateArticle(article.articleId), data)
            if (res.status === 200){
                alert("Cap nhat thanh cong")
                handleClose()
            }
        } catch (err) {
            console.log(err)
        }
    }

    useEffect(() => {
        if (article) {
            setData({
                articleId: article.articleId, title: article.title, description: article.description, image: article.image
            })
        }
    }, [article])

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Modal.Header closeButton>
                <Modal.Title>Đăng bài thành công 🎉</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="mb-3">
                    <label className="form-label">Tiêu đề bài viết</label>
                    <input type="text" name="title" className="form-control" value={data && data.title} onChange={handleChange} required />
                </div>

                <div className="mb-3">
                    <label className="form-label">Nội dung bài viết</label>
                    <textarea id="description" name="description" className="form-control" value={data && data.description} onChange={handleChange} required></textarea>
                </div>
                <div className="mb-3">
                    <label className="form-label">Hình ảnh đại diện bài viết</label>
                    <input type="file" className="form-control" accept="image/*" onChange={handleImageUpload} required />
                </div>

                {data && (
                    <div className="mb-3">
                        <img src={data.image} alt="Preview" style={{ maxWidth: "200px" }} />
                    </div>
                )}
            </Modal.Body>
            <Modal.Footer>
                <div className="d-flex">
                    <div>
                        <Button variant="primary" className="mx-3" onClick={handleUpdate}>Update</Button>
                    </div>
                    <div>
                        <Button variant="danger" onClick={handleClose}>Cancel</Button>
                    </div>
                </div>
            </Modal.Footer>
        </Modal>
    );
}

export default UpdateArticle