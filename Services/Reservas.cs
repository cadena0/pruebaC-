using PruebaDesempeño.Data;
using PruebaDesempeño.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDesempeño.Responses;

namespace PruebaDesempeño.Services;

public class ReservasServices : Controller
{
    private readonly MysqlDbContext _Context;
    public  ReservasServices(MysqlDbContext context)
    {
        _Context = context;
    }
    
    public ServicesResponse<IEnumerable<Reservas>> GetAllReservas()
    {
        var reserva = _Context.Reservas.ToList();
        return new ServicesResponse<IEnumerable<Reservas>>
        {
            Success = true,
            Data = reserva 
        };
    }

    public ServicesResponse<Reservas> Create(Reservas reservas)
    {
        bool exist = _Context.Reservas.Any(r =>
            r.EspacioDeportivoId == reservas.EspacioDeportivoId || r.UsuariosId == reservas.UsuariosId);
        if (!exist)
        {
            _Context.Add(reservas);
            var result = _Context.SaveChanges();
            if (result > 0)
            {
                return new ServicesResponse<Reservas>()
                {
                    Success = true,
                    Data = reservas,
                    Message = "reserva creada correctamente"
                };
            }
        }

        return new ServicesResponse<Reservas>()
        {
            Success = false,
            Message = "la Reserva ya existe"
        };
    }

    public ServicesResponse<Reservas> EditReserva(int id)
    {
        var existe = _Context.Reservas.FirstOrDefault(r => r.Id == id);
        if (existe != null)
        {
            return new ServicesResponse<Reservas>()
            {
                Success = true,
                Data = existe
            };
        }

        return new ServicesResponse<Reservas>()
        {
            Success = false,
            Message = "reserva no encontrada"
        };
    }

    public ServicesResponse<Reservas> UpdateReservas(Reservas reserva)
    {
        var exist = _Context.Reservas.FirstOrDefault(r => r.Id == reserva.Id);
        if (exist != null)
        {
            try
            {
                exist.Id = reserva.Id;
                exist.UsuariosId = reserva.UsuariosId;
                exist.EspacioDeportivoId = reserva.EspacioDeportivoId;
                exist.Fecha = reserva.Fecha;
                exist.horaFim = reserva.horaFim;
                exist.horaInicio = reserva.horaInicio;
                _Context.SaveChanges();

                return new ServicesResponse<Reservas>()
                {
                    Success = true,
                    Message = "reserva editada correctamente"
                };
            }
            catch (Exception e)
            {
                return new ServicesResponse<Reservas>()
                {
                    Success = false,
                    Message = $"la reserva no fue modificada {e}"
                };
            }
        }

        return new ServicesResponse<Reservas>()
        {
            Success = false,
            Message = "reserva no encontrada"
        };
    }

    public ServicesResponse<Reservas> DeleteReserva(int id)
    {
        var EncontrarReserva = _Context.Reservas.FirstOrDefault(r => r.Id == id);
        if (EncontrarReserva != null)
        {
            _Context.Reservas.Remove(EncontrarReserva);
            var result = _Context.SaveChanges();
            if (result > 0)
            {
                return new ServicesResponse<Reservas>()
                {
                    Success = true,
                    Message = "espacio eliminado correctamente"
                };
            }

            return new ServicesResponse<Reservas>()
            {
                Success = false,
                Message = "no fue posible eliminar la reserva"
            };
        }

        return new ServicesResponse<Reservas>()
        {
            Success = false,
            Message = "reserva no encontrada"
        };
    }
}