import React, { useState } from "react";
import { Modal, Form, Button } from 'react-bootstrap';
import { FaFacebookF, FaGoogle } from 'react-icons/fa';
import api, { endpoints } from "../Services/Apis";
import { useNavigate } from "react-router-dom";
import { Cookies } from "react-cookie";
import '../Style/index.css'
import logo_login from '../assets/logo_login.jpg'

function Login({ show, onHide, switchToRegister}) {
    const [user, setUser] = useState({ Username: "", Password: "" })
    const [mge, setMassage] = useState("")
    const navigate = useNavigate()
    const cookies = new Cookies()


    const change_handle = (e) => {
        setUser({ ...user, [e.target.name]: e.target.value })
    }

    const login_handle = async (e) => {
        e.preventDefault()
        try {
            if (user.Username === "")
                setMassage("Tên đăng nhập không được rỗng")
            else if (user.Password === "") {
                setMassage("Mật khẩu không được rỗng")
            } else {
                const res = await api.post(endpoints.login, user)
                if (res.status === 200) {
                    cookies.set("token", res.data.user.token, { path: "/" });
                    navigate("/")
                }
            }
        } catch (err) {
            setMassage("Tên đăng nhập hoặc mật khẩu không chính xác")
        }
    }


    return (
        <Modal show={show} onHide={onHide} centered size="lg">
            <Modal.Body>
                <div className="container login-container w-100">
                    <div className="row">
                        <div className="col-md-6 login-form">
                            <div className="d-flex justify-content-center align-items-center"><h4 className="mb-4">Đăng nhập</h4></div>
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

                                <div className="d-flex justify-content-center">
                                    <p>Bạn chưa có tài khoản? <a onClick={switchToRegister} className="color-link pointer">Đăng ký</a></p>
                                </div>

                                <div className="d-flex align-items-center my-3">
                                    <hr className="flex-grow-1" />
                                    <span className="mx-2 text-muted">Hoặc</span>
                                    <hr className="flex-grow-1" />
                                </div>

                                <div className="d-grid gap-2">
                                    <Button variant="danger" className="d-flex align-items-center justify-content-center gap-2">
                                        <FaGoogle /> Đăng nhập bằng Google
                                    </Button>

                                    <Button variant="primary" className="d-flex align-items-center justify-content-center gap-2" style={{ backgroundColor: '#3b5998' }}>
                                        <FaFacebookF /> Đăng nhập bằng Facebook
                                    </Button>
                                </div>
                            </Form>
                        </div>

                        <div className="col-md-1 d-flex justify-content-center">
                            <div style={{ borderLeft: "1px solid #ccc", height: "100%" }}></div>
                        </div>

                        <div className="col-md-5 illustration d-flex flex-column justify-content-center align-items-center">
                            <img src={logo_login} alt="Bóng đá minh họa"/>
                            
                        </div>
                    </div>

                </div>

            </Modal.Body>
        </Modal>
    );
}

export default Login;