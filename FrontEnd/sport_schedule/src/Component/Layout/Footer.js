import { FaFacebookF, FaTwitter, FaGoogle, FaInstagram, FaLinkedinIn, FaGithub, } from 'react-icons/fa';
import { Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const Footer = () => {
    return (
        <footer className="bg-dark text-center text-white pt-4">
            <Container className="pb-3">
                <section className="mb-4">
                    <button href="#" className="btn btn-outline-light btn-floating m-1 rounded-circle">
                        <FaFacebookF />
                    </button>
                    <button href="#" className="btn btn-outline-light btn-floating m-1 rounded-circle">
                        <FaTwitter />
                    </button>
                    <button href="#" className="btn btn-outline-light btn-floating m-1 rounded-circle">
                        <FaGoogle />
                    </button>
                    <button href="#" className="btn btn-outline-light btn-floating m-1 rounded-circle">
                        <FaInstagram />
                    </button>
                    <button href="#" className="btn btn-outline-light btn-floating m-1 rounded-circle">
                        <FaLinkedinIn />
                    </button>
                    <button href="#" className="btn btn-outline-light btn-floating m-1 rounded-circle">
                        <FaGithub />
                    </button>
                </section>
            </Container>

            {/* Copyright */}
            <div className="text-center p-3" style={{ backgroundColor: '#2c2c2c' }}>
                © 2020 Copyright: <a className="text-white" href="https://mdbootstrap.com/">Lê Thanh Dân</a>
            </div>
        </footer>
    );
}

export default Footer;