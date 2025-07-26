import { useState } from 'react';
import { Container, Row, Col, Form, InputGroup } from 'react-bootstrap';
import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css"

const Schedule = () => {
    const [selectedIndex, setSelectedIndex] = useState(0);
    const [selectedIndexMatches, setSelectedIndexMatches] = useState(0)
    var today = new Date()

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

    function get_date(date, quantity) {
        const newDate = new Date(date)
        newDate.setDate(newDate.getDate() + quantity)
        const day = String(newDate.getDate()).padStart(2, '0')
        const month = String(newDate.getMonth() + 1).padStart(2, '0')
        return `${day}/${month}`
    }

    const dates = [
        { label: "Hôm nay", sub: get_day(today.getDay()) },
        { label: "Ngày mai", sub: get_day((today.getDay() + 1)) },
        { label: get_date(today, 2), sub: get_day((today.getDay() + 2)) },
        { label: get_date(today, 3), sub: get_day((today.getDay() + 3)) },
        { label: get_date(today, 4), sub: get_day((today.getDay() + 4)) },
        { label: get_date(today, 5), sub: get_day((today.getDay() + 5)) },
        { label: get_date(today, 6), sub: get_day((today.getDay() + 6)) },
        { label: "Chọn", sub: "ngày" },
    ];

    const matches = [
        {
            time: "17:00",
            date: "25/07",
            league: "GHCLB",
            home: "Olympiacos",
            away: "Norwich City",
            score: "3 - 0",
            halftime: "H1: 1-0",
        },
        {
            time: "17:00",
            date: "25/07",
            league: "GHCLB",
            home: "Yokohama FC",
            away: "Sociedad",
            score: "1 - 2",
            halftime: "H1: 0-2",
        },
        {
            time: "19:00",
            date: "25/07",
            league: "GHCLB",
            home: "Freiburg",
            away: "Dynamo Dresden",
            score: "3 - 3",
            halftime: "H1: 0-1",
        },
        {
            time: "20:00",
            date: "25/07",
            league: "GHCLB",
            home: "Hannover 96",
            away: "Hansa Rostock",
            score: "vs",
        },
        {
            time: "20:30",
            date: "25/07",
            league: "GHCLB",
            home: "Mainz 05",
            away: "Seekirchen",
            score: "vs",
        },
    ];

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
                                    console.log("Ngày đã chọn:", date)
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
                            onClick={() => setSelectedIndex(index)}>
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

                <div className='d-flex justify-content-center mt-3'>
                    <div className="justify-content-center text-center bg-white rounded shadow p-3 mt-3 w-75">
                        <div className="fw-semibold mb-2">Lịch thi đấu MLS Nhà Nghề Mỹ</div>
                        {matches.map((m, i) => (
                            <div key={i} className="d-flex border-bottom py-4 mt-2 gap-3 align-items-center">
                                <div style={{ width: "150px" }} className="text-sm text-start">
                                    {m.time} - {m.date}
                                </div>

                                <div className="flex-grow-1 d-flex justify-content-center" style={{ paddingRight: "170px" }}>
                                    <div className="match-row d-flex align-items-center justify-content-between border-bottom py-2">
                                        <div className="team d-flex align-items-center gap-2" style={{width:"150px"}}>
                                            {m.home_logo && <img src={m.home_logo} alt="home" width={20} />}
                                            <span className="team-name">{m.home}</span>
                                        </div>

                                        <div className={`score-box px-2 py-1 fw-bold rounded text-white ${m.score === "vs" ? "bg-secondary" : "bg-success"}`}>
                                            {m.score}
                                        </div>

                                        <div className="team d-flex align-items-center gap-2 justify-content-start px-4" style={{width:"150px"}}>
                                            <span className="team-name text-end">{m.away}</span>
                                            {m.away_logo && <img src={m.away_logo} alt="away" width={20} />}
                                        </div>
                                    </div>

                                </div>

                                {m.status && (
                                    <span className="badge bg-light text-muted border px-2 py-1 text-uppercase">
                                        {m.status}
                                    </span>
                                )}
                            </div>

                        ))}
                    </div>
                </div>

            </div>
        </Container>
    );
}

export default Schedule