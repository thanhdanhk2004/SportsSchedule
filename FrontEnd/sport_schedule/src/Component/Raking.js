import { Table, Image } from "react-bootstrap"
import api, { endpoints } from "../Services/Apis"
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";

const Ranking = () => {

    const [ranking, setRanking] = useState()
    const [rankingPrams] = useSearchParams()
    const league_id = rankingPrams.get("leagueId")
    const season = rankingPrams.get("season")

    const getRanking = async () => {
        try {

            const res = await api.get(endpoints.ranking, { params: { league_id, season } })
            setRanking(res.data)
        } catch (err) {
            alert(err)
        }
    }

    useEffect(() => {
        getRanking()
    })

    return (
        <div className="container mt-4">
            <Table striped bordered hover responsive className="align-middle text-center">
                <thead>
                    <tr>
                        <th>TT</th>
                        <th className="text-center w-25">Đội</th>
                        <th>Trận</th>
                        <th>Thắng</th>
                        <th>Hòa</th>
                        <th>Bại</th>
                        <th>Hiệu số</th>
                        <th>Điểm</th>
                    </tr>
                </thead>
                <tbody>
                    {ranking && ranking.map((team, idx) => (
                        <tr key={idx}>
                            <td>
                                <span>{idx + 1}</span>
                            </td>
                            <td className="d-flex align-items-center w-auto" >
                                <div><Image src={team.logo} alt={team.team} width={30} height={30} className="me-2" /></div>
                                <div>{team.teamName}</div>
                            </td>
                            <td>{team.played}</td>
                            <td>{team.win}</td>
                            <td>{team.draw}</td>
                            <td>{team.loss}</td>
                            <td>{team.difference}</td>
                            <td>{team.point}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    );
}

export default Ranking