import { getAccessToken, setAccessToken, saveStore, getStore } from '@/utils';
import router from 'umi/router';

export default {
    namespace: 'app',
    state: {
        notices: [],
        collapsed: false,
        login: getStore('login') || {
            userName: '',
            displayName: '',
        },
        apiToken: getAccessToken(),
    },
    subscriptions: {},
    effects: {
        *handleClearToken(_, { call, put }) {
            setAccessToken('');
            yield router.push('/login');
        },

        *handleSaveToken({ payload: value }, { call, put }) {
            // console.log(token);
            setAccessToken(value.token);
            yield router.push('/home');
        },

        *saveLoginedInfo({ payload: value }, { call, put }) {
            saveStore('login', value);
            yield put({ type: 'setLogin', payload: { user: value } });
        },
    },
    reducers: {
        changeCollapsed(
            state = {
                notices: [],
                collapsed: true,
            },
            { payload },
        ) {
            return { ...state, collapsed: payload };
        },

        setLogin(state, { payload }) {
            return { ...state, login: payload.user };
        },
    },
};
