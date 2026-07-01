using AutoMapper;
using Azure;
using inaApp.Common.Exceptions;
using inaApp.Common.Interfaces;
using inaApp.DTOs.Producto;
using InaApp.ProyectoINAApp.Models.Producto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InaApp.ProyectoINAApp.Controllers
{
    public class ProductoController : Controller
    {
        // Servicio genérico para manejar productos
        private readonly IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO> _productoService;

        // AutoMapper se inyecta como IMapper
        private readonly IMapper _mapper;

        // Constructor
        public ProductoController(
            IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO> service,
            IMapper mapper)
        {
            _productoService = service;
            _mapper = mapper;
        }

        // GET: ProductoController
        // Lista todos los productos
        public async Task<ActionResult> Index()
        {
            try
            {
                // Obtenemos todos los productos desde el servicio
                var lista = await _productoService.obtenerTodosAsync();

                // Mapeamos los DTO a ViewModel para enviarlos a la vista
                var listaViewModel = _mapper.Map<List<ProductoIndexViewModel>>(lista.Data);

                // Enviamos la lista mapeada a la vista
                return View(listaViewModel);
            }
            catch (NotFoundException)
            {
                ViewBag.Message = "No hay productos disponibles";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al cargar la página";
                return View();
            }
        }

        // GET: ProductoController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                //Obtener el producto
                var response=await _productoService.ObtenerPorIdAsync(id);

                if (!response.Success)
                {
                    TempData["Error"] = response.Message;
                    return RedirectToAction(nameof(Index));
                }

                //Creamos el view model de producto
                var productoVM= _mapper.Map<ProductoIndexViewModel>(response.Data);

                productoVM.Id = id;

                return View(productoVM);

            }
            catch (NotFoundException)
            {
                ViewBag.Message = $"No existe el producto con el id: {id}";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = "Error al cargar la página";
                return View();
            }
        }

        // GET: ProductoController/Create
        // Método para mostrar la vista de crear producto
        [HttpGet]
        public ActionResult Create()
        { 
            var model = new ProductoCreateViewModel
            {
                CategoriaId = 1
            };

            return View(model);

        }

        // POST: ProductoController/Create
        // Método para guardar el producto
        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoCreateViewModel productoViewModel)
        {
            try
            {
                // Categoría por defecto
                productoViewModel.CategoriaId = 1;

                if (!ModelState.IsValid)
                {
                    return View(productoViewModel);
                }

                // Convertimos ViewModel a DTO
                var productoDTO = _mapper.Map<ProductoCreateDTO>(productoViewModel);

                // Guardamos el producto
                var response = await _productoService.CrearAsync(productoDTO);

                if (!response.Success)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(productoViewModel);
                }

                TempData["Mensaje"] = "Producto creado correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al crear el producto: " + ex.Message;
                return View(productoViewModel);
            }
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _productoService.ObtenerPorIdAsync(id);

            if (!response.Success)
            {
                TempData["Error"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            var productoVM = _mapper.Map<ProductoEditViewModel>(response.Data);

            productoVM.Id = id;

            return View(productoVM);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductoEditViewModel productoViewModel)
        {
            try
            {
                // Categoría por defecto
                productoViewModel.CategoriaId = 1;

                if (!ModelState.IsValid)
                {
                    return View(productoViewModel);
                }

                // Convertimos ViewModel a DTO
                var productoDTO = _mapper.Map<ProductoUpdateDTO>(productoViewModel);

                // Guardamos el producto
                var response = await _productoService.ActualizarAsync(productoViewModel.Id, productoDTO);

                if (!response.Success)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(productoViewModel);
                }

                TempData["Mensaje"] = "Producto creado correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al crear el producto: " + ex.Message;
                return View(productoViewModel);
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = await _productoService.ObtenerPorIdAsync(id);

            if (!response.Success)
            {
                TempData["Error"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            var productoVM = _mapper.Map<ProductoIndexViewModel>(response.Data);

            productoVM.Id = id;

            return View(productoVM);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response =await _productoService.EliminarAsync(id);

                if (!response.Success)
                {
                    TempData["Error"] = response.Message;
                    return RedirectToAction(nameof(Index));
                }

                TempData["Mensaje"] = "Producto Eliminado";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}