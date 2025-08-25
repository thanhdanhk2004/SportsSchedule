import { Table } from "react-bootstrap";
import { Pagination } from "react-bootstrap";
import { endpoints, authApis } from "../../Services/Apis";
import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { use } from "react";

const ManagerAward = () => {
    const { search } = useLocation();
    const query = new URLSearchParams(search);
    const matchId = query.get("matchId");
    const [guessesExactly, setGuessesExactly] = useState();
    const [listAwardId, setListAwardId] = useState();

    const getGuessesExactly = async () => {
        try {
            var res = await authApis().get(endpoints.getGuessExactly(matchId));
            if (res.status === 200) {
                setGuessesExactly(res.data);
            }
        } catch (error) {
            console.error("Error fetching guess exactly:", error);
        }
    }

    const getListAwardId = async () => {
        try{
            var res = await authApis().get(endpoints.getListAward)
            if(res.status === 200){
                setListAwardId(res.data)
            }
        }catch(error){
            console.log(error)
        }
    }

    const handleAddAward = async (guessId) =>{
        try{
            var res = await authApis().post(`${endpoints.addAward}?guessId=${guessId}`)
            if(res.status === 200){
                alert("Thêm thành công")
                getListAwardId();
            }
        }catch(error){
            console.log(error)
        }
    }

    const handleUpdateAward = async (guessId) =>{
        try{
            var res = await authApis().patch(`${endpoints.updateAward(guessId)}`)
            if(res.status === 200){
                alert("Cập nhật thành công")
                getListAwardId();
            }
        }catch(error){
            console.log(error)
        }
    }

    useEffect(() => {
        getGuessesExactly();
        getListAwardId();
    }, []);
    

    return (
        <>
            <div>
                <div className="text-center mt-4">
                    <h3>Các dự đoán chính xác</h3>
                </div>
                <div className="mt-5 mx-5" style={{ marginBottom: "200px" }}>
                    <Table className="" style={{ marginLeft: "50px", width: "1350px" }} bordered hover>
                        <thead className="text-center">
                            <tr>
                                <th>STT</th>
                                <th>Đội nhà</th>
                                <th>Đội khách</th>
                                <th>Bàn thắng</th>
                                <th>Dự đoán</th>
                                <th>User Id</th>
                                <td style={{ width: "300px" }}>Chức năng</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                guessesExactly && guessesExactly.map((guess, index) => (
                                    <tr>
                                        <td className="text-center">{index + 1}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={guess.logoHome} alt={guess.teamHome} />{guess.nameHome}</td>
                                        <td><img style={{ width: "40px", height: "40px", marginRight: "5px" }} src={guess.logoAway} alt={guess.teamAway} />{guess.nameAway}</td>
                                        <td className="text-center">{guess.scoreHome} - {guess.scoreAway}</td>
                                        <td className="text-center">{guess.scorePredictHome} - {guess.scorePredictAway}</td>
                                        <td className="text-center">{guess.userId}</td>
                                        <td>
                                            <button className="btn btn-success mx-3" disabled={listAwardId.some(item => item.guessId === guess.guessId)} onClick={() => handleAddAward(guess.guessId)}>Trao thưởng</button>
                                            <button className="btn btn-danger" disabled={listAwardId.some(item => (item.guessId === guess.guessId && item.status === true)) || !listAwardId.some(item => item.guessId === guess.guessId)} onClick={() => handleUpdateAward(guess.guessId)}>Hoàn thành</button>
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

export default ManagerAward;