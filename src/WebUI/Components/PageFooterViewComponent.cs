using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class PageFooterViewModel
{

}

public class PageFooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var viewModel = new PageFooterViewModel();
        return View("PageFooter", viewModel);
    }
}
