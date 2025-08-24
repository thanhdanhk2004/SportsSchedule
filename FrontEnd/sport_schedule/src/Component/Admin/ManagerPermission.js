import { useEffect, useState } from "react";
import { endpoints, authApis } from "../../Services/Apis";
import { Table } from "react-bootstrap";
import ModalAddPermission from "./ModalAddPermission";
import ModalUpdatePermission from "./ModalUpdatePermission";

const ManagerPermission = () => {
    const [permissions, setPermissions] = useState([]);
    const [showModal, setShowModal] = useState(false);
    const [showModalUpdate, setShowModalUpdate] = useState(false);
    const [permissionExiste, setPermissionExiste] = useState(null);

    const getPermissions = async () => {
        try {
            var res = await authApis().get(endpoints.getPermissions)
            setPermissions(res.data)
        } catch (error) {
            console.log(error)
        }
    }

    const handleDelete = async (permissionId) => {
        try {
            if (window.confirm("Bạn có chắc chắn muốn xóa không?")) {
                var res = await authApis().delete(endpoints.deletePermission(permissionId))
                if (res.status === 200) {
                    alert("Xóa thành công")
                    getPermissions()
                }
            }
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(() => {
        getPermissions()
    }, [])

    return (
        <>

            <div>
                <div className="text-center mt-4">
                    <h3>Quản lý vai trò</h3>
                </div>
                <div>
                    <button className="btn btn-success" style={{ marginBottom: "-20px", marginLeft: "100px" }} onClick={() => setShowModal(true)}>Thêm permission</button>
                </div>
                <div className="mt-5 mx-5" style={{ marginBottom: "200px" }}>
                    <Table className="" style={{ marginLeft: "50px", width: "1350px" }} bordered hover>
                        <thead className="text-center">
                            <tr>
                                <th>STT</th>

                                <th>Permission name</th>
                                <th>Role name</th>
                                <td style={{ width: "300px" }}>Chức năng</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                permissions && permissions.map((permission, index) => (
                                    <tr>
                                        <td className="text-center">{index + 1}</td>
                                        <td className="text-center">{permission.permissionName}</td>
                                        <td className="text-center">{permission.roleName}</td>
                                        <td>
                                            <button className="btn btn-danger mx-3" onClick={() => handleDelete(permission.permissionId)}>Delete</button>
                                            <button className="btn btn-primary" onClick={() => {setPermissionExiste(permission); setShowModalUpdate(true)}}>Update</button>
                                            
                                        </td>
                                    </tr>
                                ))
                            }
                            <ModalAddPermission show={showModal} onHide={() => {setShowModal(false); getPermissions()}} />
                            <ModalUpdatePermission show={showModalUpdate} onHide={() => {setShowModalUpdate(false); getPermissions()}} permissionExiste={permissionExiste} />
                        </tbody>
                    </Table>

                </div>
            </div>
        </>
    );
};

export default ManagerPermission;
