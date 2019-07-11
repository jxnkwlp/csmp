import { fetchlist, create, remove, update } from './service';
import { message } from 'antd';

export default {
    namespace: 'logs',
    state: {
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

        *formSubmit({ payload, callback }, { call, put }) {
            try {
                if (payload.id) yield call(update, payload);
                else yield call(create, payload);

                if (callback) callback(true);

                message.success('提交成功');
                yield put({ type: 'getList' });
            } catch (error) {
                console.log(error);
                if (callback) callback(false);
                message.error('提交失败');
            }
        },
    },
    reducers: {
        setTableList(state, { payload }) {
            return { ...state, tableList: payload.list, tableTotal: payload.total };
        },
    },
};
