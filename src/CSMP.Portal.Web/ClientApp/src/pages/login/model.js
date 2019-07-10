import { getAccessToken, setAccessToken } from '@/utils';
import * as api from '@/api/data';

export default {
    namespace: 'login',
    state: {},
    subscriptions: {
        setup({ history, dispatch }) {},
    },
    effects: {
        *login({ payload: forms }, { put, call }) {
            console.log(forms);

            // TODO
            // yield api
            //     .post('api/auth/login', forms)
            //     .then(result => {
            //         if (result.data) {
            //             put({
            //                 type: 'app/handleSaveToken',
            //                 payload: { token: '212121' },
            //             });
            //         } else {
            //         }
            //     })
            //     .catch(err => {});

            yield put({
                type: 'app/handleSaveToken',
                payload: { token: '123465789' },
            });
        },
    },
    reducers: {},
};
