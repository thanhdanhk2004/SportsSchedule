import React, { useState } from "react";
import { Modal, Form, Button } from 'react-bootstrap';
import { FaFacebookF } from 'react-icons/fa';
import api, { endpoints } from "../Services/Apis";
import '../Style/index.css'
import logo_login from '../assets/logo_login.jpg'
import { AuthContext } from "../Context/AuthContext";
import { useContext } from "react";
import { GoogleLogin, GoogleOAuthProvider } from "@react-oauth/google";
import { jwtDecode } from "jwt-decode"; //thu vien de giai ma jwt
import { useNavigate } from "react-router-dom";


function Login({ show, onHide, switchToRegister, onLoginSuccess }) {
    const [user, setUser] = useState({ Username: "", Password: "" })
    const [message, setMessage] = useState("")
    const [errors, setErrors] = useState({ Username: true, Password: true })
    const { login } = useContext(AuthContext);
    const Client_ID = process.env.REACT_APP_Client_ID;
    const navigate = useNavigate();

    const change_handle = (e) => {
        setUser({ ...user, [e.target.name]: e.target.value })
    }

    const login_handle = async (e) => {
        e.preventDefault()
        try {
            const newErrors = {
                Username: user.Username !== "",
                Password: user.Password !== ""
            }

            setErrors(newErrors)

            if (user.Username !== "" && user.Password !== "") {
                const res = await api.post(endpoints.login, user)
                if (res.status === 200) {
                    login(res.data.user.token)
                    if (onLoginSuccess) 
                        onLoginSuccess()
                    const decode = jwtDecode(res.data.user.token);
                    const userRole = decode.role || decode["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                    if (userRole === "Admin") {
                        navigate('/admin/users');
                    }
                    onHide()
                }
            }
        } catch (err) {
            console.log(err)
            setMessage("Tên đăng nhập hoặc mật khẩu không đúng")
        }
    }


    /*Login google*/
    const handleLoginSuccess = async (credentialResponse) => {
        const token = credentialResponse.credential;
        const userInfo = jwtDecode(token);

        const newUser = {
            LastName: userInfo.family_name,
            FirstName: userInfo.given_name,
            Email: userInfo.email,
            Username: userInfo.email,
            Password: "123456",
            ConfirmPassword: "123456"
        };

        try {
            const resRegister = await api.post(endpoints.register, newUser);
            if (resRegister.status === 200) {
                const userLogin = {
                    Username: userInfo.email,
                    Password: "123456"
                };

                const resLogin = await api.post(endpoints.login, userLogin);

                if (resLogin.status === 200) {
                    login(resLogin.data.user.token);
                    onLoginSuccess();
                    onHide();
                }
            }
        } catch (error) {
            const userLogin = {
                Username: userInfo.email,
                Password: "123456"
            };

            try {
                const resLogin = await api.post(endpoints.login, userLogin);
                if (resLogin.status === 200) {
                    login(resLogin.data.user.token);
                    onLoginSuccess();
                    onHide();
                }
            } catch (err) {
                console.log("Login failed:", err);
            }
        }
    };


    // Hàm xử lý khi đăng nhập thất bại
    const handleLoginError = () => {
        console.log("Hello")
        console.log(Client_ID)
        console.log("Đăng nhập Google thất bại!");
        alert("Đăng nhập Google thất bại, vui lòng thử lại!");
    };


    return (
        <Modal show={show} onHide={onHide} centered size="lg">
            <Modal.Body>
                <div className="container login-container w-100">
                    <div className="row">
                        <div className="col-md-6 login-form">
                            <div className="d-flex justify-content-center align-items-center"><h4 className="mb-4">Đăng nhập</h4></div>
                            <div><p className="text-danger">{message}</p></div>
                            <Form onSubmit={login_handle} name="formLogin">
                                <Form.Group className="mb-3" controlId="formUserName">
                                    <Form.Control className={errors.Username === false ? "is-invalid" : ""} onChange={change_handle} name="Username" type="username" placeholder="Tên đăng nhập" />
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formPassword">
                                    <Form.Control className={errors.Username === false ? "is-invalid" : ""} onChange={change_handle} name="Password" type="password" placeholder="Mật khẩu" />
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
                                    <p>Bạn chưa có tài khoản? <span onClick={switchToRegister} className="color-link pointer">Đăng ký</span></p>
                                </div>

                                <div className="d-flex align-items-center my-3">
                                    <hr className="flex-grow-1" />
                                    <span className="mx-2 text-muted">Hoặc</span>
                                    <hr className="flex-grow-1" />
                                </div>

                                <div className="d-grid gap-2">
                                    <GoogleOAuthProvider clientId={Client_ID}>
                                        <GoogleLogin
                                            onSuccess={handleLoginSuccess}
                                            onError={handleLoginError}
                                        />
                                    </GoogleOAuthProvider>

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
                            <img src={logo_login} alt="Bóng đá minh họa" />

                        </div>
                    </div>

                </div>

            </Modal.Body>
        </Modal>
    );
}

export default Login;