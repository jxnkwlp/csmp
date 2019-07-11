import { get, post } from '@/api/data';

export async function fetchlist(payload) {
    return get('/api/securityToken', payload);
}

export async function create(payload) {
    return post('/api/securityToken/create', payload);
}

export async function remove(payload) {
    return post('/api/securityToken/delete', payload);
}
