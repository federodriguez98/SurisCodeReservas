import { useEffect, useState } from 'react';
import { getReservas } from '../../services/reservaService';
import Listado from '../../components/Listado'; 
import { useNavigate } from 'react-router-dom';
import { EnumViews } from '../../config/config_Views';


const Lista = () => {
    const [reservas, setReservas] = useState([]);
    const navigate = useNavigate();

    const irACrear = () => {
        navigate(EnumViews.Crear);
    };

    const obtenerReservas = async () => {
        const response = await getReservas();
        setReservas(response.data);
    };

    useEffect(() => {
        obtenerReservas();
    }, []);

    return (
        <div className="pt-5 px-5">
            <div className="d-flex justify-content-between align-items-center pb-4">
                <h2>Listado de Reservas</h2>
                <button
                    className="btn btn-primary"
                    onClick={irACrear}
                >
                    Nueva reserva
                </button>
            </div>
            <Listado reservas={reservas} onReservaEliminada={obtenerReservas} />
        </div>
    );
};

export default Lista; 
