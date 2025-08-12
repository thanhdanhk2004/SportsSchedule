import Leagues from "./Sidebar/Leagues";
import FixturesLeague from "./Sidebar/FixturesLeague"

const League = () =>{
    return (
        <>
            <div className="home-container">
                <Leagues />
                <FixturesLeague />
            </div>
        </>
    )
}

export default League