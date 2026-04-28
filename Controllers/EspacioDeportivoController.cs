using Microsoft.AspNetCore.Mvc;
using PruebaDesempeño.Models;
using PruebaDesempeño.Services;
using PruebaDesempeño.Responses;
using System.Linq;

namespace PruebaDesempeño.Controllers;

public class EspacioDeportivoController : Controller
{
    private readonly EspacioDeportivoServices _Services;

    public EspacioDeportivoController(EspacioDeportivoServices services)
    {
        _Services = services;
    }
    public IActionResult Index()
    {
        var espacio = _Services.GetAllEspacios();
        return View(espacio.Data);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(EspacioDeportivo espacio)
    {
        var EspacioResponse = _Services.Create(espacio);
        if (EspacioResponse.Success)
        {
            TempData["message"] = EspacioResponse.Message;
            TempData["status"] = "success";
            return RedirectToAction("Index");
        }

        TempData["message"] = EspacioResponse.Message;
        TempData["status"] = "danger";
        return View(espacio);
        
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var espacio = _Services.EditEspacio(id);
        if (!espacio.Success)
        {
            TempData["message "] =  espacio.Message;
            TempData[""] = "danger";
            return RedirectToAction("Index");
        }
        return View(espacio.Data);
    }

    [HttpPost]
    public IActionResult Update(EspacioDeportivo espacio)
    {
        var espacios = _Services.UpdateEspacio(espacio);
        if (espacios.Success)
        {
            TempData["message"] = espacios.Message;
            TempData["status"] =  "success";
            return RedirectToAction("Index");
        }

        TempData["message"] = espacios.Message;
        TempData["status"] = "danger";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _Services.DeleteEspacio(id);
        return RedirectToAction("Index");
    }
    
}