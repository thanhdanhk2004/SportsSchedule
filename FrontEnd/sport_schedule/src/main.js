import { BrowserRouter, Route, Routes } from "react-router-dom";
import MainLayout from "./MainLayout"
import Home from "./Component/Home"
import FixtureDetail from "./Component/FixtureDetail"
import League from "./Component/League"
import Ranking from "./Component/Raking";
import Article from "./Component/PostArticle";
import Protected from "./Protected"
import HistoryArticle from "./Component/HistoryArticle";
import News from './Component/News'
import DetailArticle from "./Component/DetailArticle";
import PredictMatch from "./Component/PredictMatchs";
import ManagerUser from "./Component/Admin/ManagerUser";
import ManagerArticle from "./Component/Admin/ManagerArticle";
import ManagerPermission from "./Component/Admin/ManagerPermission";
import ManagerMinigame from "./Component/Admin/ManagerMinigame";
import ManagerGuess from "./Component/Admin/ManagerGuess";
import ManagerAward from "./Component/Admin/ManagerAward";
import ManagerRole from "./Component/Admin/ManagerRole"
import ManagerLeague from "./Component/Admin/ManagerLeague"
import ManagerFixture from "./Component/Admin/ManagerFixture";

const Main = () => {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<MainLayout><Home /></MainLayout>} />
                    <Route path="/detail/:matchId" element={<MainLayout><FixtureDetail /></MainLayout>} />
                    <Route path="/fixtures/:id" element={<MainLayout><League /></MainLayout>} />
                    <Route path="/ranking" element={<MainLayout><Ranking /></MainLayout>} />
                    <Route path="/article/post" element={<Protected roleNeed="Member"><Article/></Protected>} />
                    <Route path="/history/article" element={<Protected roleNeed="Member"><HistoryArticle /></Protected>} />
                    <Route path="/news" element={<MainLayout><News /></MainLayout>}/>
                    <Route path="/article" element={<MainLayout><DetailArticle /></MainLayout>}/>
                    <Route path="/predict" element={<Protected roleNeed="Member"><PredictMatch /></Protected>}/>
                    <Route path="/admin/users" element={<Protected roleNeed="Admin"><ManagerUser /></Protected>}/>
                    <Route path="/admin/article" element={<Protected roleNeed="Admin"><ManagerArticle /></Protected>}/>
                    <Route path="/admin/permissions" element={<Protected roleNeed="Admin"><ManagerPermission /></Protected>}/>
                    <Route path="/admin/minigame" element={<Protected roleNeed="Admin"><ManagerMinigame /></Protected>}/>
                    <Route path="/admin/guesses" element={<Protected roleNeed="Admin"><ManagerGuess /></Protected>}/>
                    <Route path="/admin/award" element={<Protected roleNeed="Admin"><ManagerAward /></Protected>}/>
                    <Route path="/admin/roles" element={<Protected roleNeed="Admin"><ManagerRole /></Protected>}/>
                    <Route path="/admin/leagues" element={<Protected roleNeed="Admin"><ManagerLeague /></Protected>}/>
                    <Route path="/admin/fixtures" element={<Protected roleNeed="Admin"><ManagerFixture /></Protected>}/>
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default Main;