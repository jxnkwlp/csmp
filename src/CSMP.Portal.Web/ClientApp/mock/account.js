export default {
    'GET /api/account': (req, res) => {
        res.send({
            count: 12,
            list: [
                {
                    id: 1,
                    userName: '1',
                    displayName: '1',
                },
                {
                    id: 2,
                    userName: '2',
                    displayName: '2',
                },
                {
                    id: 3,
                    userName: '3',
                    displayName: '3',
                },
                {
                    id: 4,
                    userName: '4',
                    displayName: '4',
                },
            ],
        });
    },

    'POST /api/account/create': (req, res) => {
        res.send();
    },

    'POST /api/account/update': (req, res) => {
        res.send();
    },

    'POST /api/account/delete': (req, res) => {
        res.send();
    },
};
