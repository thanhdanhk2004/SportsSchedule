import { Container, Row, Col, Image, Table } from "react-bootstrap";
import { useState } from "react";
import "../Style/index.css"
import "bootstrap/dist/css/bootstrap.min.css";
import { FaArrowRightArrowLeft } from "react-icons/fa6"; // icon thay người
import api, { endpoints } from "../Services/Apis";
import ModalPlayer from "./Player";

const Lineup = ({ playerHome, playerAway, nameHome, nameAway, logoHome, logoAway, statisticTeamHome, statisticTeamAway, subHome, subAway }) => {


    const positions = {
        "G": "Thủ môn",
        "D": "Hậu vệ",
        "M": "Tiền vệ",
        "F": "Tiền đạo"
    }


    //Nhom thành một mảng lớn và mỗi phần tử là một mảng con chứa các đối tượng có position gioóng nhau
    //Doi nha
    const order = ["G", "D", "M", "F"]; //Thu tu trong so do tu: Thu mon -> Hau ve -> Tien ve -> Tien dao
    const groupedHome = playerHome.reduce((acc, player) => {
        if (!acc[player.position] && player.position !== "Huấn luyện viên")
            acc[player.position] = [];
        if (player.status === true)
            acc[player.position].push(player);
        return acc;
    }, {});
    const playerHomeGrouped = order.map(pos => groupedHome[pos]);

    //Doi khach
    const groupedAway = playerAway.reduce((acc, player) => {
        if (!acc[player.position] && player.position !== "Huấn luyện viên")
            acc[player.position] = []
        if (player.status === true)
            acc[player.position].push(player)
        return acc;
    }, {})
    const playerAwayGrouped = order.map(pos => groupedAway[pos])
    console.log(playerAwayGrouped)

    //Một người trong đội hình
    const Player = ({ id, number, name, sub, team }) => (
        <div className="player">
            <div style={{ cursor: "pointer" }} onClick={() => { getPlayer(id); setShowModal(true) }} className={team === "home" ? "shirt-home" : "shirt-away"}>
                <span className="number">{number}</span>
                {sub === true && <FaArrowRightArrowLeft className="sub-icon" />}
            </div>
            <div style={{ cursor: "pointer" }} onClick={() => { getPlayer(id); setShowModal(true) }} className="player-name">{name && name}</div>
            <ModalPlayer show={showModal} close={() => setShowModal(false)} player={playerInfo} />
        </div>
    );


    //Lay thong tin cau thủ
    const [playerInfo, setPlayerInfo] = useState({})
    const getPlayer = async (playerId) => {
        try {
            const res = await api.get(endpoints.player(playerId))
            setPlayerInfo(res.data)
            console.log(playerInfo)
        } catch (err) {
            alert(err)
        }
    }

    //Modal cau thu
    const [showModal, setShowModal] = useState(false)


    return (
        <div className="d-flex justify-content-center">
            <div className="w-25" style={{ marginRight: "60px" }}>
                <Container className="mt-4 text-center" style={{ maxWidth: "400px" }}>
                    <Image src={logoHome} alt="Team Logo" style={{ width: "80px", height: "80px" }} className="mb-2" />
                    <h5 className="fw-bold">Dự bị</h5>
                    <Table bordered responsive size="sm" className="text-center align-middle">
                        <tbody>
                            <tr>
                                <td style={{ width: "20%", fontWeight: "bold" }}>Số áo</td>
                                <td style={{ fontWeight: "bold" }}>Tên cầu thủ</td>
                                <td style={{ width: "25%", fontWeight: "bold" }}>Vị trí</td>
                            </tr>
                            {playerHome && playerHome.sort((a, b) => a.number - b.number).map((player) => (
                                (player.status === false && player.position !== "Huấn luyện viên") &&
                                (<>
                                    <tr>
                                        <td style={{ width: "15%" }}>{player.number}</td>
                                        <td style={{ cursor: "pointer" }} onClick={() => { getPlayer(player.id); setShowModal(true) }}>{player.name}</td>
                                        <td style={{ width: "15%" }}>{positions[`${player.position}`]}</td>
                                    </tr>
                                </>)
                            ))}
                        </tbody>
                    </Table>

                    {/* <div className="fw-bold border text-center py-2" style={{ borderWidth: "2px", textTransform: "uppercase" }}>
                        {(playerHome.find(player => player.position === "Huấn luyện viên"))?.name || "Chưa có HLV"}
                    </div> */}
                </Container>
            </div>

            <div>
                <Container className="mt-4 p-3 border rounded shadow-sm" style={{ width: "550px", marginBottom: "20px", height: "850px" }}>
                    <h5 className="text-center fw-bold mb-4">Đội hình ra sân</h5>
                    <Container fluid className="formation-container">
                        <div className="formation-header">
                            <img src={logoHome} alt="Logo" className="team-logo" />
                            <span>{nameHome}</span>
                            <span className="formation-text">{statisticTeamHome.lineUp}</span>
                        </div>

                        <div className="formation-lineup">
                            <div>
                                {
                                    playerHomeGrouped && playerHomeGrouped.map((players) => (
                                        <Row className="formation-row-home justify-content-center">
                                            {players.map((player) => (
                                                <Col xs="auto">
                                                    <Player id={player.id} number={player.number} name={player.name} sub={subHome.find(sub => sub.nameOut === player.name) ? true : false} team="home" />
                                                </Col>
                                            ))}
                                        </Row>
                                    ))
                                }
                            </div>
                            <div style={{ marginTop: "75px" }}>
                                {
                                    playerAwayGrouped && playerAwayGrouped.reverse().map((players) => (
                                        <Row className="formation-row-away justify-content-center">
                                            {players.map((player) => (
                                                <Col xs="auto">
                                                    <Player number={player.number} name={player.name} sub={subAway.find(sub => sub.nameOut === player.name) ? true : false} team="away" />
                                                </Col>
                                            ))}
                                        </Row>
                                    ))
                                }
                            </div>
                        </div>


                        <div className="formation-footer">
                            <img src={logoAway} alt="Logo" className="team-logo" />
                            <span>{nameAway}</span>
                            <span className="formation-text">{statisticTeamAway.lineUp}</span>
                        </div>
                    </Container>
                </Container>
            </div>

            <div className="w-25" style={{ marginLeft: "70px" }}>
                <Container className="mt-4 text-center" style={{ maxWidth: "400px" }}>
                    <Image src={logoAway} alt="Team Logo" style={{ width: "80px", height: "80px" }} className="mb-2" />
                    <h5 className="fw-bold">Dự bị</h5>
                    <Table bordered responsive size="sm" className="text-center align-middle">
                        <tbody>
                            <tr>
                                <td style={{ width: "20%", fontWeight: "bold" }}>Số áo</td>
                                <td style={{ fontWeight: "bold" }}>Tên cầu thủ</td>
                                <td style={{ width: "25%", fontWeight: "bold" }}>Vị trí</td>
                            </tr>
                            { playerAway && playerAway.sort((a, b) => a.number - b.number).map((player) => (
                                (player.status === false && player.position !== "Huấn luyện viên") &&
                                (<>
                                    <tr>
                                        <td style={{ width: "15%" }}>{player.number}</td>
                                        <td style={{ cursor: "pointer" }} onClick={() => { getPlayer(player.id); setShowModal(true) }}>{player.name}</td>
                                        <td style={{ width: "15%" }}>{positions[`${player.position}`]}</td>
                                    </tr>
                                </>
                                )
                            ))}
                        </tbody>
                    </Table>

                    {/* <div className="fw-bold border text-center py-2" style={{ borderWidth: "2px", textTransform: "uppercase" }}>
                        {( playerAway.find(player => player.position === "Huấn luyện viên"))?.name || "Chưa có HLV"}
                    </div> */}
                </Container>
            </div>
        </div>
    );
}

export default Lineup