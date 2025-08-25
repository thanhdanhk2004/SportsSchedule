import { ca } from "date-fns/locale";
import { useEffect, useState } from "react";
import { Modal, Form, Button } from "react-bootstrap";
import { authApis, endpoints } from "../../Services/Apis";
import Select from "react-select";
import { use } from "react";


function ModalUpdateRole({ show, onHide, role}) {
    const [roleName, setRoleName] = useState("");

    const handleUpdateRole = async () => {
        try {
            const res = await authApis().patch(`${endpoints.updateRole(role.roleId)}?roleName=${roleName}`);
            if (res.status === 200) {
                alert("Cập nhật thành công");
                onHide();
            }
        } catch (err) {
            console.log(err);
        }
    };

    useEffect(() => {
        if(role){
            setRoleName(role.roleName)
        }
    },[role])
    
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
                <Button variant="primary" onClick={handleUpdateRole}>
                    Cập nhật
                </Button>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalUpdateRole;