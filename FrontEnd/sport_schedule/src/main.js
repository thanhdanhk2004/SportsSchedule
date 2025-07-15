import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./MainLayout"
import AuthLayout from "./AuthLayout"
import Home from "./Component/Home"
import Login from "./Component/Login"
import Register from "./Component/Register"

const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<MainLayout><Home /></MainLayout>}></Route>
                    <Route path="/login" element={<AuthLayout><Login /></AuthLayout>}></Route>
                    <Route path="/register" element={<AuthLayout><Register /></AuthLayout>}></Route>

                </Routes>
            </BrowserRouter>
        </>
    );
}

export default Main;