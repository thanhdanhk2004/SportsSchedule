import axios from "axios"
//import {Cookies } from "react-cookie"

const REACT_APP_API_URL = "http://localhost:5023"

export const endpoints={
    'register': '/user/register',
    'login' : '/user/login',
    'league':'/league',
    'fixtures':'/fixture',
    'statistic': (matchId) => `/statistic/${matchId}`,
    'fixturesLeague': ({leagueId, page}) => `/fixture/${leagueId}/${page}`,
    'player':(playerId) => `/player/${playerId}`
}

// const auth_apis = () =>{
//     return axios.create({
//         baseUrl:REACT_APP_API_URL,
//         headers:{
//             'Authorization': `Bearer ${Cookies.load('token')}`,
//             'Content-Type': 'application/json'
//         }
//     })
// }

const api = axios.create({
    baseURL:REACT_APP_API_URL
})

export default api