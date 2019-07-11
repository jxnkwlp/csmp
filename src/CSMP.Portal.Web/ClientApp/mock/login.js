export default {
    'POST /api/auth/token': (req, res) => {
        return res.send({
            userName: 'username',
            displayName: 'you name',
            token: '123465',
        });
    },
};
