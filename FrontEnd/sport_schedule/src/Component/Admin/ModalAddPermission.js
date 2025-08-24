import { ca } from "date-fns/locale";
import { useEffect, useState } from "react";
import { Modal, Form, Button } from "react-bootstrap";
import { authApis, endpoints } from "../../Services/Apis";
import Select from "react-select";
import { use } from "react";


function ModalAddPermission({ show, onHide}) {
    const [selectedOptions, setSelectedOptions] = useState([]);
    const [rolesOptions, setRolesOptions] = useState([]);
    const [permission, setPermission] = useState({ permissionName: "", ListRoleId: [] });

    const getRoles = async () => {
        try{
            var res = await authApis().get(endpoints.getRoles);
            setRolesOptions(res.data.map(role => ({ value: role.roleId, label: role.roleName })));
        }catch(err){
            console.log(err);
        }   
    }

    const handleChange = (e) => {
        const { name, value } = e.target;
        setPermission(prev =>({
            ...prev,
            [name]: value
        }))

    };

    const handleSelectChange = (selected) =>{
        setSelectedOptions(selected);
        setPermission(prev => ({
            ...prev,
            ListRoleId: selected.map(option => option.value)
        }))
    }

    const handleAddPermission = async (e) => {
        e.preventDefault();
        try {
            const res = await authApis().post(endpoints.addPermission, permission);
            if (res.status === 200) {
                alert("Thêm thành công");
                onHide();
            }

        } catch (err) {
            console.log(err);
        }
    };


    useEffect(() => {
        getRoles();
    }, []);

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title>Nhập thông tin permission</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group className="mb-3">
                        <Form.Label>Nhập tên permission</Form.Label>
                        <Form.Control type="text" name="permissionName" placeholder="Nhập vào đây..." value={permission.permissionName} required
                            onChange={(e) => handleChange(e)}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3">
                        <Form.Label>Chọn nhiều mục</Form.Label>
                        <Select
                            isMulti
                            options={rolesOptions}
                            value={selectedOptions}
                            onChange={(selected) => handleSelectChange(selected)}
                            placeholder="Chọn role cho quyền này..."
                        />
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onHide}>
                    Đóng
                </Button>
                <Button variant="primary" onClick={handleAddPermission}>
                    Thêm
                </Button>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalAddPermission;