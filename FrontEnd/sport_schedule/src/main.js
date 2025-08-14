import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./MainLayout"
import Home from "./Component/Home"
import FixtureDetail from "./Component/FixtureDetail"
import League from "./Component/League"
import Ranking from "./Component/Raking";

const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<MainLayout><Home /></MainLayout>} />
                    <Route path="/detail/:matchId" element={<MainLayout><FixtureDetail /></MainLayout>} />
                    <Route path="/fixtures/:id" element={<MainLayout><League /></MainLayout>} />
                    <Route path="/ranking" element={<MainLayout><Ranking /></MainLayout>} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default Main;