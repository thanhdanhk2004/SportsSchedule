import { createContext, useEffect, useState } from "react";
import { Cookies } from "react-cookie";
import { jwtDecode } from "jwt-decode";

export const AuthContext = createContext()


export const AuthProvider = ({ children }) => {
  const cookies = new Cookies()
  const [isLogin, setIsLogin] = useState(false)
  const [role, setRole] = useState("")

  useEffect(() => {
    const token = cookies.get('token')
    if (token) {
      setIsLogin(true)
      const decoded = jwtDecode(token);
      const userRole = decoded.role || decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      setRole(userRole);
    }
  }, [])

  const login = (token) => {
    cookies.set('token', token, { path: "/" })
    setIsLogin(true)
    const decoded = jwtDecode(token);
    const userRole = decoded.role || decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    setRole(userRole);
  }

  const logout = () => {
    cookies.remove("token", { path: "/" })
    setIsLogin(false)
  }

  return (
    <AuthContext.Provider value={{ isLogin,role, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

