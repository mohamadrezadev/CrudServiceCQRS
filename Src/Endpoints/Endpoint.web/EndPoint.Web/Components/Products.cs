using Microsoft.AspNetCore.Mvc;
[ViewComponent(Name = "Products")]
public class Products:ViewComponent{
    public Products()
    {
        
    }
      public IViewComponentResult Invoke()
        {
            
            return View();
        }
}