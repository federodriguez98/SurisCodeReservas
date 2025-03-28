import { lazy } from 'react';
import { EnumViews } from './enumViews';

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