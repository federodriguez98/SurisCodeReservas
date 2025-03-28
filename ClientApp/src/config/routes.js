import { lazy } from 'react';
import { Config_Views } from './config_Views';
import { Navigate } from 'react-router-dom';


const routes = [
    {
        path: '/',
        component: () => <Navigate to={Config_Views.Listado} replace />,
        exact: true
    },
    {
        path: Config_Views.Listado,
        component: lazy(() => import('../pages/Reservas/Lista')),
        exact: true,
    },
    {
        path: Config_Views.Crear,
        component: lazy(() => import('../pages/Reservas/Create')),
    }
];

export default routes;