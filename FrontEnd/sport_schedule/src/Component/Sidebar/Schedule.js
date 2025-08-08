import { useEffect, useState } from 'react';
import { Container, Row, Col, Form, InputGroup } from 'react-bootstrap';
import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css"
import SeeModal from "../See"
import api, { endpoints } from "../../Services/Apis"

const Schedule = () => {
    const [selectedIndex, setSelectedIndex] = useState(0);
    const [selectedIndexMatches, setSelectedIndexMatches] = useState(0)
    const [seeModal, setSeeModal] = useState(false)
    var today = new Date()
    const [error, setErrors] = useState("")
    const [matches, setMatches] = useState([])
    const [groupLeague, setGroupLeague] = useState({})
    const [matchSelected, setMatcheSelected] = useState(null)

    //Lấy thứ
    function get_day(day) {
        switch (day) {
            case 0:
                return "Chủ nhật"
            case 1:
                return "Thứ 2"
            case 2:
                return "Thứ 3"
            case 3:
                return "Thứ 4"
            case 4:
                return "Thứ 5"
            case 5:
                return "Thứ 6"
            case 6:
                return "Thứ 7"
            default:
                return get_day(day - 7)
        }
    }

    //Láy ngày
    function get_date(date, quantity) {
        const newDate = new Date(date)
        newDate.setDate(newDate.getDate() + quantity)
        const day = String(newDate.getDate()).padStart(2, '0')
        const month = String(newDate.getMonth() + 1).padStart(2, '0')
        return `${day}/${month}`
    }

    const dates = [
        { label: "Hôm nay", sub: get_day(today.getDay()) },
        { label: get_date(today, 1), sub: get_day((today.getDay() + 1)) },
        { label: get_date(today, 2), sub: get_day((today.getDay() + 2)) },
        { label: get_date(today, 3), sub: get_day((today.getDay() + 3)) },
        { label: get_date(today, 4), sub: get_day((today.getDay() + 4)) },
        { label: get_date(today, 5), sub: get_day((today.getDay() + 5)) },
        { label: get_date(today, 6), sub: get_day((today.getDay() + 6)) },
        { label: "Chọn", sub: "ngày" },
    ];

    //Gom các trận đấu cùng một giải
    const groupNameLeague = (matches) => {
        return matches.reduce((acc, match) => {
            if (!acc[match.leagueName])
                acc[match.leagueName] = []
            acc[match.leagueName].push(match);
            return acc
        }, {})
    }


    // Lây các trận đấu
    const getFixture = async (date) => {
        try {
            const res = await api.get(endpoints.fixtures, { params: { date: date } })
            setMatches(res.data)
            const grouped = groupNameLeague(res.data)
            setGroupLeague(grouped)
        } catch (err) {
            setErrors("Vui lòng kiểm tra lại mạng")
            alert(error)
        }
    }

    useEffect(() => {
        const date = get_date(today, 0)
        getFixture(date)
    }, [])


    return (
        <Container className="mt-4">
            <Row className="justify-content-center text-center">
                {dates.map((item, index) => (
                    item.label === "Chọn" ?
                        (<Col key={index} xs={6} sm={3} md={1}
                            className={"py-2 border bg-light"}
                            style={{ cursor: "pointer", minWidth: "100px" }}>
                            <DatePicker
                                selected={null}
                                onChange={(date) => {
                                    const day = date.getDate().toString().padStart(2, '0')
                                    const month = (date.getMonth() + 1).toString().padStart(2, '0')
                                    getFixture(`${day}/${month}`)
                                }}
                                customInput={
                                    <div className="text-center fw-bold">
                                        <div>{item.label}</div>
                                        <div>{item.sub}</div>
                                    </div>
                                }
                                popperPlacement="bottom"
                                dateFormat="dd/MM/yyyy"
                            />
                        </Col>) : (<Col key={index} xs={6} sm={3} md={1}
                            className={`py-2 border ${selectedIndex === index ? "bg-success text-white" : "bg-light"}`}
                            style={{ cursor: "pointer", minWidth: "100px" }}
                            onClick={() => { setSelectedIndex(index); getFixture(item.label === "Hôm nay" ? get_date(today, 0) : item.label) }}>
                            <div className="fw-bold">{item.label}</div>
                            <div>{item.sub}</div>
                        </Col>)
                ))}
            </Row>

            <h4 className="text-center mt-4">Lịch thi đấu bóng đá</h4>

            <Row className="justify-content-center mt-3">
                <Col xs={12} sm={8} md={5}>
                    <InputGroup>
                        <Form.Control
                            placeholder="Tìm kiếm trận đấu, giải đấu"
                        />
                        <button className='btn btn-primary'>
                            Search
                        </button>
                    </InputGroup>
                </Col>
            </Row>


            <div>
                <div className="d-flex justify-content-center gap-1 mt-4 border-bottom">
                    {["Tất cả", "HOT", "Vừa diễn ra", "Đang diễn ra", "Sắp diễn ra"].map((tab, i) => (
                        <button
                            key={i}
                            className={`py-2 border ${selectedIndexMatches === i ? "bg-success text-white" : "bg-light"}`}
                            style={{ minWidth: "100px" }}
                            onClick={() => setSelectedIndexMatches(i)}
                        >
                            {tab === "HOT" ? (
                                <span>
                                    HOT <span style={{ color: "red" }}>⚡</span>
                                </span>
                            ) : (
                                tab
                            )}
                        </button>
                    ))}
                </div>

                {Object.entries(groupLeague).map(([league, matches]) => (
                    <div className='d-flex justify-content-center mt-3'>
                        <div className="justify-content-center text-center bg-white rounded shadow p-3 mt-3 w-75">
                            <div className="fw-semibold mb-2">{league}</div>
                            {matches.map((m) => (
                                <div className="d-flex border-bottom py-4 mt-2 gap-3 align-items-center">
                                    <div style={{ width: "150px" }} className="text-sm text-start">
                                        <p>
                                            {m.time.split(" ")[0]}
                                        </p>
                                        <p style={{ paddingLeft: "20px" }}>
                                            {m.time.split(" ")[1].substring(0, 5)}
                                        </p>
                                    </div>

                                    <div className="flex-grow-1 d-flex justify-content-center">
                                        <div className="match-row d-flex align-items-center justify-content-between border-bottom py-2">
                                            <div className="team d-flex align-items-center gap-2" style={{ width: "150px" }}>
                                                {m.logoHome && <img src={m.logoHome} alt="home" width={20} />}
                                                <span className="team-name" style={{width: "150px"}}>{m.nameHome}</span>
                                            </div>

                                            <div key={m.matchId} className={`score-box px-2 py-1 fw-bold rounded text-white ${m.goalHomeFullTime === null ? "bg-secondary" : "bg-success"}`} style={{ height: "35px", cursor: "pointer" }} onClick={() => {setSeeModal(true); setMatcheSelected(m)}}>
                                                <span>{m.goalHomeFullTime === null ? "vs" : m.goalHomeFullTime + " - " + m.goalAwayFullTime}</span>
                                            </div>
                                            <SeeModal show={seeModal} handleClose={() => setSeeModal(false)}  match={matchSelected}/>

                                            <div className="team d-flex align-items-center gap-2 justify-content-start" style={{ width: "150px" }}>
                                                <span className="team-name text-end" style={{width: "150px"}}>{m.nameAway}</span>
                                                {m.logoAway && <img src={m.logoAway} alt="away" width={20} />}
                                            </div>
                                        </div>
                                    </div>

                                    {m.goalHomeFullTime === null && (
                                        <>
                                            <div className='btn btn-info'>Hẹn lịch</div>
                                            <div className='btn btn-success'>Minigame</div>
                                        </>
                                    )}

                                </div>

                            ))}

                        </div>
                    </div>
                ))}

            </div>
        </Container>
    );
}

export default Schedule