import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';

function App() {
    return (
        <div className="App">
            <AppRoutes /> {/* Así debe usarse */}
        </div>
    );
}

export default App;
