using Microsoft.AspNetCore.Mvc;

namespace eMovieTickets.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    { 
        public readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            //_shoppingCart.ShoppingCartItems = items;
            //var total = _shoppingCart.GetShoppingCartTotal();
            //ViewBag.Total = total;
            return View(items.Count);
        }

    }
}
