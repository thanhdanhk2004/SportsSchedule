import "../Style/index.css"

const NotFound = () => {
    return (
        <div className="text-dark">
            <div className="d-flex align-items-center justify-content-center min-vh-100 px-2">
                <div className="text-center">
                    <h1 className="display-1 fw-bold">404</h1>
                    <p className="fs-2 fw-medium mt-4">Không tìm thấy trang</p>
                    <p className="mt-4 mb-5">
                        Vui lòng đăng nhập tài khoản
                    </p>
                    <a
                        href="/"
                        className="btn btn-light fw-semibold rounded-pill px-4 py-2 custom-btn"
                    >
                        Go Home
                    </a>
                </div>
            </div>
        </div>


    )
}

export default NotFound