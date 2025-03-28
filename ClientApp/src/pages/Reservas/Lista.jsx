import { useEffect, useState } from 'react';
import { getReservas } from '../../services/reservaService';
import Listado from '../../components/Listado'; 
import { useNavigate } from 'react-router-dom';
import { EnumViews } from '../../config/enumViews';


const Lista = () => {
    const [reservas, setReservas] = useState([]);
    const navigate = useNavigate();

    const irACrear = () => {
        navigate(EnumViews.Crear);
    };
    useEffect(() => {
        const fetchData = async () => {
            const response = await getReservas();
            setReservas(response.data);
        };
        fetchData();
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
            <Listado reservas={ reservas } />
        </div>
    );
};

export default Lista; 
