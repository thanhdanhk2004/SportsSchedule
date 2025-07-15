import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';

const League = () => {
    return (
        <div className="bg-light border p-3" style={{ width: "220px" }}>
            <div className="mb-4">
                <div className="bg-secondary text-white fw-bold text-uppercase px-3 py-2">
                    Giải nổi bật
                </div>
                <ul className="list-group list-group-flush">
                    <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                     <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                     <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                     <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                    
                </ul>
            </div>

            <div>
                <div className="bg-secondary text-white fw-bold text-uppercase px-3 py-2">
                    Khu vực
                </div>
                <ul className="list-group list-group-flush">
                     <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                     <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>
                     <a href="/login"><li className="list-group-item">
                        Premier League
                    </li></a>

                </ul>
            </div>
        </div>
    );
}

export default League