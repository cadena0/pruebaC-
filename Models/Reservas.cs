namespace PruebaDesempeño.Models;

public class Reservas
{
    public int Id { get; set; }
    public string UsuariosId { get; set; }
    public string EspacioDeportivoId { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime horaInicio { get; set; }
    public DateTime horaFim { get; set; }
}