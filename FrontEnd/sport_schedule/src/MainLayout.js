import Header from "./Component/Layout/Header"
import Footer from "./Component/Layout/Footer"
import Slider from "./Component/Layout/Slider"
import League from "./Component/Sidebar/League" 


const MainLayout = ({children}) =>{
    return (
        <>
            <Header />
            <Slider />
            <League />
            <main>{children}</main>
            <Footer />
        </>
    )
}

export default MainLayout