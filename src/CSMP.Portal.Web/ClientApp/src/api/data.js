import http from '@/utils/httpclient';

export const request = (url, config) => {
    config['url'] = url;
    return http.request(config);
};

export const get = (url, params) => {
    var _config = {
        url: url,
        params: params,
    };
    _config = Object.assign(_config, params);
    return http.request(_config);
};

export const post = (url, data) => {
    var _config = {
        method: 'post',
        url: url,
        data: data,
    };
    _config = Object.assign(_config, data);
    return http.request(_config);
};
