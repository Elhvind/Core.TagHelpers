using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Buttons;

/// <summary>
/// Combine sets of button groups into button toolbars for more complex components.
/// Use utility classes as needed to space out groups, buttons, and more.
/// </summary>
[HtmlTargetElement("btn-toolbar", ParentTag = null)]
public class ButtonToolbarTagHelper : BootstrapTagHelperBase
{
    /// <summary>
    /// Toolbars should be given an explicit label, as most assistive technologies will otherwise not announce them.
    /// </summary>
    [HtmlAttributeName("label")]
    public string? Label { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("role", "toolbar");

        if (!string.IsNullOrEmpty(Label))
            output.Attributes.SetAttribute("aria-label", Label);

        output.AddCssClasses(ClassNames.ButtonToolbars.ButtonToolbar);
    }
}
