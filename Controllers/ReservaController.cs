using Microsoft.AspNetCore.Mvc;
using PruebaDesempeño.Models;
using PruebaDesempeño.Services;
using PruebaDesempeño.Responses;
using System.Linq;


namespace PruebaDesempeño.Controllers;

public class ReservaController : Controller
{
    private readonly ReservasServices _services;

    public ReservaController(ReservasServices services)
    {
        _services = services;
    }
    public IActionResult Index()
    {
        var reserva = _services.GetAllReservas();
        return View(reserva.Data);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Reservas reserva)
    {
        var ReservaResponse = _services.Create(reserva);
        if (ReservaResponse.Success)
        {
            TempData["message"] = ReservaResponse.Message;
            TempData["status"] = "success";
            return RedirectToAction("Index");
        }

        TempData["message"] = ReservaResponse.Message;
        TempData["status"] = "danger";
        return View(reserva);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var reserva = _services.EditReserva(id);
        if (!reserva.Success)
        {
            TempData["message"] = reserva.Message;
            TempData[""] = "danger";
            return RedirectToAction("Index");
        }
        return View(reserva.Data);
    }

    [HttpPost]
    public IActionResult Update(Reservas reserva)
    {
        var reservas = _services.UpdateReservas(reserva);
        if (reservas.Success)
        {
            TempData["message"] = reservas.Message;
            TempData["status"] = "success";
            return RedirectToAction("Index");
        }
        TempData["message"] = reservas.Success;
        TempData["status"] = "danger";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _services.DeleteReserva(id);
        return RedirectToAction("Index");
    }
}