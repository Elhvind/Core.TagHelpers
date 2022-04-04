using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Layout.GridSystem;

/// <summary>
/// Containers are the most basic layout element in Bootstrap and are required when using our default grid system.
/// Containers are used to contain, pad, and (sometimes) center the content within them.
/// While containers can be nested, most layouts do not require a nested container.
/// </summary>
[HtmlTargetElement(tag: "container", ParentTag = null)]
[OutputElementHint(outputElement: "div")]
public class ContainerTagHelper : BootstrapTagHelperBase
{
    /// <summary>
    /// Adds .container-fluid for width: 100% across all viewport and device sizes.
    /// </summary>
    [HtmlAttributeName("fluid")]
    public bool Fluid { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.AddCssClasses(Fluid ? ClassNames.Containers.Fluid : ClassNames.Containers.FixedWidth);
    }
}
