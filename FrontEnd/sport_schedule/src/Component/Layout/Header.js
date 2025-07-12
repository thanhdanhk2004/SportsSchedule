import React from "react";
import {Button, Navbar, Nav, NavDropdown, Container} from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import logo from '../../assets/logo.jpg';

const Header = () => {
    return (
    <Navbar expand="lg" style={{ backgroundColor: "#6349dbff" }} variant="dark">
      <Container>
        <Navbar.Brand>
            <img src={logo} height="40" alt="logo" />
        </Navbar.Brand> 
        <Navbar.Toggle aria-controls="main-navbar" />
        <Navbar.Collapse id="main-navbar">
          <Nav className="mx-auto text-uppercase fw-bold">
            <Nav.Link href="#" className="text-warning">Lịch thi đấu</Nav.Link> 
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
          </Nav>

          <div className="d-flex gap-2">
            <Button variant="outline-warning" href="/login">Đăng nhập</Button>
            <Button variant="outline-warning" href="/register">Đăng ký</Button>
          </div>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default Header;