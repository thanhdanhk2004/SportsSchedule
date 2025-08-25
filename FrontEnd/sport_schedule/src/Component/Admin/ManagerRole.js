import { useEffect, useState } from "react";
import { Table } from "react-bootstrap";
import { endpoints, authApis } from "../../Services/Apis";
import ModalAddRole from "./ModalAddRole";
import ModalUpdateRole from "./ModalUpdateRole";

const ManagerRole = () => {
    const [roles, setRoles] = useState();
    const [showModalAddRole, setShowModalAddRole] = useState(false);
    const [showModalUpdateRole, setShowModalUpdateRole] = useState(false);
    const [selectedRole, setSelectedRole] = useState();

    const getRoles = async () => {
        try {
            const response = await authApis().get(endpoints.getRoles);
            if (response.status === 200) {
                setRoles(response.data);
            }
        } catch (error) {
            console.error("Failed to fetch roles:", error);
        }
    }

    const handleDeleteRole = async (roleId) => {
        try {
            if (window.confirm("Bạn có chắc chắn muốn xóa vai trò này?")) {
                var res = await authApis().delete(endpoints.deleteRole(roleId));
                if (res.status === 200) {
                    alert("Xóa thành công");
                    getRoles();
                }
            }
        } catch (err) {
            console.log(err);

        }
    }


    useEffect(() => {
        getRoles();
    }, []);

    return (
        <>
            <div>
                <div className="text-center mt-4">
                    <h3>Quản lý vai trò</h3>
                </div>
                <div>
                    <button className="btn btn-success" style={{ marginBottom: "-20px", marginLeft: "100px" }} onClick={() => setShowModalAddRole(true)}>Thêm role</button>
                </div>
                <div className="mt-5 mx-5" style={{ marginBottom: "200px" }}>
                    <Table className="" style={{ marginLeft: "50px", width: "1350px" }} bordered hover>
                        <thead className="text-center">
                            <tr>
                                <th>STT</th>
                                <th>Role name</th>
                                <td style={{ width: "300px" }}>Chức năng</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                roles && roles.map((role, index) => (
                                    role && role.roleName !== "Admin" &&
                                    <tr>
                                        <td className="text-center">{index + 1}</td>
                                        <td className="text-center">{role.roleName}</td>
                                        <td>
                                            <button className="btn btn-danger mx-3" onClick={() => handleDeleteRole(role.roleId)}>Delete</button>
                                            <button className="btn btn-primary" onClick={() => { setSelectedRole(role); setShowModalUpdateRole(true); }}>Update</button>
                                        </td>
                                    </tr>
                                ))
                            }
                            <ModalAddRole show={showModalAddRole} onHide={() => { setShowModalAddRole(false); getRoles() }} />
                            <ModalUpdateRole show={showModalUpdateRole} onHide={() => { setShowModalUpdateRole(false); getRoles() }} role={selectedRole} />
                        </tbody>
                    </Table>

                </div>
            </div>
        </>
    )
}

export default ManagerRole;