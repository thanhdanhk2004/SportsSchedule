import React from "react";

import { Container, Form, Button} from 'react-bootstrap';
import { FaFacebookF, FaGoogle } from 'react-icons/fa';

const Login = () => {
    return (
        <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: '100vh' }}>
            <div className="p-5 rounded shadow" style={{ maxWidth: 400, width: '100%', background: 'white' }}>
                <h3 className="text-center mb-4">Đăng nhập</h3>

                <Form>
                    <Form.Group className="mb-3" controlId="formEmail">
                        <Form.Control type="email" placeholder="Email" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formPassword">
                        <Form.Control type="password" placeholder="Password" />
                    </Form.Group>

                    <Form.Group className="mb-3 d-flex align-items-center">
                        <Form.Check type="checkbox" label="Remember password" />
                    </Form.Group>

                    <div className="d-grid mb-3">
                        <Button variant="primary" size="lg">
                            LOGIN
                        </Button>
                    </div>

                    <hr />

                    <div className="d-grid gap-2">
                        <Button variant="danger" size="lg" className="d-flex align-items-center justify-content-center gap-2">
                            <FaGoogle /> SIGN IN WITH GOOGLE
                        </Button>

                        <Button variant="primary" size="lg" className="d-flex align-items-center justify-content-center gap-2" style={{ backgroundColor: '#3b5998' }}>
                            <FaFacebookF /> SIGN IN WITH FACEBOOK
                        </Button>
                    </div>
                </Form>

            </div>
        </Container>
    );
}

export default Login;