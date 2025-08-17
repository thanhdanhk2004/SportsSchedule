import { useContext } from "react"
import { AuthContext } from "./Context/AuthContext"
import NotFound from "./Component/NotFound"
import Header from "./Component/Layout/Header"
import Footer from "./Component/Layout/Footer"
import Slider from "./Component/Layout/Slider"

const Protected = ({ children }) => {
    const { isLogin } = useContext(AuthContext)
    if (!isLogin)
        return (
            <>
                <Header />
                <Slider />
                <main>
                    <NotFound />
                </main>
                <Footer />
            </>
        )
    return (
        <>
            <Header />
            <Slider />
            <main>{children}</main>
            <Footer />
        </>
    )
}

export default Protected