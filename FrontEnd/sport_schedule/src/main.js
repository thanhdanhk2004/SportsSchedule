import { BrowserRouter, Route, Routes } from "react-router-dom";
import Header from "./Component/Layout/Header"
import Footer from "./Component/Layout/Footer"
import Slider from "./Component/Layout/Slider"
import { Container } from "react-bootstrap";
import Login from "./Component/login";
import Register from "./Component/Register"
import Home from "./Component/Home"
import Sidebar from "./Component/Sidebar/Sidebar"

const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Header />
                <Slider />
                <Sidebar />
                <Container>
                    <Routes>
                        <Route path="/" element={<Home />}></Route>
                        <Route path="/login" element={<Login />}></Route>
                        <Route path="/register" element={<Register />}></Route>
                    </Routes>
                </Container>
                <Footer />
            </BrowserRouter>

        </>
    );
}

export default Main;