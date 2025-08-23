import { ca } from "date-fns/locale";
import { useEffect, useState } from "react";
import { Modal, Form, Button } from "react-bootstrap";
import { authApis, endpoints } from "../../Services/Apis";

function ModalUpdateUser({ show, onHide, onSubmit, User }) {
  const [form, setForm] = useState({
    userId: User && User.userId,
    firstName: User && User.firstName,
    lastName: User && User.lastName,
    userName: User && User.userName,
    password: User && User.password,
    email: User && User.email,
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm(prev => ({ ...prev, [name]: value }));
  };

  const handleSave = async (e) => {
    e.preventDefault();
    try{
        const res = await authApis().put(endpoints.updateUser, form);
        if(res.status === 200){
            alert("Cập nhật người dùng thành công");
            onHide();
        }
    }catch(err){
      console.log(err);
    }
  };

  useEffect(() => {
    setForm({
      userId: User && User.userId,
      firstName: User && User.firstName,
      lastName: User && User.lastName,
      userName: User && User.userName,
      password: User && User.password,
      email: User && User.email,
    });
  }, [User]);

  return (
    <Modal show={show} onHide={onHide} centered>
      <Form onSubmit={handleSave}>
        <Modal.Header closeButton>
          <Modal.Title>Thêm người dùng</Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <Form.Group className="mb-3">
            <Form.Label>First name</Form.Label>
            <Form.Control name="firstName" value={form.firstName} onChange={handleChange} placeholder="Nhập first name" required />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Last name</Form.Label>
            <Form.Control name="lastName" value={form.lastName} onChange={handleChange} placeholder="Nhập last name" required />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>User name</Form.Label>
            <Form.Control name="userName" value={form.userName} onChange={handleChange} placeholder="Nhập user name" required />
          </Form.Group>

          <Form.Group className="mb-3">
            <Form.Label>Mật khẩu</Form.Label>
            <Form.Control type="password" name="password" value={form.password} onChange={handleChange} placeholder="Nhập mật khẩu" required minLength={6} />
          </Form.Group>

          <Form.Group>
            <Form.Label>Email</Form.Label>
            <Form.Control type="email" name="email" value={form.email} onChange={handleChange} placeholder="vd: name@example.com" required />
          </Form.Group>
        </Modal.Body>

        <Modal.Footer>
          <Button variant="secondary" onClick={onHide}>
            Hủy
          </Button>
          <Button type="submit" variant="primary">
            Lưu
          </Button>
        </Modal.Footer>
      </Form>
    </Modal>
  );
}

export default ModalUpdateUser;