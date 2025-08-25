import { Pagination, Table } from "react-bootstrap";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { endpoints, authApis } from "../../Services/Apis";

const ManagerGuess = () => {
    const [fixtures, setFixtures] = useState();
    const [totalPage, setTotalPage] = useState();
    const [page, setPage] = useState(1);
    const [pageSelected, setPageSelected] = useState(1);

    const getFixturesPredict = async () => {
        try {
            const response = await authApis().get(endpoints.getMatchesGuessAdmin(page));
            setFixtures(response.data);
            setTotalPage(response.data[0].totalPage);
            console.log(totalPage)
        } catch (error) {
            console.error("Error fetching fixtures:", error);
        }
    }

    useEffect(() => {
        getFixturesPredict();
    }, [page]);

    return (
        <>
            <div>
                <div className="text-center mt-4">
                    <h3>Quản lý minigame</h3>
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
                                        <td>{fixture.leagueName}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={fixture.logoNameHome} alt={fixture.teamNameHome} />{fixture.teamNameHome}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={fixture.logoNameAway} alt={fixture.teamNameAway} />{fixture.teamNameAway}</td>
                                        <td>{fixture.matchTime}</td>
                                        <td>
                                            <Link to={`/admin/award?matchId=${fixture.matchId}`} className="btn btn-primary mx-4">Xem đự đoán chính xác</Link>
                                        </td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </Table>
                    <div className="" style={{ marginLeft: "550px" }}>
                        <Pagination>
                            <Pagination.First onClick={() => { setPage(1); getFixturesPredict(); setPageSelected(1) }} />
                            <Pagination.Prev onClick={() => { setPage(page - 1); getFixturesPredict(); setPageSelected(page - 1) }} />
                            {totalPage && [...Array(totalPage)].map((_, index) => (
                                <div className={`${pageSelected === index + 1 ? "bg-primary" : ""}`}>
                                    <Pagination.Item key={index} onClick={() => { setPage(index + 1); getFixturesPredict(); setPageSelected(index + 1) }}>
                                        {index + 1}
                                    </Pagination.Item>
                                </div>
                            ))}
                            <Pagination.Next onClick={() => { setPage(page + 1); getFixturesPredict(); setPageSelected(page + 1) }} />
                            <Pagination.Last onClick={() => { setPage(totalPage); getFixturesPredict(); setPageSelected(totalPage) }} />
                        </Pagination>
                    </div>
                </div>
            </div>
        </>
    );
}

export default ManagerGuess;