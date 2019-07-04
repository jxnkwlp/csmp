import Cookies from 'js-cookies';

const tokenKey = '.token';

export const getAccessToken = () => {
    return Cookies.getItem(tokenKey) || '';
};
export const setAccessToken = token => {
    Cookies.setItem(tokenKey, token || '', { expires: 1 });
};
