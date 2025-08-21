import { useContext, useEffect, useState } from 'react';
import { Container, Row, Col, Form, InputGroup } from 'react-bootstrap';
import DatePicker from "react-datepicker"
import "react-datepicker/dist/react-datepicker.css"
import SeeModal from "../See"
import api, { endpoints, authApis } from "../../Services/Apis"
import { Nav } from 'react-bootstrap';
import { AuthContext } from '../../Context/AuthContext';
import Login from '../Login';
import { Cookies } from "react-cookie";


const Schedule = () => {
    const [selectedIndex, setSelectedIndex] = useState(0);
    const [selectedIndexMatches, setSelectedIndexMatches] = useState(0)
    const [seeModal, setSeeModal] = useState(false)
    var today = new Date()
    const [error, setErrors] = useState("")
    const [groupLeague, setGroupLeague] = useState({})
    const [matchSelected, setMatcheSelected] = useState(null)
    const [value, setValue] = useState("")
    const [groupFixturesSearch, setGroupFixturesSearch] = useState({})
    const [yearSelected, setYearSelected] = useState(today.getFullYear())

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
            const grouped = groupNameLeague(res.data)
            setGroupLeague(grouped)
        } catch (err) {
            setErrors("Vui lòng kiểm tra lại mạng")
            alert(error)
        }
    }


    //Tim kiem giai dau hoac tran dau hom nay
    const groupedSearch = (text) => {
        return Object.entries(groupLeague || {}).reduce((acc, [leagueName, matches]) => {
            if (leagueName.toLowerCase().includes(text.toLowerCase())) {
                acc[leagueName] = matches;
            }
            else {
                const filteredMatches = matches.filter(match =>
                    match.nameHome.toLowerCase().includes(text.toLowerCase()) ||
                    match.nameAway.toLowerCase().includes(text.toLowerCase())
                );

                if (filteredMatches.length > 0) {
                    acc[leagueName] = filteredMatches;
                }
            }
            return acc;
        }, {});
    };

    //Goi ham 
    const search = (text) => {
        try {
            const grouped_search = groupedSearch(text)
            setGroupFixturesSearch(grouped_search)
        } catch (err) {
            setErrors(err)
            console.log(error)
        }
    }

    /*Xu ly hen lich*/
    const { isLogin } = useContext(AuthContext)
    const [showLogin, setShowLogin] = useState(false)
    const [showRegister, setShowRegister] = useState(false)
    const [matchesAppointmented, setMatchesAppointmented] = useState()
    const cookie = new Cookies()

    const getMatchesAppointmented = async () => {
        try {
            var res = await authApis().get(endpoints.getMatchesAppointmented)
            setMatchesAppointmented(res.data)
            console.log(matchesAppointmented)
        } catch (err) {
            console.log(err)
        }
    }

    const handleLoginSuccess = () => {
        getMatchesAppointmented()
    }

    const handleAppontment = async (matchId) => {
        if (!isLogin) {
            if (window.confirm("Vui lòng đăng nhập để hẹn lịch")) {
                setShowLogin(true)
            }
        }
        else {
            try {
                var res = await authApis().post(endpoints.addAppointment(matchId))
                if (res.status === 200) {
                    alert("Hẹn lịch thành công")
                    getMatchesAppointmented()
                }
            } catch (err) {
                console.log(err)
            }
        }
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps 
    //(load trang khi vua chay len)
    useEffect(() => {
        const date = get_date(today, 0)
        getFixture(date)
        if (cookie.get('token')!== "") {
            getMatchesAppointmented()
        }
    },[])

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
                                    setValue("")
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
                            value={value}
                            onChange={(e) => setValue(e.target.value)}
                            onInput={(e) => search(e.target.value)}
                        />
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

                {groupLeague && Object.keys(groupLeague).length > 0 ? Object.entries(value === "" ? groupLeague : groupFixturesSearch).map(([league, matches]) => (
                    <div className='d-flex justify-content-center mt-3'>
                        <div className="justify-content-center text-center bg-white rounded shadow p-3 mt-3 w-75">
                            <div className="fw-semibold mb-2 league-name d-flex justify-content-between aline-item-center">
                                <div className="text-center flex-grow-1">
                                    {league}
                                </div>
                                <div style={{ marginTop: "-5px" }}>
                                    <Nav>
                                        <Nav.Link href={`/ranking?leagueId=${matches[0].leagueId}&season=${yearSelected}`}>BXH</Nav.Link>
                                    </Nav>
                                </div>
                            </div>
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
                                                <span className="team-name" style={{ width: "150px" }}>{m.nameHome}</span>
                                            </div>

                                            <div key={m.matchId} className={`score-box px-2 py-1 fw-bold rounded text-white ${m.goalHomeFullTime === null ? "bg-secondary" : "bg-success"}`} style={{ height: "35px", cursor: "pointer" }} onClick={() => { setSeeModal(true); setMatcheSelected(m) }}>
                                                <span>{m.goalHomeFullTime === null ? "vs" : m.goalHomeFullTime + " - " + m.goalAwayFullTime}</span>
                                            </div>
                                            <SeeModal show={seeModal} handleClose={() => setSeeModal(false)} match={matchSelected} />

                                            <div className="team d-flex align-items-center gap-2 justify-content-start" style={{ width: "150px" }}>
                                                <span className="team-name text-end" style={{ width: "150px" }}>{m.nameAway}</span>
                                                {m.logoAway && <img src={m.logoAway} alt="away" width={20} />}
                                            </div>
                                        </div>
                                    </div>

                                    {m.goalHomeFullTime === null ? (
                                        <>
                                            <button disabled={matchesAppointmented && matchesAppointmented.includes(m.matchId)} onClick={() => handleAppontment(m.matchId)} className='btn btn-info'>Hẹn lịch</button>
                                        </>
                                    ) :
                                        <div className='bg-primary' style={{ width: "200px" }}>

                                        </div>}
                                    <Login show={showLogin} onHide={() => setShowLogin(false)} switchToRegister={() => { setShowLogin(false); setShowRegister(true)}} onLoginSuccess={() => handleLoginSuccess()} />
                                </div>
                            ))}

                        </div>
                    </div>
                )) :
                    <div className='d-flex justify-content-center mt-5'>
                        <h3 className='text text-danger'>Không tìm thấy trận đấu nào</h3>
                    </div>
                }
                {
                    Object.keys(groupFixturesSearch).length === 0 && value !== "" &&
                    <div className='d-flex justify-content-center mt-5'>
                        <h3 className='text text-danger'>Không tìm thấy trận đấu nào</h3>
                    </div>
                }

            </div>
        </Container>
    );
}

export default Schedule