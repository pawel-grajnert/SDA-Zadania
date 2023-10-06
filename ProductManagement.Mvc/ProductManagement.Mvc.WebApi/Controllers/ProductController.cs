using Microsoft.AspNetCore.Mvc;
using ProductManagement.Mvc.Domain.Abstractions.Interfaces;
using ProductManagement.Mvc.WebApi.Mappers;
using ProductManagement.Mvc.WebApi.ModelView.Products;

namespace ProductManagement.Mvc.WebApi.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var productViewModelList = (await _productService.GetAllAsync()).Select(p => p.MapToViewModel()).ToList();
        return View(productViewModelList);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var productViewModel = (await _productService.GetAsync(id)).MapToViewModel();
        return View(productViewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new ProductViewModel() { Id = 0} );
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(productViewModel);
        }

        var product = productViewModel.MapToEntity();

        await _productService.Create(product);
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var productModelView = (await _productService.GetAsync(id)).MapToViewModel();
        return View(productModelView);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(productViewModel);
        }

        var product = productViewModel.MapToEntity();

        await _productService.Update(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var productModelView = (await _productService.GetAsync(id)).MapToViewModel();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ProductViewModel productViewModel)
    {
        await _productService.DeleteAsync(productViewModel.Id);
        return RedirectToAction(nameof(Index));
    }
}