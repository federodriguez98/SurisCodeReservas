import api from './api';

export const getHorarios = (idServicio, fecha) => api.get('/Horario', { params: { idServicio, fecha } });