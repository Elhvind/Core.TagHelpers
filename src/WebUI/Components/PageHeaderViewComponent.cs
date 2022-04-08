using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class PageHeaderViewModel
{

}

public class PageHeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var viewModel = new PageHeaderViewModel();
        return View("PageHeader", viewModel);
    }
}
