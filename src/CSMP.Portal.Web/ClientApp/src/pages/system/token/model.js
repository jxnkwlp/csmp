import { getAccessToken, setAccessToken } from '@/utils';
import { fetchlist, create, remove } from './service';
import { message } from 'antd';

export default {
    namespace: 'token',
    state: {
        modelVisible: false,
        modelTitle: 'a',

        tableTotal: 0,
        tableList: [],
    },
    subscriptions: {
        setup({ history, dispatch }) {},
    },
    effects: {
        *getList({ payload }, { call, put }) {
            var qs = {
                page: 1,
                pageSize: 10,
            };

            qs = Object.assign(qs, payload || {});

            try {
                var response = yield call(fetchlist, qs);

                yield put({
                    type: 'setTableList',
                    payload: { list: response.data.list, total: response.data.count },
                });
            } catch (error) {
                message.error('系统错误');
            }
        },

        *remove({ payload }, { call, put }) {
            try {
                var response = yield call(remove, { id: payload.id });
                message.success('操作成功');
                yield put({ type: 'getList' });
            } catch (error) {
                console.log(error);
                message.error('提交失败');
            }
        },

        *formSubmit({ payload }, { call, put }) {
            // console.log(payload);

            try {
                var response = yield call(create, payload);
                message.success('提交成功');
                yield put({ type: 'getList' });
            } catch (error) {
                console.log(error);
                message.error('提交失败');
            }

            yield put({
                type: 'updateModalShow',
                payload: { show: false },
            });

            // console.log('11');

            // create(payload)
            //     .then(result => {
            //         message.success('提交成功');
            //     })
            //     .catch(err => {
            //         console.log(err);
            //         message.error('提交失败');
            //     })
            //     .then(() => {
            //         console.log('11');
            //     });
        },
    },
    reducers: {
        updateModalShow(state, { payload }) {
            // console.log(payload);
            return { ...state, modelVisible: payload.show, modelTitle: payload.title };
        },

        setTableList(state, { payload }) {
            return { ...state, tableList: payload.list, tableTotal: payload.total };
        },
    },
};
