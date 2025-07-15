import Header from "./Component/Layout/Header"
import Footer from "./Component/Layout/Footer"

const AuthLayout = ({children}) =>{
    return (
        <>
            <Header />
            <main>{children}</main>
            <Footer />
        </>
    )
}

export default AuthLayout