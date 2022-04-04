using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Badges;

/// <summary>
/// Badges scale to match the size of the immediate parent element by using relative font sizing and em units.
/// </summary>
[HtmlTargetElement("badge", TagStructure = TagStructure.NormalOrSelfClosing)]
public class BadgeTagHelper : BootstrapTagHelperBase
{
    /// <summary>
    /// Changes the appearance of the badge.
    /// </summary>
    [HtmlAttributeName("variant")]
    public ThemeColor Variant { get; set; } = ThemeColor.Primary;

    /// <summary>
    /// Makes badges more rounded (with a larger border-radius and additional horizontal padding).
    /// </summary>
    [HtmlAttributeName("pill")]
    public bool Pill { get; set; }

    /// <summary>
    /// Provides an actionable badges with hover and focus states.
    /// </summary>
    [HtmlAttributeName("href")]
    public string? Href { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (string.IsNullOrEmpty(Href))
        {
            output.TagName = "span";
        }
        else
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", Href);
        }

        output.AddCssClasses(ClassNames.Badges.Badge, GetColorClassName(ClassNames.Badges.Badge, Variant));

        if (Pill)
            output.AddCssClasses(ClassNames.Badges.Pill);
    }
}
