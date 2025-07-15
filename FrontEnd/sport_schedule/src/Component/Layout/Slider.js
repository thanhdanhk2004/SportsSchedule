import slider1 from "../../assets/slider1.jpg"
import slider2 from "../../assets/slider2.jpg"
import slider3 from "../../assets/slider3.jpg"
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.bundle.min.js'
import '../../Style/index.css'

const Slider = () => {
    return (
        <div id="carouselExampleIndicators" className="carousel slide d-flex justify-content-center my-4" data-bs-ride="carousel"
        style={{ maxWidth: '1100px', margin: '0 auto', height: '220px'}}
        >
            <ol className="carousel-indicators">
                <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to={0} className="active" />
                <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to={1} />
                <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to={2} />
            </ol>
            <div className="carousel-inner">
                <div className="carousel-item active">
                    <img className="d-block w-100 carousel-img" src={slider1} alt="First slide" />
                </div>
                <div className="carousel-item">
                    <img className="d-block w-100 carousel-img" src={slider2} alt="Second slide" />
                </div>
                <div className="carousel-item">
                    <img className="d-block w-100 carousel-img" src={slider3} alt="Third slide" />
                </div>
            </div>
            <a className="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-bs-slide="prev">
                <span className="sr-only">Previous</span>
                <span className="carousel-control-prev-icon" aria-hidden="true" />
                
            </a>
            <a className="carousel-control-next" href="#carouselExampleIndicators" role="button" data-bs-slide="next">
                <span className="carousel-control-next-icon" aria-hidden="true" />
                <span className="sr-only">Next</span>
            </a>
        </div>

    );
}

export default Slider