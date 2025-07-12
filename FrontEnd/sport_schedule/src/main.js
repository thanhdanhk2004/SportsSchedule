import Header from "./Component/Layout/Header"
import Footer from "./Component/Layout/Footer"
import { Container } from "react-bootstrap";

const Main = () => {
    return(
         <>
            <Header />
            <Container className="my-4">
                <h1>Nội dung trang chính</h1>
            </Container>
            <Footer />
        </>
    );
}

export default Main;