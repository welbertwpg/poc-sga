import axios from 'axios'

export default axios.create({
    baseURL: 'http://localhost:8080/api',
    validateStatus: (status) => [200, 400].some((s) => s == status) 
})