namespace PruebaDesempeño.Models;

public class EspacioDeportivo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string TipoEspacio { get; set; } = string.Empty;
    public int capacidad { get; set; }
    
}