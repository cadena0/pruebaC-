using PruebaDesempeño.Data;
using PruebaDesempeño.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDesempeño.Responses;


namespace PruebaDesempeño.Services;

public class UsuariosServices
{
    private readonly MysqlDbContext _context; 
    
    public UsuariosServices(MysqlDbContext context)
    {
        _context = context;
    }

    public ServicesResponse<IEnumerable<Usuario>> GetAllUSers()
    {
        var usuarios = _context.Usuario.ToList();
        return new ServicesResponse<IEnumerable<Usuario>>
        {
            Success = true,
            Data = usuarios
        };
    }

    public ServicesResponse<Usuario> Create(Usuario usuario)
    {
        bool exist = _context.Usuario.Any(U => U.DocumentoIdentidad == usuario.DocumentoIdentidad ||  U.Correo == usuario.Correo);
        if (!exist)
        {
            _context.Add(usuario);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new ServicesResponse<Usuario>()
                {
                    Success = true,
                    Data = usuario,
                    Message = "Usuario creado correctamente"
                };
            }
        }

        return new ServicesResponse<Usuario>()
        {
            Success = false,
            Data = null,
            Message = "Documento o Correo ya esta registrado "
        };
    }

    public ServicesResponse<Usuario> EditUsuario(int id)
    {
        var exists = _context.Usuario.FirstOrDefault(u => u.Id == id);
        if (exists != null)
        {
            return new ServicesResponse<Usuario>()
            {
                Success = true,
                Data = exists
            };
        }

        return new ServicesResponse<Usuario>()
        {
            Success = false,
            Message = "usuario no encontrado"
        };
    }

    public ServicesResponse<Usuario> UpdateUsuario(Usuario usuario)
    {
        var exist = _context.Usuario.FirstOrDefault(u => u.Id == usuario.Id);
        if (exist != null)
        {
            try
            {
                exist.DocumentoIdentidad = usuario.DocumentoIdentidad;
                exist.Nombre = usuario.Nombre;
                exist.Correo = usuario.Correo;
                _context.SaveChanges();

                return new ServicesResponse<Usuario>()
                {
                    Success = true,
                    Message = "Usuario editado correctamente"
                };
            }
            catch (Exception e)
            {
                return new ServicesResponse<Usuario>()
                {
                    Success = false,
                    Message = $"Usuario no fue modificado {e}"
                };
            }
        }

        return new ServicesResponse<Usuario>()
        {
            Success = false,
            Message = "usuario no encontrado"
        };
    }

    public ServicesResponse<Usuario> DeleteUsuario(int id)
    {
        var FindUser = _context.Usuario.FirstOrDefault(u => u.Id == id);
        if (FindUser != null)
        {
            _context.Usuario.Remove(FindUser);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new ServicesResponse<Usuario>()
                {
                    Success = true,
                    Message = "Usuario eliminado correctamente"
                };
            }

            return new ServicesResponse<Usuario>()
            {
                Success = false,
                Message = "no fue posible eliminar al usuario"
            };
        }

        return new ServicesResponse<Usuario>()
        {
            Success = false,
            Message = "usuario no encontrado"
        };
    }
}