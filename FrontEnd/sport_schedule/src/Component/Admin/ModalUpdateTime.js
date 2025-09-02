import { useEffect, useState } from "react";
import { Modal, Form, Button } from "react-bootstrap";
import { authApis, endpoints } from "../../Services/Apis";

function ModalUpdateTime({ show, onHide, fixture}) {

    const [time, setTime] = useState("");

    const validateTime = (time) => {
        const timePattern = /^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])\s(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$/
        return timePattern.test(time)
    };

    const handleUpdateTime = async () => {
        if(validateTime(time) === false) {
            alert("Định dạng không hợp lệ");
            return;
        }
        try {
            const response = await authApis().patch(`${endpoints.updateTimeFixture(fixture.matchId)}?time=${time}`);
            if (response.status === 200) {
                alert("Cập nhật thời gian thành công"); 
                onHide();
            }
        } catch (error) {
            console.error("Error updating fixture time:", error);
        }
    };

    useEffect(() => {
        if(fixture){
            setTime(fixture.time)
        }
    },[fixture])

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title>Thời gian</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group className="mb-3">
                        <Form.Label>Nhập thời gian</Form.Label>
                        <Form.Control type="text" name="time" placeholder="Nhập vào đây..."  required
                            onChange={(e) => setTime(e.target.value)} value={time}
                        />
                    </Form.Group>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onHide}>
                    Đóng
                </Button>
                <Button variant="primary" onClick={handleUpdateTime}>
                    Cập nhật
                </Button>
            </Modal.Footer>
        </Modal>
    );
}

export default ModalUpdateTime;