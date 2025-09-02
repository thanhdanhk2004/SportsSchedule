import React, { useContext, useState } from "react";
import { Navbar, Nav, Container } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import logo from '../../assets/logo.jpg';
import Login from "../Login"
import Register from "../Register";
import { AuthContext } from "../../Context/AuthContext";


const Header = () => {

  const [showLogin, setShowLogin] = useState(false)
  const [showRegister, setShowRegister] = useState(false)
  const {  logout, role } = useContext(AuthContext)

  return (
    <Navbar expand="lg" style={{ backgroundColor: "#6349dbff" }} variant="dark">
      <Container>
        <Navbar.Brand>
          <img src={logo} height="40" alt="logo" />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="main-navbar" />
        <Navbar.Collapse id="main-navbar">
          <Nav className="mx-auto text-uppercase fw-bold">
            {role === "Member" ?
              <>
                <Nav.Link href="/" className="text-warning">Lịch thi đấu</Nav.Link>
                <Nav.Link href={`/news`}>Tin tức</Nav.Link>
                <Nav.Link href="/article/post">Đăng bài viết</Nav.Link>
                <Nav.Link href="/predict">Minigame</Nav.Link>
              </> :
              role === "Admin" ?
                <>
                  <Nav.Link href="/admin/article">Quản lý bài viết</Nav.Link>
                  <Nav.Link href="/admin/users">Quản lý người dùng</Nav.Link>
                  <Nav.Link href="/admin/permissions">Quản lý quyền</Nav.Link>
                  <Nav.Link href="/admin/minigame">Quản lý minigame</Nav.Link>
                  <Nav.Link href="/admin/guesses">Quản lý dự đoán</Nav.Link>
                  <Nav.Link href="/admin/roles">Quản lý vai trò</Nav.Link>
                  <Nav.Link href="/admin/leagues">Quản lý giải đấu</Nav.Link>
                  <Nav.Link href="/admin/fixtures">Quản lý trận đấu</Nav.Link>
                </> :
                <>
                  <Nav.Link href="/" className="text-warning">Lịch thi đấu</Nav.Link>
                  <Nav.Link href={`/news`}>Tin tức</Nav.Link>
                </>
            }
          </Nav>

          {role === "Member" ?
            <div className="d-flex gap-2">

              <div className="dropdown my-auto" style={{ fontSize: "30px" }}>
                <a href="/" className="dropdown-toggle d-flex align-items-center" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                  <i className="bi bi-person-hearts" style={{ fontSize: "25px" }}></i>
                </a>
                <div className="dropdown-menu dropdown-menu-end p-2" aria-labelledby="dropdownMenuLink">

                  <a className="dropdown-item" href="/">
                    Thông tin tài khoản
                  </a>
                  <a className="dropdown-item" href="/history/article">
                    Lịch sử bài viết
                  </a>
                  <hr className="dropdown-divider" />
                  <Nav.Link onClick={logout} href="/" className="dropdown-item" style={{ marginLeft: "15px" }}>
                    Đăng xuất
                  </Nav.Link>
                </div>
              </div>

            </div>
            :
            role === "Admin" ?
              <div className="d-flex gap-2">

                <div className="dropdown my-auto" style={{ fontSize: "30px" }}>
                  <a href="/" className="dropdown-toggle d-flex align-items-center" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                    <i className="bi bi-person-hearts" style={{ fontSize: "25px" }}></i>
                  </a>
                  <div className="dropdown-menu dropdown-menu-end p-2" aria-labelledby="dropdownMenuLink">
                    <hr className="dropdown-divider" />
                    <Nav.Link onClick={logout} href="/" className="dropdown-item" style={{ marginLeft: "15px" }}>
                      Đăng xuất
                    </Nav.Link>
                  </div>
                </div>

              </div>
              :
              <div className="d-flex gap-2">
                <button className="btn btn-outline-warning" onClick={() => setShowLogin(true)}>Đăng nhập</button>
                <Login show={showLogin} onHide={() => setShowLogin(false)} switchToRegister={() => { setShowLogin(false); setShowRegister(true); }} onLoginSuccess={null} />

                <button className="btn btn-outline-warning" onClick={() => setShowRegister(true)}>Đăng ký</button>
                <Register show={showRegister} onHide={() => setShowRegister(false)} switchToLogin={() => { setShowLogin(true); setShowRegister(false) }} />
              </div>
          }

        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default Header;