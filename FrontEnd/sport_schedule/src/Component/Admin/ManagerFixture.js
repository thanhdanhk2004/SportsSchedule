import api, { endpoints, authApis } from "../../Services/Apis";
import { Pagination, Table } from "react-bootstrap";
import { useEffect, useState } from "react";
import ModalUpdateTime from "./ModalUpdateTime";


const ManagerFixture = () => {
    const [fixtures, setFixtures] = useState();
    const [totalPage, setTotalPage] = useState();
    const [page, setPage] = useState(1);
    const [pageSelected, setPageSelected] = useState(1);
    const [leagueSelected, setLeagueSelected] = useState(2015);
    const [showModal, setShowModal] = useState(false);
    const [selectedFixture, setSelectedFixture] = useState();
    const [leagues, setLeagues] = useState([]);

    const getFixturesByLeague = async () => {
        try {
            const response = await authApis().get(`${endpoints.getFixtureByLeagueAdmin(leagueSelected)}?page=${page}`);
            if (response.status === 200) {
                setFixtures(response.data);
                setTotalPage(response.data[0].totalPage);
            }
        } catch (error) {
            console.error("Error fetching fixtures:", error);
        }
    }

    const getLeagues = async () => {
        try {
            const response = await api.get(endpoints.league);
            if (response.status === 200) {
                setLeagues(response.data.leagues);
                console.log(response.data.leagues);
            }
        } catch (error) {
            console.error("Error fetching leagues:", error);
        }
    }

    useEffect(() => {
        getLeagues();
    }, []);

    useEffect(() => {
        getFixturesByLeague();
    }, [leagueSelected, page]);

    return (
        <>
            <div>
                <div className="text-center mt-4">
                    <h3>Quản lý minigame</h3>
                </div>
                <div>
                    <select className="form-select w-25 mt-5" style={{ marginLeft: "100px" }} aria-label="Default select example"
                        onChange={(e) => { setLeagueSelected(e.target.value); setPage(1); setPageSelected(1) }} value={leagueSelected}>
                        {leagues.map((league) => (
                            <option key={league.id} value={league.id}>{league.name}</option>
                        ))}
                    </select>
                </div>
                <div className="mt-5 mx-5" style={{ marginBottom: "200px" }}>
                    <Table className="" style={{ marginLeft: "50px", width: "1350px" }} bordered hover>
                        <thead className="text-center">
                            <tr>
                                <th>STT</th>
                                <th>Tên giải đấu</th>
                                <th>Đội nhà</th>
                                <th>Đội khách</th>
                                <th>Thời gian</th>
                                <td style={{ width: "300px" }}>Chức năng</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                fixtures && fixtures.map((fixture, index) => (
                                    <tr>
                                        <td className="text-center">{index + 1}</td>
                                        <td>{fixture.nameLeague}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={fixture.logoHome} alt={fixture.teamHome} />{fixture.teamHome}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={fixture.logoAway} alt={fixture.teamAway} />{fixture.teamAway}</td>
                                        <td>{fixture.time}</td>
                                        <td className="text-center">
                                            <button className="btn btn-primary" onClick={() => { setSelectedFixture(fixture); setShowModal(true) }}>Cập nhật thời gian</button>
                                        </td>
                                    </tr>
                                ))
                            }
                            <ModalUpdateTime show={showModal} onHide={() => { getFixturesByLeague(); setShowModal(false) }} fixture={selectedFixture} />
                        </tbody>
                    </Table>
                    <div className="" style={{ marginLeft: "550px" }}>
                        <Pagination>
                            <Pagination.First onClick={() => { setPage(1); getFixturesByLeague(); setPageSelected(1) }} />
                            <Pagination.Prev onClick={() => { setPage(page - 1); getFixturesByLeague(); setPageSelected(page - 1) }} />
                            {totalPage && [...Array(totalPage)].map((_, index) => (
                                <div className={`${pageSelected === index + 1 ? "bg-primary" : ""}`}>
                                    <Pagination.Item key={index} onClick={() => { setPage(index + 1); getFixturesByLeague(); setPageSelected(index + 1) }}>
                                        {index + 1}
                                    </Pagination.Item>
                                </div>
                            ))}
                            <Pagination.Next onClick={() => { setPage(page + 1); getFixturesByLeague(); setPageSelected(page + 1) }} />
                            <Pagination.Last onClick={() => { setPage(totalPage); getFixturesByLeague(); setPageSelected(totalPage) }} />
                        </Pagination>
                    </div>
                </div>
            </div>
        </>
    );
};

export default ManagerFixture;