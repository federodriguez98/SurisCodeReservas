import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import Swal from 'sweetalert2';
import { deleteReserva } from '../services/reservaService';
import PropTypes from 'prop-types';

const Listado = ({ reservas, onReservaEliminada }) => {

    Listado.propTypes = {
        reservas: PropTypes.arrayOf(
            PropTypes.shape({
                id: PropTypes.number.isRequired,
                cliente: PropTypes.string.isRequired,
                servicio: PropTypes.string.isRequired,
                fecha: PropTypes.oneOfType([
                    PropTypes.instanceOf(Date) 
                ]).isRequired,
                hora: PropTypes.string.isRequired,
            })
        ).isRequired,
        onReservaEliminada: PropTypes.func.isRequired,
    };

    const eliminarReserva = async (reserva) => {
        Swal.fire({
            icon: 'warning',
            title: '¿Deseas eliminar la reserva a nombre de ' + reserva.cliente + ' para el servicio ' + reserva.servicio + ' el día ' + new Date(reserva.fecha).toLocaleDateString() + ' a las ' + reserva.hora.slice(0, 5) + '?',
            showCancelButton: true,
            confirmButtonText: 'Confirmar',
            cancelButtonText: 'Cancelar', 
            confirmButtonColor: '#3085d6', 
            cancelButtonColor: '#d33',
        }).then((result) => {
            if (result.isConfirmed) {
                
                deleteReserva(reserva.id)
                    .then(() => {
                        Swal.fire(
                            '¡Eliminada!',
                            'La reserva ha sido eliminada.',
                            'success' 
                        );        
                        onReservaEliminada();
                    })
                    .catch((error) => {
                        Swal.fire(
                            'Error',
                            'No se pudo eliminar la reserva: ',
                            'error'
                        );
                    });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Cancelado',
                    'La reserva no ha sido eliminada.',
                    'info'
                );
            }
        });
    }

    return (
        <table className="table table-striped table-hover table-bordered">
            <thead className="table-dark">
                <tr>
                    <th>Cliente</th>
                    <th>Servicio</th>
                    <th>Fecha</th>
                    <th>Hora</th>
                    <th>Acción</th>
                </tr>
            </thead>
            <tbody>
                {reservas.length === 0 ? (
                    <tr>
                        <td colSpan="5" className="text-center">No existen datos</td>
                    </tr>
                ) : (reservas.map((reserva, indexReserva) => (
                    <tr key={reserva.id}>
                        <td>{reserva.cliente}</td>
                        <td>{reserva.servicio}</td>
                        <td>
                           <span >
                              {new Date(reserva.fecha).toLocaleDateString()}
                           </span>
                        </td>
                        <td>
                           <span >
                              {reserva.hora.slice(0,5)}
                           </span>
                        </td>
                        <td className="text-center">
                            <span onClick={() => eliminarReserva(reserva)} style={{ cursor: 'pointer', color: 'red' }}>
                                <FontAwesomeIcon icon={faTrashAlt} />
                            </span>
                        </td>
                    </tr>
                )))}
            </tbody>
        </table>
    );
}
export default Listado;
