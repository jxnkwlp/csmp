import { getAccessToken, setAccessToken } from '@/utils/util';

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
    effects: {},
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

        handleSaveToken(state, { token }) {
            setAccessToken(token);
        },

        handleClearToken(state) {
            setAccessToken('');
        },
    },
};
