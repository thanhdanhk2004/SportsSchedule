import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import api, { endpoints } from "../../Services/Apis"
import { Container } from "react-bootstrap";
import SeeModal from "../See";

const FixturesLeague = () => {
    const { id } = useParams()
    const [fixtures, setFixtures] = useState([])
    const [error, setErrors] = useState("")
    const [round, setRound] = useState(1)
    const [groupFixture, setGroupFixture] = useState({})
    const [seeModal, setSeeModal] = useState(false)
    const [matchSelected, setMatcheSelected] = useState(null)

    //Gom cac tran dau theo ngay
    const groupDateFixture = (matches) =>{
        return matches.reduce((acc, match) =>{
            if(!acc[match.time.split(" ")[0]])
                acc[match.time.split(" ")[0]] = []
            acc[match.time.split(" ")[0]].push(match)
            return acc
        }, {})
    } 

    const getFixtures = async (page) => {
        try {
            const res = await api.get(endpoints.fixturesLeague({ leagueId: id, page: page }))
            setFixtures(res.data)
            const grouped = groupDateFixture(res.data)
            setGroupFixture(grouped)
            console.log(groupFixture)
        } catch (err) {
            setErrors("Vui lòng kiểm tra lại mạng")
            alert(error)
        }
    }

    useEffect(() => {
        getFixtures(1)
    }, [id])

    return (
        <Container className="mt-4">
            <h4 className="text-center mt-4">Lịch thi đấu bóng đá giải {fixtures[0]?.leagueName|| ""}</h4>
            <div className="d-flex justify-content-center bg-light flex-wrap" style={{marginLeft: "200px", width:`${48*parseInt(fixtures[0]?.numberRound)/2}px`}} >
                {fixtures[0]?.numberRound && Array.from({ length: parseInt(fixtures[0].numberRound) }, (_, i) => i + 1).map((index) => (
                <button className={`btn-primary ${round === index?"bg-success text-white" : ""}` } style={{width: "40px", margin: "3px"}}
                 onClick={() => {setRound(index); getFixtures(index)}}>
                    {index}
                </button>
            ))}
            </div>
            <div className="text" style={{marginLeft: "220px", marginTop:"20px"}}>Vòng đấu: 
                 <strong className="text text-danger"> {round}</strong>
            </div>
            <div>
                {Object.entries(groupFixture).map(([date, matches]) => (
                    <div className='d-flex justify-content-center mt-3'>
                        <div className="justify-content-center text-center bg-white rounded shadow p-3 mt-3 w-75">
                            <div className="fw-semibold mb-2">{date}</div>
                            {matches.map((m) => (
                                <div className="d-flex border-bottom py-4 mt-2 gap-3 align-items-center">
                                    <div style={{ width: "150px" }} className="text-sm text-start">
                                        <p>
                                            {m.time.split(" ")[0]}
                                        </p>
                                        <p style={{ paddingLeft: "20px" }}>
                                            {m.time.split(" ")[1].substring(0, 5)}
                                        </p>
                                    </div>

                                    <div className="flex-grow-1 d-flex justify-content-center">
                                        <div className="match-row d-flex align-items-center justify-content-between border-bottom py-2">
                                            <div className="team d-flex align-items-center gap-2" style={{ width: "150px" }}>
                                                {m.logoHome && <img src={m.logoHome} alt="home" width={20} />}
                                                <span className="team-name" style={{width: "150px"}}>{m.nameHome}</span>
                                            </div>

                                            <div key={m.matchId} className={`score-box px-2 py-1 fw-bold rounded text-white ${m.goalHomeFullTime === null ? "bg-secondary" : "bg-success"}`} style={{ height: "35px", cursor: "pointer" }} onClick={() => {setSeeModal(true); setMatcheSelected(m)}}>
                                                <span>{m.goalHomeFullTime === null ? "vs" : m.goalHomeFullTime + " - " + m.goalAwayFullTime}</span>
                                            </div>
                                            <SeeModal show={seeModal} handleClose={() => setSeeModal(false)}  match={matchSelected}/>

                                            <div className="team d-flex align-items-center gap-2 justify-content-start" style={{ width: "150px" }}>
                                                <span className="team-name text-end" style={{width: "150px"}}>{m.nameAway}</span>
                                                {m.logoAway && <img src={m.logoAway} alt="away" width={20} />}
                                            </div>
                                        </div>
                                    </div>

                                    {m.goalHomeFullTime === null && (
                                        <>
                                            <div className='btn btn-info'>Hẹn lịch</div>
                                            <div className='btn btn-success'>Minigame</div>
                                        </>
                                    )}

                                </div>

                            ))}

                        </div>
                    </div>
                ))}
            </div>
        </Container>

    )
}
export default FixturesLeague