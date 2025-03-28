import { lazy } from 'react';
import { EnumViews } from './config_Views';

const routes = [
    {
        path: EnumViews.Listado,
        component: lazy(() => import('../pages/Reservas/Lista')),
        exact: true,
    },
    {
        path: EnumViews.Crear,
        component: lazy(() => import('../pages/Reservas/Create')),
    }
];

export default routes;