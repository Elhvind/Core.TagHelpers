using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Buttons;

[HtmlTargetElement(tag: "btn")]
public class ButtonTagHelper : BootstrapTagHelperBase
{
    [HtmlAttributeName("size")]
    public ComponentSize Size { get; set; } = ComponentSize.Default;

    [HtmlAttributeName("variant")]
    public ThemeColor Variant { get; set; } = ThemeColor.Primary;

    [HtmlAttributeName("outline")]
    public bool Outline { get; set; }

    [HtmlAttributeName("href")]
    public string? Href { get; set; }

    [HtmlAttributeName("block")]
    public bool Block { get; set; }

    [HtmlAttributeName("link")]
    public bool Link { get; set; }

    [HtmlAttributeName("disabled")]
    public bool Disabled { get; set; }

    [HtmlAttributeName("active")]
    public bool Active { get; set; }

    [HtmlAttributeName("submit")]
    public bool Submit { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;

        if (string.IsNullOrEmpty(Href))
        {
            output.TagName = "button";
            output.Attributes.SetAttribute("type", Submit ? "submit" : "button");
        }
        else
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", Href);
            output.Attributes.SetAttribute("role", "button");
        }

        output.AddCssClasses(ClassNames.Buttons.Button);

        switch (Size)
        {
            case ComponentSize.Lg:
                output.AddCssClasses(ClassNames.Buttons.Large);
                break;

            case ComponentSize.Sm:
                output.AddCssClasses(ClassNames.Buttons.Small);
                break;
        }

        if (Block)
            output.AddCssClasses(ClassNames.Buttons.BlockLevel);

        if (Link)
        {
            output.AddCssClasses(ClassNames.Buttons.LinkButton);
        }
        else
        {
            output.AddCssClasses(GetColorClassName(Outline ? ClassNames.Buttons.OutlineButton : ClassNames.Buttons.Button, Variant));
        }

        if (Active || output.HasCssClasses(ClassNames.Active))
        {
            output.AddCssClasses(ClassNames.Active);
            output.Attributes.SetAttribute("aria-pressed", "true");
        }

        if (Disabled || output.HasCssClasses(ClassNames.Disabled))
        {
            if (output.TagName == "a")
            {
                output.AddCssClasses(ClassNames.Disabled);
            }
            else
            {
                output.Attributes.SetAttribute("disabled", null);
            }
            output.Attributes.SetAttribute("aria-disabled", "true");
        }
    }
}
