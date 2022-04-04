using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Spinners;

[HtmlTargetElement("spinner", ParentTag = null)]
public class SpinnerTagHelper : BootstrapTagHelperBase
{
    /// <summary>
    /// Changes the spinners appearance.
    /// </summary>
    [HtmlAttributeName("type")]
    public SpinnerType Type { get; set; } = SpinnerType.Border;

    /// <summary>
    /// Changes the color of the spinner.
    /// </summary>
    [HtmlAttributeName("variant")]
    public ThemeColor? Variant { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("role", "status");
        output.Content.SetHtmlContent(@"<span class=""sr-only"">Loading...</span>");

        switch (Type)
        {
            case SpinnerType.Border:
                output.AddCssClasses(ClassNames.Spinners.SpinnerBorder);
                break;

            case SpinnerType.Grow:
                output.AddCssClasses(ClassNames.Spinners.SpinnerGrow);
                break;
        }

        if (Variant.HasValue)
            output.AddCssClasses(GetColorClassName("text", Variant.Value));
    }
}
