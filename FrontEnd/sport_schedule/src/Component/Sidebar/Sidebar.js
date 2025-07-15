import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';

const Sidebar = () => {
    return (
        <div className="bg-light border p-3" style={{ width: "220px" }}>
            <div className="mb-4">
                <div className="bg-secondary text-white fw-bold text-uppercase px-3 py-2">
                    Giải nổi bật
                </div>
                <ul className="list-group list-group-flush">
                    <li className="list-group-item">
                        <a href="#">Premier League</a>
                    </li>
                    <li className="list-group-item">
                        <a href="#">Premier League</a>
                    </li>
                    <li className="list-group-item">
                        <a href="#">Premier League</a>
                    </li>
                    <li className="list-group-item">
                        <a href="#">Premier League</a>
                    </li>
                    
                </ul>
            </div>

            <div>
                <div className="bg-secondary text-white fw-bold text-uppercase px-3 py-2">
                    Khu vực
                </div>
                <ul className="list-group list-group-flush">
                    <li className="list-group-item">
                        <a href="#">Châu Âu</a>
                    </li>
                    <li className="list-group-item">
                        <a href="#">Châu Á</a>
                    </li>
                    <li className="list-group-item">
                        <a href="#">Châu Phi</a>
                    </li>

                </ul>
            </div>
        </div>
    );
}

export default Sidebar