
import { useParams } from "react-router-dom"
import api, { endpoints } from "../Services/Apis"
import { useEffect, useState } from "react"
import "bootstrap/dist/css/bootstrap.min.css";
import { Nav } from "react-bootstrap";
import Statistic from "./Statistic";

const FixtureDetail = () => {
    const [statisticFixture, setStatisticFixture] = useState([])
    const { matchId } = useParams()
    const [activeKey, setActiveKey] = useState("dienbien");

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
    },[])

    

    return (
        <>
            <div className="d-flex justify-content-center">
                <h3>Thống kê trận đấu giữa <strong>{statisticFixture.nameHome}</strong> và <strong>{statisticFixture.nameAway} ngày {statisticFixture.time ? statisticFixture.time.split(" ")[0] : ""}</strong></h3>
            </div>
            <div className="detail-container px-5" >
                <div className="px-5 w-50">
                    <div>
                        <h5>Giải {statisticFixture.leagueName} - {statisticFixture.time && statisticFixture.time.split(" ")[1].substring(0, 5)}</h5>
                    </div>
                    <div className="d-flex justify-content-around align-items-center mb-4">
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

                    <div className="mb-3 text-center">
                        <p>Hiệp một: {statisticFixture.goalHomeFullTime !== null ? statisticFixture.goalHomeFirst + " - " + statisticFixture.goalAwayFirst : "0 - 0"}</p>
                    </div>
                </div>

                <div>
                    <Nav variant="tabs" activeKey={activeKey} onSelect={(selectedKey) => setActiveKey(selectedKey)} className="mb-3">
                        <Nav.Item>
                            <Nav.Link eventKey="tongquan">Tổng quan</Nav.Link>
                        </Nav.Item>
                        
                        <Nav.Item>
                            <Nav.Link eventKey="doihinh">Đội hình</Nav.Link>
                        </Nav.Item>
                        
                        <Nav.Item>
                            <Nav.Link eventKey="thongke">Thống kê</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link eventKey="doidau">Đối đầu</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link eventKey="bxh">BXH</Nav.Link>
                        </Nav.Item>
                    </Nav>

                    {activeKey === "thongke" && statisticFixture.statisticTeamHome!== null  && 
                        <Statistic statisticTeamHome={statisticFixture.statisticTeamHome} statisticTeamAway={statisticFixture.statisticTeamAway}
                                    nameHome={statisticFixture.nameHome} nameAway={statisticFixture.nameAway}
                                    logoHome={statisticFixture.logoHome} logoAway={statisticFixture.logoAway}/>
                    }
                </div>
            </div>
        </>
    )
}

export default FixtureDetail