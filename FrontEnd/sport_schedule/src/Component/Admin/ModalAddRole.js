import { Modal, Form, Button } from "react-bootstrap";
import { useState } from "react";
import { authApis, endpoints } from "../../Services/Apis";

function ModalAddRole({ show, onHide }){
    const [roleName, setRoleName] = useState("");

    const handleAddRole = async () =>{
        try{
            const res = await authApis().post(`${endpoints.addRole}?roleName=${roleName}`)
            if(res.status === 200){
                alert("Thêm thành công");
                onHide();
            }
        }catch(err){
            console.error("Failed to add role:", err);
        }
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title>Nhập thông tin role</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group className="mb-3">
                        <Form.Label>Nhập tên role</Form.Label>
                        <Form.Control type="text" name="roleName" placeholder="Nhập vào đây..."  required
                            onChange={(e) => setRoleName(e.target.value)} value={roleName}
                        />
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onHide}>
                    Đóng
                </Button>
                <Button variant="primary" onClick={handleAddRole}>
                    Thêm
                </Button>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalAddRole;