import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./MainLayout"
import Home from "./Component/Home"
import FixtureDetail from "./Component/FixtureDetail"

const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<MainLayout><Home /></MainLayout>}></Route>
                </Routes>
                <Routes>
                    <Route path="/detail/:matchId" element={<MainLayout><FixtureDetail /></MainLayout>}></Route>
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default Main;