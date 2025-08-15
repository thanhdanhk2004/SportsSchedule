import React, { useContext, useState } from "react";
import { Navbar, Nav, NavDropdown, Container } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import logo from '../../assets/logo.jpg';
import Login from "../Login"
import Register from "../Register";
import { Link } from "react-router-dom";
import { AuthContext } from "../../Context/AuthContext";

const Header = () => {

  const [showLogin, setShowLogin] = useState(false)
  const [showRegister, setShowRegister] = useState(false)
  const { isLogin, logout } = useContext(AuthContext)

  return (
    <Navbar expand="lg" style={{ backgroundColor: "#6349dbff" }} variant="dark">
      <Container>
        <Navbar.Brand>
          <img src={logo} height="40" alt="logo" />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="main-navbar" />
        <Navbar.Collapse id="main-navbar">
          <Nav className="mx-auto text-uppercase fw-bold">
            <Nav.Link href="/" className="text-warning">Lịch thi đấu</Nav.Link>
            <Nav.Link href="#">Kết quả</Nav.Link>

            <NavDropdown title="Giải đấu" id="league-dropdown">
              <NavDropdown.Item href="#">Ngoại hạng Anh</NavDropdown.Item>
              <NavDropdown.Item href="#">La Liga</NavDropdown.Item>
              <NavDropdown.Item href="#">Serie A</NavDropdown.Item>
            </NavDropdown>

            <NavDropdown title="Đội bóng" id="teams-dropdown">
              <NavDropdown.Item href="#">MU</NavDropdown.Item>
              <NavDropdown.Item href="#">Barcelona</NavDropdown.Item>
            </NavDropdown>

            <Nav.Link href="#">Chuyển nhượng</Nav.Link>

            <NavDropdown title="Anh" id="anh-dropdown">
              <NavDropdown.Item href="#">Chelsea</NavDropdown.Item>
            </NavDropdown>

            <NavDropdown title="TBN" id="tbn-dropdown">
              <NavDropdown.Item href="#">Real Madrid</NavDropdown.Item>
            </NavDropdown>
            <Nav.Link href="#">Việt Nam</Nav.Link>
            {isLogin === true ?
              <>
                <Nav.Link href="/article/post">Đăng bài viết</Nav.Link>
                <Nav.Link>Minigame</Nav.Link>
              </>
              : ""}
          </Nav>

          {isLogin ?
            <div className="d-flex gap-2">
              
              <div className="dropdown my-auto" style={{ fontSize: "30px" }}>
                <a href="/" className="dropdown-toggle d-flex align-items-center" role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                  <i class="bi bi-person-hearts" style={{ fontSize: "25px" }}></i>
                </a>
                <div className="dropdown-menu dropdown-menu-end p-2" aria-labelledby="dropdownMenuLink">

                  <a className="dropdown-item" href="/">
                    Thông tin tài khoản
                  </a>
                  <a className="dropdown-item" href="/">
                    Lịch sử bài viết
                  </a>
                  <hr className="dropdown-divider" />
                  <Link onClick={logout} href="/" className="dropdown-item">
                    Đăng xuất
                  </Link>
                </div>
              </div>

            </div>
            :
            <div className="d-flex gap-2">
              <button className="btn btn-outline-warning" onClick={() => setShowLogin(true)}>Đăng nhập</button>
              <Login show={showLogin} onHide={() => setShowLogin(false)} switchToRegister={() => { setShowLogin(false); setShowRegister(true); }} />

              <button className="btn btn-outline-warning" onClick={() => setShowRegister(true)}>Đăng ký</button>
              <Register show={showRegister} onHide={() => setShowRegister(false)} switchToLogin={() => { setShowLogin(true); setShowRegister(false) }} />
            </div>}
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default Header;