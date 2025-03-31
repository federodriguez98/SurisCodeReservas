import { useEffect, useState } from 'react';
import { getHorarios } from '../../services/horarioService';
import { getServicios } from '../../services/servicioService';
import { createReserva } from '../../services/reservaService';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import Swal from 'sweetalert2';
import { useNavigate } from 'react-router-dom';
import { Config_Views } from '../../config/config_Views';


const Create = () => {
    const [servicios, setServiciosState] = useState([]);
    const [horarios, setHorariosState] = useState([]);
    const [horarioSeleccionado, setHorarioSeleccionado] = useState('');
    const [servicioSeleccionado, setServicioSeleccionado] = useState('');
    const [nombre, setNombre] = useState('');
    const [fechaSeleccionada, setFechaSeleccionada] = useState(null);
    const navigate = useNavigate();


    useEffect(() => {
        const fetchData = async () => {
            const response = await getServicios();
            setServiciosState(response.data);
        };
        fetchData();
    }, []);

    useEffect(() => {
        const fetchHorarios = async () => {
            if (servicioSeleccionado && fechaSeleccionada) {
                const fechaNormalizada = fechaSeleccionada.toISOString().split('T')[0];
                const response = await getHorarios(servicioSeleccionado, fechaNormalizada);
                setHorariosState(response.data);
            }
        };

        fetchHorarios();
    }, [servicioSeleccionado, fechaSeleccionada]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        const reserva = {
            idServicio: servicioSeleccionado,
            idHorario: horarioSeleccionado,
            fecha: fechaSeleccionada,
            cliente: nombre,
        };

        try {
            await createReserva(reserva);
            Swal.fire({
                icon: 'success',
                title: 'Se reservo el turno correctamente',
            });
            navigate(Config_Views.Listado);

        } catch (error) {
            Swal.fire({
                icon: 'error',
                title: error.response.data,
            });
        }
    };

    return (
        <div>
            <button
                className="btn btn-primary mx-4"
                onClick={() => navigate(Config_Views.Listado)}
        >
            Volver al listado
        </button>
        <div className="d-flex justify-content-center align-items-center min-vh-100">
            <div className="card" style={{ width: '40rem' }}>
                <div className="card-body">
                    <h3 className="card-title text-center">Nueva reserva</h3>
                    <form onSubmit={handleSubmit}>
                        <div className="mb-3">
                            <label htmlFor="servicio" className="form-label">Seleccioná un servicio</label>
                            <select
                                className="form-select"
                                id="horario"
                                value={servicioSeleccionado}
                                onChange={(e) => setServicioSeleccionado(e.target.value)}
                                required
                            >
                                <option value="">-- Seleccionar --</option>
                                {servicios.map((servicio) => (
                                    <option key={servicio.id} value={servicio.id}>
                                        {servicio.descripcion}
                                    </option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="calendario" className="form-label me-4">Seleccionar fecha</label>
                            <DatePicker
                                id="calendario"
                                selected={fechaSeleccionada}
                                onChange={(date) => setFechaSeleccionada(date)}
                                className="form-control"
                                dateFormat="dd/MM/yyyy"
                                minDate={new Date()}
                                required
                                placeholderText="Seleccione una fecha"
                                isClearable
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="horario" className="form-label">Seleccioná un horario</label>
                            <select
                                className="form-select"
                                id="horario"
                                value={horarioSeleccionado}
                                onChange={(e) => setHorarioSeleccionado(e.target.value)}
                                required
                            >
                                <option value="">-- Seleccionar --</option>
                                {horarios.map((horario) => (
                                    <option key={horario.id} value={horario.id}>
                                        {horario.hora.slice(0, 5)}
                                    </option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="nombre" className="form-label">Nombre</label>
                            <input
                                type="text"
                                className="form-control"
                                id="nombre"
                                value={nombre}
                                onChange={(e) => setNombre(e.target.value)}
                                placeholder="Ingrese su nombre"
                                required
                            />
                        </div>
                        <div className="text-center">
                            <button
                                type="submit"
                                className="btn btn-primary"
                                disabled={!nombre || !horarioSeleccionado || !fechaSeleccionada || !servicioSeleccionado}
                            >
                                Reservar
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    );
};

export default Create; 
