import { createContext, useEffect, useState } from "react";
import { Cookies } from "react-cookie";

export const AuthContext = createContext()


export const AuthProvider = ({children}) =>{
    const cookies = new Cookies()
    const [isLogin, setIsLogin]  = useState(false)

    useEffect(() =>{
        const token = cookies.get('token')
        if(token)
            setIsLogin(true)
    }, [])

    const login = (token) => {
        cookies.set('token', token , {path: "/"})
        setIsLogin(true)
    }

    const logout = () =>{
        cookies.remove("token", {path: "/"})
        setIsLogin(false)
    }
    return (
    <AuthContext.Provider value={{ isLogin, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

