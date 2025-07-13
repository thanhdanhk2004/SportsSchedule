import { BrowserRouter, Route, Routes } from "react-router-dom";
import Header from "./Component/Layout/Header"
import Footer from "./Component/Layout/Footer"
import { Container } from "react-bootstrap";
import Login from "./Component/login";
import Register from "./Component/Register"

const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Header />
                <Container>
                    <Routes>
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