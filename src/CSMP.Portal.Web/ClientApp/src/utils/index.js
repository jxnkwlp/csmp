import Cookies from 'js-cookies';

const tokenKey = '.token';

export const getAccessToken = () => {
    return Cookies.getItem(tokenKey) || '';
};

export const setAccessToken = token => {
    Cookies.setItem(tokenKey, token || '', { expires: 1 });
};

export const saveStore = (key, value) => {
    window.sessionStorage.setItem(key, JSON.stringify(value));
};

export const getStore = key => {
    return JSON.parse(window.sessionStorage.getItem(key) || '{}') || {};
};
