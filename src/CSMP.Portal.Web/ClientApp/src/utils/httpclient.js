import axios from 'axios';
import qs from 'qs';
import { getAccessToken } from './index';
import config from '@/config/';

const baseUrl = process.env.NODE_ENV === 'development' ? config.baseUrl.dev : config.baseUrl.prod;

// axios.defaults.headers["Content-Type"] = "application/x-www-form-urlencoded;charset=UTF-8";
axios.defaults.timeout = 30000; // 30s
axios.defaults.withCredentials = true;

class HttpRequest {
    config() {
        return {
            baseURL: baseUrl,
            headers: {
                //
                Authorization: 'Bearer ' + getAccessToken(),
            },
        };
    }
    interceptors(instance, url) {
        instance.interceptors.response.use(
            res => {
                const { data, status } = res;
                return {
                    data,
                    status,
                };
            },
            error => {
                return Promise.reject(error);
            },
        );
    }
    request(options) {
        const instance = axios.create();
        options = Object.assign(this.config(), options);
        this.interceptors(instance, options.url);
        return instance(options);
    }
}

const http = new HttpRequest();

export default http;
