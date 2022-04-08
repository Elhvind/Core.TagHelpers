using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Content.Typography;

[HtmlTargetElement(tag: "paragraph", ParentTag = null)]
public class ParagraphTagHelper : BootstrapTagHelperBase
{
    /// <summary>
    /// Changes the color of the paragraph.
    /// </summary>
    [HtmlAttributeName("color")]
    public ThemeColor? Color { get; set; }

    [HtmlAttributeName("lead")]
    public bool Lead { get; set; }

    [HtmlAttributeName("small")]
    public bool Small { get; set; }

    [HtmlAttributeName("muted")]
    public bool Muted { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "p";
        output.TagMode = TagMode.StartTagAndEndTag;

        if (Lead)
            output.AddCssClasses("lead");
        else if (Small)
            output.AddCssClasses("small");

        if (Muted)
            output.AddCssClasses("text-muted");
        else if (Color.HasValue)
            output.AddCssClasses(GetColorClassName("text", Color.Value));
    }
}
