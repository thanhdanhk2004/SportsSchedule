import { useState } from 'react';
import { Container, Row, Col, Form, InputGroup } from 'react-bootstrap';
import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css"

const Schedule = () => {
    const [selectedIndex, setSelectedIndex] = useState(0);
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


    const dates = [
        { label: "Hôm nay", sub: get_day(today.getDay()) },
        { label: "Ngày mai", sub: get_day((today.getDay() + 1)) },
        { label: (today.getDate() + 2) + "/" + (today.getMonth() + 1), sub: get_day((today.getDay() + 2)) },
        { label: (today.getDate() + 3) + "/" + (today.getMonth() + 1), sub: get_day((today.getDay() + 3)) },
        { label: (today.getDate() + 4) + "/" + (today.getMonth() + 1), sub: get_day((today.getDay() + 4)) },
        { label: (today.getDate() + 5) + "/" + (today.getMonth() + 1), sub: get_day((today.getDay() + 5)) },
        { label: (today.getDate() + 6) + "/" + (today.getMonth() + 1), sub: get_day((today.getDay() + 6)) },
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
                            className={`px-3 py-2 border ${tab === "Tất cả" ? "bg-success text-white" : "bg-light text-black"
                                }`}
                            style={{ minWidth: "100px" }}
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

                <div className='d-flex justify-content-center mt-2'>
                    <div className="justify-content-center text-center bg-white rounded shadow p-3 mt-3 w-75">
                        <div className="fw-semibold mb-2">Lịch thi đấu MLS Nhà Nghề Mỹ</div>
                        {matches.map((m, i) => (
                            <div key={i} className="d-flex border-bottom py-2 gap-3 position-relative">
                                <div style={{ width: "150px" }} className=" text-sm">
                                    {m.time} - {m.date}
                                </div>
                                <div className="position-absolute start-50 translate-middle-x">
                                    <div className="d-flex gap-3">
                                        <div className="d-flex align-items-center gap-2">
                                            {m.home_logo && <img src={m.home_logo} alt="home" width={20} />}
                                            <span style={{ color: m.home_color || "#000" }}>{m.home}</span>
                                        </div>
                                        <span
                                            className={`text-white fw-bold px-2 py-1 rounded ${m.score === "vs" ? "bg-secondary" : "bg-success"}`}
                                        >
                                            {m.score}
                                        </span>
                                        <div className="d-flex align-items-center gap-2">
                                            {m.away_logo && <img src={m.away_logo} alt="away" width={20} />}
                                            <span style={{ color: m.away_color || "#000" }}>{m.away}</span>
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