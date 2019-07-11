export default {
    'GET /api/securityToken': (req, res) => {
        res.send({
            count: 12,
            list: [
                {
                    id: 1,
                    token: 'aaaaaaaa',
                    expired: '2019/01/01',
                },
                {
                    id: 2,
                    token: 'bbbbbbbbb',
                    expired: '',
                },
                {
                    id: 3,
                    token: 'cccccccc',
                    expired: '',
                },
                {
                    id: 4,
                    token: 'dddddddddd',
                    expired: '',
                },
            ],
        });
    },

    'POST /api/securityToken/create': (req, res) => {
        res.send();
    },

    'POST /api/securityToken/delete': (req, res) => {
        res.send();
    },
};
