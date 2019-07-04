import Axios from 'axios';

// Axios.defaults.withCredentials = true;

class Http {
    constructor() {
        // Axios.defaults.headers[]
    }
    request(options) {
        var instalce = Axios.create(options);

        return instalce;
    }
}

let http = new Http();

export default http;
