import React, { useState, useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import api, { endpoints } from "../../Services/Apis";
import '../../Style/index.css'

const League = () => {

    const [leagues, setLeagues] = new useState([])

    useEffect(() => {
        const fetchLengues = async () => {
            try {
                const res = await api.get(endpoints.league)
                setLeagues(res.data.leagues)
                console.log(res.data.leagues)
            } catch (err) {
                alert(err.response.data.message)
            }
        };

        fetchLengues()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <div className="bg-light border p-3" style={{ width: "250px" }}>
            <div className="mb-4">
                <div className="bg-secondary text-white fw-bold text-uppercase px-3 py-2">
                    Giải nổi bật
                </div>
                <ul className="list-group list-group-flush">
                    {leagues.map((league) => (
                        <li key={league.id} className="list-group-item p-0">
                            <a href="/login" className="hover-link d-block px-3 py-2">
                                {league.name}
                            </a>
                        </li>
                    ))}
                </ul>
            </div>

            <div>
                <div className="bg-secondary text-white fw-bold text-uppercase px-3 py-2">
                    Khu vực
                </div>
                <ul className="list-group list-group-flush">
                    <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                    <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                    <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>

                </ul>
            </div>
        </div>
    );
}

export default League