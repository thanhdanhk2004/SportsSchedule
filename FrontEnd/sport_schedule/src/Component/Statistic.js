import { Table, Container, Row, Col, Image } from "react-bootstrap";

const Statistic = ({ statisticTeamHome, statisticTeamAway, nameHome, nameAway, logoHome, logoAway }) => {
    return (
        <div>
            <Container className="mt-4 p-3 border rounded shadow-sm" style={{ width: "600px" }}>
                <h5 className="text-center fw-bold mb-4">SỐ LIỆU THỐNG KÊ</h5>

                <Row className="text-center align-items-center mb-3">
                    <Col className="d-flex align-items-center">
                        <Image src={logoHome} height={40} className="me-2" />
                        <div className="fw-bold">{nameHome}</div>
                    </Col>
                    <Col className="d-flex align-items-center justify-content-end">
                        <div className="fw-bold me-2">{nameAway}</div>
                        <Image src={logoAway} height={40} />
                    </Col>
                </Row>
                <Table bordered hover >
                    <tbody>
                        <tr>
                            <td>{statisticTeamHome.processing ? statisticTeamHome.processing : "50%"}</td>
                            <td className="text-center">Kiểm soát bóng</td>
                            <td>{statisticTeamAway.processing ? statisticTeamAway.processing : "50%"}</td>
                        </tr>

                    </tbody>
                </Table>
            </Container>
        </div>
    );
}

export default Statistic