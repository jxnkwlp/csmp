import { getAccessToken, setAccessToken } from '@/utils';
import * as api from '@/api/data';
import { getToken } from './service';
import { message } from 'antd';

export default {
    namespace: 'login',
    state: {},
    subscriptions: {
        setup({ history, dispatch }) {},
    },
    effects: {
        *login({ payload: forms }, { put, call }) {
            console.log(forms);

            try {
                var response = yield call(getToken, forms);
                // console.log(response);
                var data = response.data;
                yield put({
                    type: 'app/handleSaveToken',
                    payload: { token: data.token },
                });
                yield put({
                    type: 'app/saveLoginedInfo',
                    payload: data,
                });
            } catch (error) {
                console.log(error);
                message.error('登录失败！用户名或密码错误');
            }
        },
    },
    reducers: {},
};
