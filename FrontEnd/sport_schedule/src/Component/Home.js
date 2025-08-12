import Leagues from "./Sidebar/Leagues"
import Schedule from "./Sidebar/Schedule"
import "../Style/index.css"

const Home = () => {
    return (
        <>
            <div className="home-container" >
                <Leagues />
                <Schedule />
            </div>
        </>
    )   
}

export default Home