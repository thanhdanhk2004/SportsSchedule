import { Modal } from "react-bootstrap"

function ModalPlayer({show, close, player}){
    const positions = {
        "G" :"Thủ môn",
        "D":"Hậu vệ",
        "M":"Tiền vệ",
        "F":"Tiền đạo"
    }

    return (
        <Modal show={show} onHide={close} centered size="lg">
            <Modal.Header closeButton>
                <Modal.Title>Thông tin cầu thủ</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="d-flex flex-wrap">
                    <div className="text-center p-3">
                        <div
                            style={{
                                backgroundColor: "#00a99d",
                                color: "white",
                                width: "50px",
                                height: "50px",
                                borderRadius: "8px",
                                display: "flex",
                                alignItems: "center",
                                justifyContent: "center",
                                fontSize: "20px",
                                fontWeight: "bold",
                                margin: "0 auto"
                            }}
                        >
                            {player.number}
                        </div>
                        <h4 className="mt-2">{player.name}</h4>
                        <img
                            src={player.image}
                            alt={player.name}
                            style={{
                                width: "200px",
                                borderRadius: "5px",
                                marginTop: "10px"
                            }}
                        />
                    </div>

                    <div className="p-3 flex-grow-1">
                        <div
                            style={{
                                border: "1px solid #ddd",
                                borderRadius: "5px",
                                padding: "10px"
                            }}
                        >
                            <table className="table table-borderless mb-0">
                                <tbody>
                                    <tr>
                                        <td>Nationality</td>
                                        <td>
                                            
                                            {player.nationaly}
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Position</td>
                                        <td>{positions[player.position]}</td>
                                    </tr>
                                    <tr>
                                        <td>Height</td>
                                        <td>{player.height}</td>
                                    </tr>
                                    <tr>
                                        <td>Weight</td>
                                        <td>{player.weight}</td>
                                    </tr>
                                    <tr>
                                        <td>Current Team</td>
                                        <td>{player.nameCLB}</td>
                                    </tr>
                                    <tr>
                                        <td>Birthday</td>
                                        <td>{player.birthday ? player.birthday.split(" ")[0] : ""}</td>
                                    </tr>
                                    <tr>
                                        <td>Age</td>
                                        <td>{player.age}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </Modal.Body>
            
        </Modal>
    )
}

export default ModalPlayer