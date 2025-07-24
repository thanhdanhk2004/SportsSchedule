import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./MainLayout"
import AuthLayout from "./AuthLayout"
import Home from "./Component/Home"


const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<MainLayout><Home /></MainLayout>}></Route>
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default Main;