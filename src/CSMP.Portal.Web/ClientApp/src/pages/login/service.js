import { get, post } from '@/api/data';

export async function getToken(payload) {
    // return post('/api/account/create', payload);
    return post('/api/auth/token', payload);
}
