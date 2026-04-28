namespace PruebaDesempeño.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }= string.Empty;

    public int DocumentoIdentidad { get; set; } 
    
    public string Correo { get; set; }= string.Empty;
    
}