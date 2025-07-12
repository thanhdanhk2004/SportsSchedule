import axios from "axios"
import cookie from "react-cookie"

const REACT_APP_API_URL = "http://localhost:5023/api"

export const endpoints={
    'register': '/users',
    'login': '/login',
}

export const auth_apis = () =>{
    return axios.create({
        baseUrl:REACT_APP_API_URL,
        headers:{
            'Authorization': `Bearer ${cookie.load('token')}`,
            'Content-Type': 'application/json'
        }
    })
}

export default axios.create({
    baseUrl:REACT_APP_API_URL
})