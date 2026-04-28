using Microsoft.AspNetCore.Mvc;
using PruebaDesempeño.Models;
using PruebaDesempeño.Services;
using PruebaDesempeño.Responses;
     
namespace PruebaDesempeño.Controllers;

public class UsuariosController : Controller
{
    private readonly UsuariosServices _service;
    
    public UsuariosController(UsuariosServices service)
    {
        _service = service;
    }

    public ActionResult index()
    {
        var usuarios = _service.GetAllUSers();
        return View(usuarios.Data);
    }
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Usuario usuario)
    {
        var usuarioResponse = _service.Create(usuario);
        if (usuarioResponse.Success)
        {
            
            TempData["message"] = usuarioResponse.Message;
            TempData["status"] = "success";
            return RedirectToAction("index");
        }
        TempData["Message"] = usuarioResponse.Message;
        TempData["status"] = "danger";
        return View(usuario);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var usuario = _service.EditUsuario(id);
        if (!usuario.Success)
        {
            TempData["message"] =  usuario.Message;
            TempData[""] =  "danger";
            return RedirectToAction("index");
        }
        return View(usuario.Data);
    }

    [HttpPost]
    public IActionResult Update(Usuario usuario)
    {
        var users = _service.UpdateUsuario(usuario);
        if (users.Success)
        {
            TempData["message"] = users.Message;
            TempData["status"] = "success";
            return RedirectToAction("index");
        }
        TempData ["message"] = users.Message;
        TempData ["status"] = "danger";
        return RedirectToAction("index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _service.DeleteUsuario(id);
        return RedirectToAction("index");
    }
}

