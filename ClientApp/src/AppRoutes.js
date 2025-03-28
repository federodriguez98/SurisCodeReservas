import { Suspense } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import routes from './config/routes';

const AppRoutes = () => (
    <BrowserRouter>
        <Suspense>
            <Routes>
                {routes.map((route, index) => (
                    <Route
                        key={index}
                        path={route.path}
                        element={<route.component />}
                    />
                ))}
            </Routes>
        </Suspense>
    </BrowserRouter>
);

export default AppRoutes;
