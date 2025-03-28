import api from './api';

export const getReservas = () => api.get('/Reserva');
export const createReserva = (data) => api.post('/Reserva', data);
export const deleteReserva = (id) => api.delete(`/Reserva/${id}`);
