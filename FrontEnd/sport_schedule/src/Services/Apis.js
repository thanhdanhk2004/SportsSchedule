import axios from "axios"
import {Cookies } from "react-cookie"

const REACT_APP_API_URL = "http://localhost:5023"
const cookies = new Cookies()

export const endpoints={
    'register': '/user/register',
    'login' : '/user/login',
    'league':'/league',
    'fixtures':'/fixture',
    'statistic': (matchId) => `/statistic/${matchId}`,
    'fixturesLeague': ({leagueId, page}) => `/fixture/${leagueId}/${page}`,
    'player':(playerId) => `/player/${playerId}`,
    'ranking':'/ranking',
    'postArticle':'/article/post'
}

export const authApis = () =>{
    return axios.create({
        baseURL:REACT_APP_API_URL,
        headers:{
            'Authorization': `Bearer ${cookies.get('token')}`,
            'Content-Type': 'application/json'
        }
    })
}

const api = axios.create({
    baseURL:REACT_APP_API_URL
})

export default api