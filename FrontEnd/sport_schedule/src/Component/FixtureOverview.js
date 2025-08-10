import { Row, Col, Container } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import yellowCard from "../assets/yellowCard.png"
import redCard from "../assets/redCard.png"

const Overview = ({ goalHome, goalAway, cardHome, cardAway, subHome, subAway }) => {
    //Cap nhat lai tung mang cho no co ma de dễ hiển thị trên giao diện
    const goalHomeUpdate = goalHome.map(goal => ({
        ...goal,
        id: "goal"
    }))
    const goalAwayUpdate = goalAway.map(goal => ({
        ...goal,
        id: "goal"
    }))
    const cardHomeUpdate = cardHome.map(card => ({
        ...card,
        id: "card"
    }))
    const cardAwayUpdate = cardAway.map(card => ({
        ...card,
        id: "card"
    }))
    const subHomeUpdate = subHome.map(sub => ({
        ...sub,
        id: "sub"
    }))
    const subAwayUpdate = subAway.map(sub => ({
        ...sub,
        id: "sub"
    }))

    const home = [...goalHomeUpdate, ...cardHomeUpdate, ...subHomeUpdate].sort((a, b) => a.time - b.time).map(item => ({
        ...item,
        team: "home"
    }))
    const away = [...goalAwayUpdate, ...cardAwayUpdate, ...subAwayUpdate].sort((a, b) => a.time - b.time).map(item => ({
        ...item,
        team: "away"
    }))

    const mergeTeam = [...home, ...away].sort((a, b) => a.time - b.time)
   
    return (
        <div>
            <Container className="mt-4 p-3 border rounded shadow-sm" style={{ width: "800px" }}>
                <h5 className="text-center fw-bold mb-4">TỔNG QUAN TRẬN ĐẤU</h5>
                {mergeTeam.map((item, index) => (
                    <Row key={index} className="align-items-center mb-2">

                        {/* Cột đội chủ nhà */}
                        <Col>
                            {item.team === "home" && (
                                <div className="d-flex justify-content-start align-items-center">
                                    {item.id === "goal" ? (
                                        <span><i className="fa-solid fa-futbol px-3" />{item.namePlayer}</span>
                                    ) : item.id === "card" ? (
                                        <span><img className="px-3"
                                            src={item.type === "Yellow Card"
                                                ? yellowCard
                                                : redCard
                                            }
                                            alt={item.type === "Yellow Card" ? "theVang" : "theDo"}
                                            style={{width:"60px"}}
                                        />{item.nameMember}</span>
                                    ) : (
                                       <span><i className="fa-solid fa-arrows-rotate px-3"></i> {item.nameIn + " (Thay: "+ item.nameOut+")"}</span> 
                                    )}
                                </div>
                            )}
                        </Col>

                        {/* Cột thời gian (timeline) */}
                        <Col xs="auto" className="text-center" style={{ position: "relative" }}>
                            {/* Đường kẻ dọc */}
                            <div
                                style={{
                                    position: "absolute",
                                    top: 0,
                                    bottom: 0,
                                    left: "50%",
                                    width: "2px",
                                    background: "#ccc",
                                    transform: "translateX(-50%)",
                                    zIndex: 0
                                }}
                            ></div>

                            {/* Vòng tròn */}
                            <div
                                style={{
                                    width: "12px",
                                    height: "12px",
                                    background: "#ccc",
                                    borderRadius: "50%",
                                    margin: "0 auto",
                                    position: "relative",
                                    zIndex: 1
                                }}
                            ></div>

                            {/* Thời gian */}
                            <div style={{ fontSize: "0.9rem", marginTop: "2px" }}>
                                {item.time}
                            </div>
                        </Col>

                        {/* Cột đội khách */}
                        <Col>
                            {item.team === "away" && (
                                <div className="d-flex justify-content-end align-items-center">
                                    {item.id === "goal" ? (
                                        <span>{item.namePlayer}<i className="fa-solid fa-futbol px-3" /></span>
                                    ) : item.id === "card" ? (
                                        <span>{item.nameMember}<img
                                            className="px-3"
                                            src={item.type === "Yellow Card"
                                                ? yellowCard
                                                : redCard
                                            }
                                            alt={item.type === "Yellow Card" ? "theVang" : "theDo"}
                                            style={{width:"60px"}}
                                        /></span>
                                    ) : (
                                       <span> {item.nameIn + " (Thay: "+ item.nameOut+")"}<i className="fa-solid fa-arrows-rotate px-3"></i></span> 
                                    )}
                                </div>
                            )}
                        </Col>
                    </Row>
                ))}
            </Container>
        </div>
    );

}

export default Overview