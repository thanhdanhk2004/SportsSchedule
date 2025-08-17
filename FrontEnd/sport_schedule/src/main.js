import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./MainLayout"
import Home from "./Component/Home"
import FixtureDetail from "./Component/FixtureDetail"
import League from "./Component/League"
import Ranking from "./Component/Raking";
import Article from "./Component/PostArticle";
import Protected from "./Protected"
import HistoryArticle from "./Component/HistoryArticle";

const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<MainLayout><Home /></MainLayout>} />
                    <Route path="/detail/:matchId" element={<MainLayout><FixtureDetail /></MainLayout>} />
                    <Route path="/fixtures/:id" element={<MainLayout><League /></MainLayout>} />
                    <Route path="/ranking" element={<MainLayout><Ranking /></MainLayout>} />
                    <Route path="/article/post" element={<Protected><Article/></Protected>} />
                    <Route path="/history/article" element={<Protected><HistoryArticle/></Protected>} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default Main;