const Listado = ({ reservas }) => {
    return (
        <table className="table table-striped table-hover table-bordered">
            <thead className="table-dark">
                <tr>
                    <th>Cliente</th>
                    <th>Servicio</th>
                    <th>Fecha</th>
                    <th>Hora</th>
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
                    </tr>
                )))}
            </tbody>
        </table>
    );
}
export default Listado;
