import { endpoints, authApis } from "../../Services/Apis";
import React, { useEffect, useState } from "react";
import { Table } from "react-bootstrap";
import ModalUpdateUser from "./ModalUpdateUser";

const ManagerUser = () => {
    const [users, setUsers] = useState();
    const [showModal, setShowModal] = useState(false);
    const [userUpdateSelected, setUserUpdateSelected] = useState(null);

    const getUsers = async () => {
        try {
            const response = await authApis().get(endpoints.getUsers);
            setUsers(response.data);
        } catch (error) {
            console.log(error);
        }
    }

    //Xoa user
    const handleDeleteUser = async (userId) => {
        if (window.confirm("Bạn có chắc chắn muốn xóa user này không?")) {
            try {
                const res = await authApis().delete(endpoints.deleteUser(userId));
                if (res.status === 200) {
                    alert("Xóa người dùng thành công");
                    getUsers();
                }
            } catch (err) {
                console.log(err);
            }
        }
    }

    //Xu ly update user
    const handleUpdateUser = (user) => {
        setShowModal(true);
        setUserUpdateSelected(user);
    }

    useEffect(() => {
        getUsers();
    }, [])

    return (
        <>
            <div>
                <div className="text-center mt-4">
                    <h3>Quản lý người dùng</h3>
                </div>
                <div className="mt-5 mx-5" style={{ marginBottom: "200px" }}>
                    <Table className="" style={{ marginLeft: "50px", width: "1350px" }} bordered hover>
                        <thead className="text-center">
                            <tr>
                                <th>STT</th>
                                <th>First name</th>
                                <th>Last name</th>
                                <th>User name</th>
                                <th>Mật khẩu</th>
                                <th>Email</th>
                                <th>Vai trò</th>
                                <td style={{ width: "300px" }}>Chức năng</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                users && users.map((user, index) => (
                                    <tr>
                                        <td className="text-center">{index + 1}</td>
                                        <td>{user.lastName}</td>
                                        <td>{user.firstName}</td>
                                        <td>{user.userName}</td>
                                        <td>{user.password}</td>
                                        <td>{user.email}</td>
                                        <td>{user.roleName}</td>
                                        <td>
                                            <button className="btn btn-danger mx-3" onClick={() => handleDeleteUser(user.userId)}>Delete</button>
                                            <button className="btn btn-primary"  onClick={() => handleUpdateUser(user)}>Update</button>
                                        </td>
                                    </tr>
                                ))                             
                            }
                        <ModalUpdateUser show={showModal} onHide={() => {setShowModal(false); getUsers()}} onSubmit={handleUpdateUser} User={userUpdateSelected} />
                        </tbody>
                    </Table>

                </div>
            </div>
        </>
    );
};

export default ManagerUser;
