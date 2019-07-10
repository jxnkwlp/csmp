import { getAccessToken, setAccessToken } from '@/utils';
import router from 'umi/router';

export default {
    namespace: 'app',
    state: {
        notices: [],
        collapsed: false,
        login: {
            userName: 'youname',
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
    },
};
