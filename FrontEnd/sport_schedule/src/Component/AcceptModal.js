import {Modal, Button} from "react-bootstrap"

function AcceptModal({show, handleClose}){
    return(
      <Modal show={show} onHide={handleClose} centered>
        <Modal.Header closeButton>
          <Modal.Title>Đăng bài thành công 🎉</Modal.Title>
        </Modal.Header>
        <Modal.Body style={{minHeight: "200px"}}>
            <div className="text-center mt-5">
                <h5>Bài viết của bạn đã được gửi đến admin để duyệt. Vui lòng kiểm tra email thường xuyên</h5>
            </div>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="success" onClick={handleClose}>
            OK
          </Button>
        </Modal.Footer>
      </Modal>
    );
}

export default AcceptModal