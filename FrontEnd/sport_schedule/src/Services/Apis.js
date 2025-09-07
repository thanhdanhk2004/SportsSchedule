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
    'postArticle':'/article/post',
    'historyArticle':'/article/history',
    'updateArticle':(articleId) => `/article/update/${articleId}`,
    'deleteArticle':(articleId) => `/article/delete/${articleId}`,
    'getPageArticles': (page) => `/article/articles/${page}`,
    'getArticle':(articleId) => `/article/${articleId}`,
    'addComment': '/comment',
    'getComments':(postId) => `/Comment/comment/${postId}`,
    'getCommentsReply':(commentId) =>`/Comment/comment/reply/${commentId}`,
    'getMatchesGuess':(time) => `/guess/fixtures/${time}`,
    'addGuess':(matchId)  => `/guess/add/${matchId}`,
    'addAppointment':(matchId) => `/appointment/${matchId}`,
    'getMatchesAppointmented':'/appointmented',
    'getUsers':'/users',
    'deleteUser': (userId) => `/user/delete/${userId}`,
    'updateUser': '/user/update',
    'getArticlesByPageAdmin': (page) => `/admin/articles/${page}`,
    'approveArticle': (article_id) => `/admin/update/status/${article_id}`,
    'getPermissions': '/admin/permissions',
    'addPermission':'/admin/permission/add',
    'deletePermission':(permissionId) => `/admin/permission/delete/${permissionId}`,
    "updatePermission": '/admin/permission/update',
    'getRoles': '/admin/roles',
    'getFixturesPredict':(page) => `/admin/fixtures/predict/${page}`,
    'updateStatusPredictFixture':(matchId) => `admin/update/predict/${matchId}`,
    'getMatchesGuessAdmin':(page) => `/admin/guess/fixtures/${page}`,
    'getGuessExactly': (matchId) => `/admin/guess/exactly/${matchId}`,
    'getListAward': '/admin/list/award',
    'addAward': '/admin/award/add',
    'updateAward':(guessId) => `/admin/award/update/${guessId}`,
    'addRole' : '/admin/role/add',
    'deleteRole':(roleId) => `/admin/role/delete/${roleId}`,
    'updateRole':(roleId) => `/admin/role/update/${roleId}`,
    'getLeaguesAdmin': '/admin/leagues',
    'deleteLeague':(leagueId) => `/admin/leagues/delete/${leagueId}`,
    'getFixtureByLeagueAdmin':(leagueId) => `/admin/get/fixtures/${leagueId}`,
    'updateTimeFixture':(matchId) => `/admin/update/time/${matchId}`,
    'addSeason':'/admin/season/add',
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