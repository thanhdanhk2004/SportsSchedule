import { useState } from "react";
import { authApis, endpoints} from '../Services/Apis'
import { useNavigate } from "react-router-dom";
import AcceptModal from "./AcceptModal"

const Article = () => {
    const [formData, setFormData] = useState({title: "",description: "",image: "", status:"Chờ duyệt"});
    const navigate = useNavigate()
    const [showModal, setShowModal] = useState(false)

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
            setFormData((prev) => ({
                ...prev,
                image: result.secure_url,
            }));
        } catch (err) {
            console.error("Upload failed", err);
        }
    };

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try{
            
            const res = await authApis().post(endpoints.postArticle, formData)
            if(res.status === 200)
            {
                setShowModal(true)
            }
        }catch(err){
            console.log(err)
        }
    };

    return (
        <div className="container mt-4">
            <h2 className="text-center">Đăng bài viết mới</h2>
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label className="form-label">Tiêu đề bài viết</label>
                    <input type="text" name="title" className="form-control" value={formData.title} onChange={handleChange} required/>
                </div>

                <div className="mb-3">
                    <label className="form-label">Nội dung bài viết</label>
                    <textarea id="description" name="description" className="form-control" onChange={handleChange} required></textarea>
                </div>
                <div className="mb-3">
                    <label className="form-label">Hình ảnh đại diện bài viết</label>
                    <input type="file" className="form-control" onChange={handleImageUpload} accept="image/*" required/>
                </div>

                {formData.image && (
                    <div className="mb-3">
                        <img src={formData.image} alt="Preview" style={{ maxWidth: "200px" }} />
                    </div>
                )}

                <button type="submit" className="btn btn-primary">
                    Đăng bài
                </button>
                <AcceptModal show={showModal} handleClose={() => {setShowModal(false); navigate("/")}}/>
            </form>
        </div>
    );
};


export default Article