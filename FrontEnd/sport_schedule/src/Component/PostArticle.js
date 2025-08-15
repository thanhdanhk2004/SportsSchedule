import { useState } from "react";
import { authApis, endpoints} from '../Services/Apis'
import { useNavigate } from "react-router-dom";

const Article = () => {
    const [formData, setFormData] = useState({title: "",description: "",imageUrl: "", status:"Chờ duyệt"});
    const navigate = useNavigate()

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
                imageUrl: result.secure_url,
            }));
            console.log(formData)
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
                alert("Dang bai thanh cong")
                navigate("/")
            }
        }catch(err){
            console.log(err)
        }
    };

    return (
        <div className="container mt-4">
            <h2>Đăng bài viết mới</h2>
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label className="form-label">Tiêu đề</label>
                    <input type="text" name="title" className="form-control" value={formData.title} onChange={handleChange} required/>
                </div>

                <div className="mb-3">
                    <label className="form-label">Nội dung</label>
                    <textarea id="description" name="description" className="form-control" onChange={handleChange}></textarea>
                </div>

                <div className="mb-3">
                    <label className="form-label">Hình ảnh</label>
                    <input type="file" className="form-control" onChange={handleImageUpload} accept="image/*"/>
                </div>

                {formData.imageUrl && (
                    <div className="mb-3">
                        <img src={formData.imageUrl} alt="Preview" style={{ maxWidth: "200px" }} />
                    </div>
                )}

                <button type="submit" className="btn btn-primary">
                    Đăng bài
                </button>
            </form>
        </div>
    );
};


export default Article