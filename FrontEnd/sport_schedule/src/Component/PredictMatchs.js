import api, { endpoints, authApis } from "../Services/Apis"
import { AuthContext } from "../Context/AuthContext"
import { useContext, useEffect, useState } from "react"
import { Card, Row, Col, Button, Form } from "react-bootstrap";
import Login from "./Login"

const PredictMatch = () => {
    const { isLogin } = useContext(AuthContext)
    const [showLogin, setShowLogin] = useState(false)
    const [matchesGuess, setMatchesGuess] = useState(null)
    const [guesses, setGuesses] = useState({})
    const today = new Date()

    const getMatchesGuess = async () => {
        try {
            console.log(today.getDate().toString() + "/" + (today.getMonth() + 1).toString())
            var res = await api.get(endpoints.getMatchesGuess(today.getDate().toString() + "-" + (today.getMonth() + 1).toString()))
            if (res.status === 200)
                setMatchesGuess(res.data)
        } catch (err) {
            console.log(err)
        }
    }

    const handleChange = (matchId, e) => {
        const { name, value } = e.target
        setGuesses(prev => ({
            ...prev,
            [matchId]: {
                ...prev[matchId],
                [name]: value
            }
        }))
    }

    const addGuess = async (matchId) => {
        try {
            if (!isLogin) {
                if (window.confirm("Vui long dang nhap de du doan")) {
                    setShowLogin(true)
                }
            } else {
                const guess = guesses[matchId]
                if (!guess || guess.PredictHomeScore === null || guess.PredictAwayScore === null)
                    alert("Vui long dien du doan")
                else {
                    var res = await authApis().post(endpoints.addGuess(matchId), guess)
                    alert("Dự đoán thành công")
                    setGuesses(prev => ({
                        ...prev,
                        [matchId]: { PredictHomeScore: "", PredictAwayScore: "" }
                    }))
                }
            }
        } catch (err) {
            alert("Trận đấu này đã được bạn dự đoán")
        }
    }

    useEffect(() => {
        getMatchesGuess()
    }, [])

   return (
        <div className="container py-4">
            <h3 className="text-center mb-4 text-success">Cuồng nhiệt cùng trận đấu</h3>
            <p className="text-center text-muted">Dự đoán hay, rinh quà ngay</p>
            {
                matchesGuess && matchesGuess.map((match) => {
                    const guess = guesses[match.matchId] || { PredictHomeScore: "", PredictAwayScore: "" }

                    return (
                        <Card key={match.matchId} className="mb-4 shadow-lg border-0 rounded-4">
                            <Card.Header className="text-white rounded-top-4" style={{ backgroundColor: "#7c4dff" }}>
                                <strong>MINI GAME SỐ {match.matchId}</strong>
                            </Card.Header>
                            <Card.Body>
                                <Row className="align-items-center">
                                    {/* Team A */}
                                    <Col xs={12} md={4} className="text-center">
                                        <img src={match.logoNameHome} alt={match.teamNameHome} style={{ width: 60 }} />
                                        <h5 className="mt-2">{match.teamNameHome}</h5>
                                    </Col>

                                    {/* Input score */}
                                    <Col xs={12} md={4} className="text-center">
                                        <p className="mb-2 text-muted">
                                            {match.matchTime && match.matchTime.split(" ")[1].substring(0, 5) + " " + match.matchTime.split(" ")[0]}
                                        </p>
                                        <div className="d-flex justify-content-center align-items-center mb-3">
                                            <Form.Control
                                                type="number"
                                                min={0}
                                                name="PredictHomeScore"
                                                value={guess.PredictHomeScore}
                                                className="mx-2 text-center"
                                                style={{ width: "60px" }}
                                                onChange={(e) => handleChange(match.matchId, e)}
                                            />
                                            <span>-</span>
                                            <Form.Control
                                                type="number"
                                                min={0}
                                                name="PredictAwayScore"
                                                value={guess.PredictAwayScore}
                                                className="mx-2 text-center"
                                                style={{ width: "60px" }}
                                                onChange={(e) => handleChange(match.matchId, e)}
                                            />
                                        </div>
                                        <Button variant="primary" className="px-4" onClick={() => addGuess(match.matchId)}>
                                            GỬI DỰ ĐOÁN
                                        </Button>
                                        <p className="mt-2 text-muted">Cơ hội trúng ngay 500.000 đồng!!!</p>
                                    </Col>

                                    {/* Team B */}
                                    <Col xs={12} md={4} className="text-center">
                                        <img src={match.logoNameAway} alt={match.teamNameAway} style={{ width: 60 }} />
                                        <h5 className="mt-2">{match.teamNameAway}</h5>
                                    </Col>
                                </Row>
                            </Card.Body>
                        </Card>
                    )
                })
            }
        </div>
    );
}

export default PredictMatch