import axios from "axios"

console.log("API URL:", process.env.REACT_APP_API_URL)

const $host = axios.create({
    baseURL: process.env.REACT_APP_API_URL
})

export {
    $host
}