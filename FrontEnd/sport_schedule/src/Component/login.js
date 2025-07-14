import React, { useState } from "react";
import { Container, Form, Button} from 'react-bootstrap';
import { FaFacebookF, FaGoogle } from 'react-icons/fa';
import api, { endpoints } from "../Services/Apis";
import { useNavigate } from "react-router-dom";
import { Cookies } from "react-cookie";

const Login = () => {
    const [user, setUser] = useState({Username:"", Password:""})
    const [mge, setMassage] = useState("")
    const navigate = useNavigate()
    const cookies = new Cookies()

    const change_handle = (e) =>{
        setUser({...user, [e.target.name] : e.target.value})
    }

    const login_handle = async (e) =>{
        e.preventDefault()
        try{
            if(user.Username === "")
                setMassage("Tên đăng nhập không được rỗng")
            else if(user.Password === ""){
                setMassage("Mật khẩu không được rỗng")
            }else{
                const res = await api.post(endpoints.login, user)
                if(res.status === 200){
                    alert(res.data.message)
                    cookies.set("token", res.data.user.token, { path: "/" });
                    navigate("/")
                }
            }
        }catch(err){
            setMassage("Tên đăng nhập hoặc mật khẩu không chính xác")
        }
    }


    return (
        <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
            <div className="p-5 rounded shadow" style={{ maxWidth: 400, width: '100%', background: 'white' }}>
                <h3 className="text-center mb-4">Đăng nhập</h3>
                <p className="text-danger">{mge}</p>
                <Form onSubmit={login_handle}>
                    <Form.Group className="mb-3" controlId="formUserName">
                        <Form.Control onChange={change_handle} name="Username" type="username" placeholder="Tên đăng nhập" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formPassword">
                        <Form.Control onChange={change_handle} name="Password" type="password" placeholder="Mật khẩu" />
                    </Form.Group>

                    <Form.Group className="mb-3 d-flex align-items-center">
                        <Form.Check type="checkbox" label="Quên mật khẩu" />
                    </Form.Group>

                    <div className="d-grid mb-3">
                        <Button type="submit" variant="primary">
                            Đăng nhập
                        </Button>
                    </div>

                    <hr />

                    <div className="d-grid gap-2">
                        <Button variant="danger" className="d-flex align-items-center justify-content-center gap-2">
                            <FaGoogle /> SIGN IN WITH GOOGLE
                        </Button>

                        <Button variant="primary" className="d-flex align-items-center justify-content-center gap-2" style={{ backgroundColor: '#3b5998' }}>
                            <FaFacebookF /> SIGN IN WITH FACEBOOK
                        </Button>
                    </div>
                </Form>

            </div>
        </Container>
    );
}

export default Login;