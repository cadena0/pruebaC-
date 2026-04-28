using PruebaDesempeño.Data;
using PruebaDesempeño.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDesempeño.Responses;

namespace PruebaDesempeño.Services;

public class EspacioDeportivoServices : Controller
{
    private readonly MysqlDbContext _context;
    
    public EspacioDeportivoServices(MysqlDbContext context)
    {
        _context = context;
    }

    public ServicesResponse<IEnumerable<EspacioDeportivo>> GetAllEspacios()
    {
        var espacio = _context.EspacioDeportivo.ToList();
        return new ServicesResponse<IEnumerable<EspacioDeportivo>>()
        {
            Success = true,
            Data = espacio
        };
    }

    public ServicesResponse<EspacioDeportivo> Create(EspacioDeportivo espacio)
    {
        bool exist = _context.EspacioDeportivo.Any(E => E.Nombre == espacio.Nombre);
        if (!exist)
        {
            _context.Add(espacio);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new ServicesResponse<EspacioDeportivo>()
                {
                    Success = true,
                    Data = espacio,
                    Message = "espacio creado correctamente"
                };
            }
        }

        return new ServicesResponse<EspacioDeportivo>()
        {
            Success = false,
            Message = "espacio ya existe"
        };
    }

    public ServicesResponse<EspacioDeportivo> EditEspacio(int id)
    {
        var existe = _context.EspacioDeportivo.FirstOrDefault(E => E.Id == id);
        if (existe != null)
        {
            return new ServicesResponse<EspacioDeportivo>()
            {
                Success = true,
                Data = existe
            };
        }

        return new ServicesResponse<EspacioDeportivo>()
        {
            Success = false,
            Message = "espacio no encontrado"
        }; 
    }

    public ServicesResponse<EspacioDeportivo> UpdateEspacio(EspacioDeportivo espacio)
    {
        var exist = _context.EspacioDeportivo.FirstOrDefault(E => E.Id == espacio.Id);
        if (exist != null)
        {
            try
            {
                exist.Nombre = espacio.Nombre;
                exist.capacidad = espacio.capacidad;
                exist.TipoEspacio = espacio.TipoEspacio;
                _context.SaveChanges();

                return new ServicesResponse<EspacioDeportivo>()
                {
                    Success = true,
                    Message = "espacio editado correctamente"
                };
            }
            catch (Exception e)
            {
                return new ServicesResponse<EspacioDeportivo>()
                {
                    Success = false,
                    Message = $"el espacio no fue modificado {e}"
                };
            }
        }

        return new ServicesResponse<EspacioDeportivo>()
        {
            Success = false,
            Message = "espacio no encontrado"
        };
    }

    public ServicesResponse<EspacioDeportivo> DeleteEspacio(int id)
    {
        var EncontrarEspacio = _context.EspacioDeportivo.FirstOrDefault(E => E.Id == id );
        if (EncontrarEspacio != null)
        {
            _context.EspacioDeportivo.Remove(EncontrarEspacio);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new ServicesResponse<EspacioDeportivo>()
                {
                    Success = true,
                    Message = "espacio eliminado correctamente"
                };
            }

            return new ServicesResponse<EspacioDeportivo>()
            {
                Success = false,
                Message = "No fue posible eliminar espacio "
            };
        }

        return new ServicesResponse<EspacioDeportivo>()
        {
            Success = false,
            Message = "Espacio no encontrado "
        };
    }
    
}