import axios, { AxiosError, AxiosResponse } from 'axios';
import { history } from '../';
import { MoistureContent } from '../app/models/apiTypes';

// replicate the real waiting time
const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

axios.interceptors.response.use(async response => {
    await sleep(600);
    return response;
}, (error: AxiosError) => {
    const { status } = error.response!;
    switch (status) {
        case 400:
            history.push('/badRequest');
            break;
        case 401:
            history.push('/unauthorised');
            break;
        case 404:
            history.push('/notFound');
            break;
        case 500:
            history.push('/serverError');
            break;
    }
    return Promise.reject(error);
})


axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}

const MoistureContents = {
    list: () => requests.get<MoistureContent[]>('/moistureContent'),
    details: (id: string) => requests.get<MoistureContent>(`/moistureContent/${id}`),
    create: (moistureContent: MoistureContent) => axios.post<void>('/moistureContent', moistureContent),
    update: (moistureContent: MoistureContent) => axios.put<void>('/moistureContent', moistureContent),
    delete: (id: string) => axios.delete<MoistureContent>(`/moistureContent/${id}`)
}

const agent = {
    MoistureContents
}

export default agent;