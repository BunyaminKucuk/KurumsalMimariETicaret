using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionHelper _cartSessionHelper;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }
        public IActionResult AddToCart(int productId)
        {
            //ürünü çek
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart", cart);

            TempData.Add("message", product.ProductName + " added basket");

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };
            return View(model);
        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionHelper.SetCart("cart", cart);
            TempData.Add("message", product.ProductName + " deleted basket");

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Complate()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };
            return View();
        }

        [HttpPost]
        public IActionResult Complate(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", "Your order completed successfully");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Cart");
        }
    }
}
