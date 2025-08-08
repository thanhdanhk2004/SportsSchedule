import { Button, Modal } from "react-bootstrap";
import '../Style/index.css'



function SeeModal({ show, handleClose, match }) {
    if(show == false)
        return null
    return (
        <Modal show={show} onHide={handleClose} centered size="lg">
            <Modal.Header closeButton>
                {match.goalHomeFullTime !== null ?
                    <Modal.Title>Kết quả trận đấu:</Modal.Title> :
                    <Modal.Title>Lịch trận đấu:</Modal.Title>
                }
            </Modal.Header>
            <Modal.Body>
                <div className="d-flex justify-content-around align-items-center mb-4">
                    <div className="text-center">
                        <img
                            src={match.logoHome}
                            alt={match.nameHome}
                            style={{ height: '80px' }}
                        />
                        <h5 className="mt-2">{match.nameHome}</h5>
                    </div>

                    <div className="text-center">
                        <h2 className="text-success fw-bold">{match.goalHomeFullTime !== null ? match.goalHomeFullTime + " - " + match.goalAwayFullTime : "Vs"}</h2>
                    </div>

                    <div className="text-center">
                        <img
                            src={match.logoAway}
                            alt={match.nameAway}
                            style={{ height: '80px' }}
                        />
                        <h5 className="mt-2">{match.nameAway}</h5>
                    </div>
                </div>

                <div className="text-center mb-3">
                    <p>Hiệp một: {match.goalHomeFullTime !== null ? match.goalHomeFirst + " - " + match.goalAwayFirst : "0 - 0"}</p>
                    <p>Thời gian: <strong>{match.time.split(" ")[1].substring(0, 5) + ",  " + match.time.split(" ")[0]}</strong></p>
                    <p>Giải đấu: {match.leagueName}</p>
                </div>

                {match.goalHomeFullTime !== null && (
                    <div className="d-grid">
                        <Button variant="success" size="lg" style={{ marginBottom: "5px" }}>Xem chi tiết</Button>
                    </div>
                )}
            </Modal.Body>
        </Modal >
    );
}

export default SeeModal