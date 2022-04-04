using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Buttons;

/// <summary>
/// Groups a series of buttons together on a single line.
/// </summary>
[HtmlTargetElement("btn-group", ParentTag = null)]
[RestrictChildren(childTag: "btn", childTags: "btn-group")]
public class ButtonGroupTagHelper : BootstrapTagHelperBase
{
    /// <summary>
    /// Instead of applying button sizing classes to every button in a group,
    /// just add .btn-group-* to each .btn-group,
    /// including each one when nesting multiple groups.
    /// </summary>
    [HtmlAttributeName("size")]
    public ButtonSize Size { get; set; } = ButtonSize.Default;

    /// <summary>
    /// Make a set of buttons appear vertically stacked rather than horizontally.
    /// Split button dropdowns are not supported here.
    /// </summary>
    [HtmlAttributeName("vertical")]
    public bool Vertical { get; set; }

    /// <summary>
    /// Groups should be given an explicit label, as most assistive technologies will otherwise not announce them.
    /// </summary>
    [HtmlAttributeName("label")]
    public string? Label { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("role", "group");

        if (!string.IsNullOrEmpty(Label))
            output.Attributes.SetAttribute("aria-label", Label);

        output.AddCssClasses(Vertical ? ClassNames.ButtonGroups.VerticalButtonGroup : ClassNames.ButtonGroups.ButtonGroup);

        switch (Size)
        {
            case ButtonSize.Large:
                output.AddCssClasses(ClassNames.ButtonGroups.Large);
                break;

            case ButtonSize.Small:
                output.AddCssClasses(ClassNames.ButtonGroups.Small);
                break;
        }
    }
}
