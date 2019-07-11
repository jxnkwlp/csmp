import { get, post } from '@/api/data';

export async function fetchlist(payload) {
    return get('/api/account', payload);
}

export async function create(payload) {
    return post('/api/account/create', payload);
}

export async function update(payload) {
    return post('/api/account/update', payload);
}

export async function remove(payload) {
    return post('/api/account/delete', payload);
}
