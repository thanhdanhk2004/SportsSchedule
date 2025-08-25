import { Table } from "react-bootstrap";
import { endpoints, authApis } from "../../Services/Apis";
import { useState, useEffect } from "react";


const ManagerLeague = () => {
    const [leagues, setLeagues] = useState();

    const getLeagues = async () => {
        try {
            var res = await authApis().get(endpoints.getLeaguesAdmin);
            if (res.status === 200) {
                setLeagues(res.data);
            }
        } catch (err) {
            console.log(err);
        }
    }

    const handleDeleteLeague = async (leagueId) => {
        try {
            if (window.confirm("Bạn có chắc chắn muốn xóa giải đấu này không?")) {
                var res = await authApis().delete(endpoints.deleteLeague(leagueId));
                if (res.status === 200) {
                    alert("Xóa giải đấu thành công");
                    getLeagues();
                }
            }
        } catch (err) {
            console.log(err);
        }
    }

    useEffect(() => {
        getLeagues();
    }, []);


    return (
        <>
            <div>
                <div className="text-center mt-4">
                    <h3>Giải đấu</h3>
                </div>
                <div className="mt-5 mx-5" style={{ marginBottom: "200px" }}>
                    <Table className="" style={{ marginLeft: "50px", width: "1350px" }} bordered hover>
                        <thead className="text-center">
                            <tr>
                                <th>STT</th>
                                <th>Logo</th>
                                <th>Tên giải đấu</th>
                                <th>Quốc gia</th>
                                <td style={{ width: "300px" }}>Chức năng</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                leagues && leagues.map((league, index) => (
                                    <tr>
                                        <td className="text-center">{index + 1}</td>
                                        <td className="text-center"><img src={league.logo} alt={league.leagueName} style={{ width: "50px", height: "50px" }} /></td>
                                        <td className="text-center">{league.leagueName}</td>
                                        <td className="text-center">{league.country}</td>
                                        <td className="text-center">
                                            <button className="btn btn-danger mx-3" onClick={() => handleDeleteLeague(league.leagueId)}>Delete</button>
                                        </td>
                                    </tr>
                                ))
                            }

                        </tbody>
                    </Table>

                </div>
            </div>
        </>
    );
}

export default ManagerLeague;