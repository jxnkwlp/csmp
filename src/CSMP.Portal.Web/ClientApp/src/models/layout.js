export default {
    namespace: 'layout',
    state: {
        notices: [],
        collapsed: false,
        login: {
            userName: 'youname',
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
