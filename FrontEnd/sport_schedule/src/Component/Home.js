import League from "./Sidebar/League"
import Schedule from "./Sidebar/Schedule"
import "../Style/index.css"

const Home = () => {
    return (
        <>
            <div className="home-container">
                <League />
                <Schedule />
            </div>
        </>
    )
}

export default Home