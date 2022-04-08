using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class PageFooterViewModel
{
    public List<PageFooterLink> Col1Links { get; set; } = new();
    public List<PageFooterLink> Col2Links { get; set; } = new();
    public List<PageFooterLink> Col3Links { get; set; } = new();
}

public class PageFooterLink
{
    public string Text { get; set; } = "";
    public string Href { get; set; } = "#";
}

public class PageFooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var viewModel = new PageFooterViewModel();

        for (int i = 1; i < 3; i++)
        {
            viewModel.Col1Links.Add(new PageFooterLink()
            {
                Text = $"Link {i}"
            }); ;
        }

        for (int i = 1; i < 2; i++)
        {
            viewModel.Col2Links.Add(new PageFooterLink()
            {
                Text = $"Link {i}"
            }); ;
        }

        for (int i = 1; i < 4; i++)
        {
            viewModel.Col3Links.Add(new PageFooterLink()
            {
                Text = $"Link {i}"
            }); ;
        }

        return View("PageFooter", viewModel);
    }
}
