using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;
namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Recibir obj guardar db
            if(!ModelState.IsValid)
                return View(); 
            
            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
            
        }

        public IActionResult Editar(int IdContacto)
        {
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
          
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {

            var respuesta = _ContactoDatos.Editar(oContacto);
            if (!respuesta)
            {
                ModelState.AddModelError("", "Error al guardar los cambios");
                return View(oContacto);
            }

            return RedirectToAction("Listar");
        }

        public IActionResult Eliminar(int IdContacto)
        {
            var ocontacto = _ContactoDatos.Obtener(IdContacto);

            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            
            var respuesta = _ContactoDatos.Eliminar(oContacto);
            if (respuesta)
            {

                return RedirectToAction("Listar");
            }

            else
                return View();
            
        }

       

    }
}
