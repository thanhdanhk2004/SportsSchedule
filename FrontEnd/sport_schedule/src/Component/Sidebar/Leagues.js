import React, { useState, useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import api, { endpoints } from "../../Services/Apis";
import '../../Style/index.css'
import { Nav, NavLink } from "react-bootstrap";
import { useNavigate, useLocation } from "react-router-dom";

const Leagues = () => {
    const [leagues, setLeagues] = new useState([])
    const navigate = useNavigate()
    const location = useLocation() // Lay duong dan hien tai
    const today = new Date()

    const handlePath = (leagueId) => {
        if(location.pathname.startsWith("/ranking"))
            navigate(`/ranking?leagueId=${leagueId}&season=${today.getFullYear()}`);
        else if(location.pathname.startsWith("/") || location.pathname.startsWith("/fixtures"))
            navigate(`/fixtures/${leagueId}`)
    }

    useEffect(() => {
        const fetchLengues = async () => {
            try {
                const res = await api.get(endpoints.league)
                setLeagues(res.data.leagues)
            } catch (err) {
                alert(err.response.data.message)
            }
        };

        fetchLengues()
    }, [])

    return (
        <div className="p-3" style={{ width: "300px" }}>
            <div className="mb-4 bg-gray">
                <div className="bg-secondary text-white fw-bold text-uppercase px-3 py-2">
                    Giải nổi bật
                </div>
                <ul className="list-group list-group-flush">
                    {leagues.map((league) => (
                        <li key={league.id} className="list-group-item p-0">
                            <Nav.Link onClick={() => handlePath(league.id)} className="hover-link d-block px-3 py-2">
                                <strong>{league.name}</strong>
                            </Nav.Link>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default Leagues