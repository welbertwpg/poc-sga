import axios from 'axios'

export default axios.create({
    baseURL: 'http://localhost/api',
    validateStatus: (status) => [200, 400].some((s) => s == status) 
})