import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom"
import { Container, Form, Button, Col, Row } from 'react-bootstrap';
import { FaFacebookF, FaGoogle } from 'react-icons/fa';
import api, { endpoints } from "../Services/Apis";

const Register = () => {

    const [form, setForm] = useState({LastName:"", FirstName:"", Username:"", Email:"", Password:"", ConfirPassword:""})
    const [massage, setMassage] = useState("")
    const navigate = useNavigate();

    const handle_change = (e) =>{
        setForm({ ...form, [e.target.name]: e.target.value });
    }
    const handle_submit = async (e) =>{
        e.preventDefault()
        try{
            if(form.Password !== form.ConfirPassword)
                alert("Mat khau khong trung khop")
            else{
                const res = await api.post(endpoints.register, form)
                if(res.status === 200){
                    alert("Dang ky thanh cong")
                    
                    navigate("/login")
                }
            }
        }catch(err){
            setMassage(err.response.data.message)
        }
    }

    return (
        <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
            <div className="p-5 rounded shadow" style={{ maxWidth: 400, width: '100%', background: 'white' }}>
                <h3 className="text-center mb-4">Đăng ký</h3>
                <p className="text-danger">{massage}</p>
                <Form onSubmit={handle_submit}>
                    <Row className="mb-3">
                        <Col md={6}>
                            <Form.Group controlId="formLastname">
                                <Form.Control onChange={handle_change} name="LastName" type="text" placeholder="Họ" />
                            </Form.Group>
                        </Col>

                        <Col md={6}>
                            <Form.Group controlId="formFirstname">
                                <Form.Control onChange={handle_change} name="FirstName" type="text" placeholder="Tên" />
                            </Form.Group>
                        </Col>
                    </Row>

                    <Form.Group className="mb-3" controlId="formUsername">
                        <Form.Control onChange={handle_change} name="Username" type="username" placeholder="Tên đăng nhập" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formEmail">
                        <Form.Control onChange={handle_change} name="Email" type="email" placeholder="Email" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formPassword">
                        <Form.Control onChange={handle_change} name="Password" type="password" placeholder="Mật khẩu" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formConfirPassword">
                        <Form.Control onChange={handle_change} name="ConfirPassword" type="Password" placeholder="Xác nhận mật khẩu" />
                    </Form.Group>

                    <div className="d-grid mb-3">
                        <Button type="submit" variant="primary">
                            Đăng ký
                        </Button>
                    </div>

                    <div className="d-flex justify-content-center">
                        <p>Bạn đã có tài khoản? <Link to="/login" className="">Đăng nhập</Link></p>
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
                </Form>

            </div>
        </Container>
    );
}

export default Register;