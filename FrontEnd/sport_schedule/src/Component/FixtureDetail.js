
import { useParams } from "react-router-dom"
import api, { endpoints } from "../Services/Apis"
import { useEffect, useState } from "react"
import "bootstrap/dist/css/bootstrap.min.css";
import { Nav } from "react-bootstrap";
import Statistic from "./FixtureStatistic";
import Overview from "./FixtureOverview";
import Lineup from "./FixtrueLineup";
import { Container } from "react-bootstrap"

const FixtureDetail = () => {
    const [statisticFixture, setStatisticFixture] = useState([])
    const { matchId } = useParams()
    const [activeKey, setActiveKey] = useState("tongQuan");

    const getDataStatistic = async () => {
        try {
            if (matchId !== null) {
                const res = await api.get(endpoints.statistic(matchId))
                setStatisticFixture(res.data)
            }
        } catch (err) {
            alert("Vui lòng kiểm tra mạng")
        }
    }
    useEffect(() => {
        getDataStatistic()
    }, [])


    return (
        <>
            <div className="d-flex justify-content-center">
                <h3>Thống kê trận đấu giữa <strong>{statisticFixture.nameHome}</strong> và <strong>{statisticFixture.nameAway} ngày {statisticFixture.time ? statisticFixture.time.split(" ")[0] : ""}</strong></h3>
            </div>
            <Container className="mt-4 p-3 border rounded shadow-sm w-50 mb-5">
                <div className="detail-container">
                    <div className="w-100">
                        <div className="d-flex">
                            <h5>Giải {statisticFixture.leagueName} - {statisticFixture.time && statisticFixture.time.split(" ")[1].substring(0, 5)}</h5>
                            <h5 style={{marginLeft:"29rem"}}><strong className="text-danger">Kết thúc</strong></h5>
                        </div>
                        
                        <div className="d-flex justify-content-around align-items-center" style={{marginTop: "20px"}}>
                            <div className="text-center">
                                <img
                                    src={statisticFixture.logoHome}
                                    alt={statisticFixture.nameHome}
                                    style={{ height: '80px' }}
                                />
                                <h5 className="mt-2">{statisticFixture.nameHome}</h5>
                            </div>

                            <div className="text-center">
                                <h2 className="text-success fw-bold">{statisticFixture.goalHomeFullTime !== null ? statisticFixture.goalHomeFullTime + " - " + statisticFixture.goalAwayFullTime : "Vs"}</h2>
                            </div>

                            <div className="text-center">
                                <img
                                    src={statisticFixture.logoAway}
                                    alt={statisticFixture.nameAway}
                                    style={{ height: '80px' }}
                                />
                                <h5 className="mt-2">{statisticFixture.nameAway}</h5>
                            </div>
                        </div>

                        <div className="text-center">
                            <p>Hiệp một: {statisticFixture.goalHomeFullTime !== null ? statisticFixture.goalHomeFirst + " - " + statisticFixture.goalAwayFirst : "0 - 0"}</p>
                        </div>
                    </div>
                </div>
            </Container>
            <div>
                <Nav variant="tabs" activeKey={activeKey} onSelect={(selectedKey) => setActiveKey(selectedKey)} className="mb-3 d-flex justify-content-center">
                    <Nav.Item>
                        <Nav.Link eventKey="tongQuan">Tổng quan</Nav.Link>
                    </Nav.Item>

                    <Nav.Item>
                        <Nav.Link eventKey="doiHinh">Đội hình</Nav.Link>
                    </Nav.Item>

                    <Nav.Item>
                        <Nav.Link eventKey="thongKe">Thống kê</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link eventKey="doidau">Đối đầu</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link eventKey="bxh">BXH</Nav.Link>
                    </Nav.Item>
                </Nav>

                {activeKey === "thongKe" && statisticFixture.statisticTeamHome !== null &&
                    <Statistic statisticTeamHome={statisticFixture.statisticTeamHome} statisticTeamAway={statisticFixture.statisticTeamAway}
                        nameHome={statisticFixture.nameHome} nameAway={statisticFixture.nameAway}
                        logoHome={statisticFixture.logoHome} logoAway={statisticFixture.logoAway} />
                }
                {activeKey === "tongQuan" &&
                    <Overview goalHome={statisticFixture.goalHome ? statisticFixture.goalHome : []} goalAway={statisticFixture.goalAway ? statisticFixture.goalAway : []}
                        cardHome={statisticFixture.cardsHome ? statisticFixture.cardsHome : []} cardAway={statisticFixture.cardsAway ? statisticFixture.cardsAway : []}
                        subHome={statisticFixture.subHome ? statisticFixture.subHome : []} subAway={statisticFixture.subAway ? statisticFixture.subAway : []}
                        nameHome={statisticFixture.nameHome} nameAway={statisticFixture.nameAway}
                        logoHome={statisticFixture.logoHome} logoAway={statisticFixture.logoAway} />
                }
                {
                    activeKey === "doiHinh" &&
                    <Lineup playerHome={statisticFixture.playerHome ? statisticFixture.playerHome : []} playerAway={statisticFixture.playerAway ? statisticFixture.playerAway : []}
                        nameHome={statisticFixture.nameHome} nameAway={statisticFixture.nameAway}
                        logoHome={statisticFixture.logoHome} logoAway={statisticFixture.logoAway}
                        statisticTeamHome={statisticFixture.statisticTeamHome} statisticTeamAway={statisticFixture.statisticTeamAway}
                        subHome={statisticFixture.subHome} subAway={statisticFixture.subAway}/>
                }
            </div>
        </>
    )
}

export default FixtureDetail