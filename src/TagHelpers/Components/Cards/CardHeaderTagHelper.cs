using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Cards;

/// <summary>
/// To add an optional header within a card, see <see cref="CardTagHelper"/>.
/// </summary>
[HtmlTargetElement(tag: CardHeaderTag, ParentTag = null)]
public class CardHeaderTagHelper : BootstrapTagHelperBase
{
    private const string CardHeaderTag = "card-header";
    private const string CardHeaderTagNameDefault = "div";

    /// <summary>
    /// Changes the HTML element used for the header. Defaults to <c>div</c>.
    /// </summary>
    [HtmlAttributeName("tag")]
    public string Tag { get; set; } = CardHeaderTagNameDefault;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = string.IsNullOrWhiteSpace(Tag) ? CardHeaderTagNameDefault : Tag;
        output.TagMode = TagMode.StartTagAndEndTag;

        output.AddCssClasses(ClassNames.Cards.CardHeader);
    }
}
