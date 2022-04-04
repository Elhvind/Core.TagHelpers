using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Content.Typography;

[HtmlTargetElement(tag: "heading", ParentTag = null)]
public class HeadingTagHelper : BootstrapTagHelperBase
{
    [HtmlAttributeName("level")]
    public HeadingLevel Level { get; set; } = HeadingLevel.H1;

    [HtmlAttributeName("imitate")]
    public bool Imitate { get; set; }

    [HtmlAttributeName("display-level")]
    public DisplayLevel? DisplayLevel { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;

        if (Imitate)
        {
            output.TagName = "p";
            output.AddCssClasses(Level.ToString().ToLower());
        }
        else
        {
            output.TagName = Level.ToString().ToLower();
        }

        output.AddCssClasses(GetDisplayClass());
    }

    private string GetDisplayClass()
    {
        if (!DisplayLevel.HasValue)
            return "";

        return DisplayLevel.Value switch
        {
            Content.DisplayLevel.D1 => "display-1",
            Content.DisplayLevel.D2 => "display-2",
            Content.DisplayLevel.D3 => "display-3",
            Content.DisplayLevel.D4 => "display-4",
            _ => ""
        };
    }
}
