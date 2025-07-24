import React, { useState } from "react";
import { Modal, Form, Button, Col, Row } from 'react-bootstrap';
import { FaFacebookF, FaGoogle } from 'react-icons/fa';
import api, { endpoints } from "../Services/Apis";
import logo from "../assets/logo_login.jpg"

function Register({ show, onHide, switchToLogin }) {

    const [form, setForm] = useState({ LastName: "", FirstName: "", Username: "", Email: "", Password: "", ConfirPassword: "" })
    const [message, setMassage] = useState("")
    const [errors, setErrors] = useState({LastName: true, FirstName: true, Username: true, Email: true, Password: true, ConfirPassword: true})


    const handle_change = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    }

    function check_email(email){
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
        return re.test(email);
    }

    const handle_submit = async (e) => {
        e.preventDefault()
        setForm({ ...form, [e.target.name]: e.target.value });
        console.log(form)
        try {
            
            const newErrors = {
                LastName: form.LastName !== "",
                FirstName: form.FirstName !== "",
                Username: form.Username !== "",
                Email: form.Email !== "" && check_email(form.Email),
                Password: form.Password !== "",
                ConfirPassword: form.ConfirPassword !== ""
            }

            if(form.Password !== form.ConfirPassword)
            {
                newErrors.Password = false
                newErrors.ConfirPassword = false
            }
            setErrors(newErrors)

            console.log(errors)
            if(errors.LastName === true && errors.FirstName === true && errors.Username === true && errors.Email === true && errors.Password === true && errors.ConfirPassword === true) {
                const res = await api.post(endpoints.register, form)
                if (res.status === 200) {
                    alert("Dang ky thanh cong")
                    switchToLogin()
                }
            }
        } catch (err) {
            setMassage(err.response.data.message)
            console.log(message)
        }
    }

    return (
        <Modal show={show} onHide={onHide} centered size="lg">
            <Modal.Body>
                <div className="container login-container">
                    <div className="row">
                        <div className="col-md-6 login-form">
                            <div className="d-flex justify-content-center align-items-center"><h4 className="mb-4">Đăng ký</h4></div>
                            <div><p className="text-danger">{message}</p></div>
                            <Form onSubmit={handle_submit}>
                                <Row className="mb-3">
                                    <Col md={6}>
                                        <Form.Group controlId="formLastname">
                                            <Form.Control className={errors.LastName === false ? "is-invalid" : ""} onChange={handle_change} name="LastName" type="text" placeholder="Họ" />
                                        </Form.Group>
                                    </Col>

                                    <Col md={6}>
                                        <Form.Group controlId="formFirstname">
                                            <Form.Control className={errors.FirstName === false ? "is-invalid": ""} onChange={handle_change} name="FirstName" type="text" placeholder="Tên" />
                                        </Form.Group>
                                    </Col>
                                </Row>

                                <Form.Group className="mb-3" controlId="formUsername">
                                    <Form.Control className={errors.Username === false ? "is-invalid": ""} onChange={handle_change} name="Username" type="username" placeholder="Tên đăng nhập" />
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formEmail">
                                    <Form.Control className={errors.Email === false ? "is-invalid": ""} onChange={handle_change} name="Email" type="email" placeholder="Email" />
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formPassword">
                                    <Form.Control className={errors.Password === false ? "is-invalid": ""} onChange={handle_change} name="Password" type="password" placeholder="Mật khẩu" />
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formConfirPassword">
                                    <Form.Control className={errors.ConfirPassword === false ? "is-invalid": ""} onChange={handle_change} name="ConfirPassword" type="Password" placeholder="Xác nhận mật khẩu" />
                                </Form.Group>

                                <div className="d-grid mb-3">
                                    <Button type="submit" variant="primary">
                                        Đăng ký
                                    </Button>
                                </div>


                            </Form>

                            <div className="d-flex justify-content-center">
                                <p>Bạn đã có tài khoản?  
                                    <span className="color-link pointer" onClick={switchToLogin}> Đăng nhập</span>                                   
                                </p>
                            </div>
                            <div className="d-flex align-items-center my-3">
                                <hr className="flex-grow-1" />
                                <span className="mx-2 text-muted">Hoặc</span>
                                <hr className="flex-grow-1" />
                            </div>
                            <div className="d-grid gap-2">
                                <Button variant="danger" className="d-flex align-items-center justify-content-center gap-2">
                                    <FaGoogle /> Đăng nhập với Google
                                </Button>

                                <Button variant="primary" className="d-flex align-items-center justify-content-center gap-2" style={{ backgroundColor: '#3b5998' }}>
                                    <FaFacebookF /> Đăng nhập với Facebook
                                </Button>
                            </div>
                        </div>

                        <div className="col-md-1 d-flex justify-content-center">
                            <div style={{ borderLeft: "1px solid #ccc", height: "100%" }}></div>
                        </div>

                        <div className="col-md-5 illustration d-flex flex-column justify-content-center align-items-center">
                            <img src={logo} alt="Bóng đá minh họa" />
                        </div>
                    </div>

                </div>

            </Modal.Body>
        </Modal>
    );
}

export default Register;