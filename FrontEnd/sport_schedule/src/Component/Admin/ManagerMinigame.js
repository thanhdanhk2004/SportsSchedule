import { useEffect } from "react";
import { endpoints, authApis } from "../../Services/Apis";
import { useState } from "react";
import { Table } from "react-bootstrap";
import { Pagination } from "react-bootstrap";
import { Link } from "react-router-dom";

const ManagerMinigame = () => {
    const [fixtures, setFixtures] = useState();
    const [totalPage, setTotalPage] = useState();
    const [page, setPage] = useState(1);
    const [pageSelected, setPageSelected] = useState(1);

    const getFixturesPredict = async () => {
        try {
            const response = await authApis().get(endpoints.getFixturesPredict(page));
            setFixtures(response.data);
            setTotalPage(response.data[0].totalPage);
            console.log(totalPage)
        } catch (error) {
            console.error("Error fetching fixtures:", error);
        }
    }

    const handleMinigame = async (matchId, status) => {
        try {
            if (window.confirm("Bạn có chắc chắn muốn cập nhật trạng thái minigame cho trận đấu này không?")) {
                const res = await authApis().patch(`${endpoints.updateStatusPredictFixture(matchId)}?status=${status}`);
                if (res.status === 200) {
                    alert("Cập nhật thành công")
                    getFixturesPredict();
                }
            } 
        } catch (err) {
            console.error("Error updating minigame status:", err);
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
                                        <td>{fixture.nameLeague}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={fixture.logoHome} alt={fixture.teamHome} />{fixture.teamHome}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={fixture.logoAway} alt={fixture.teamAway} />{fixture.teamAway}</td>
                                        <td>{fixture.time}</td>
                                        <td>
                                            <button className="btn btn-danger mx-1" disabled={fixture.predict === true} onClick={() => { handleMinigame(fixture.matchId, true)}}>Gán minigame</button>
                                            <button className="btn btn-primary" disabled={fixture.predict === false} onClick={() => { handleMinigame(fixture.matchId, false)}}>Xóa minigame</button>
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
};

export default ManagerMinigame;