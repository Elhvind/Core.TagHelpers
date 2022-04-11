using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Cards;

/// <summary>
/// A card is a flexible and extensible content container.
/// It includes options for headers and footers, a wide variety of content, contextual background colors, and powerful display options.
/// </summary>
[HtmlTargetElement(tag: CardColumnsTag, ParentTag = null)]
[RestrictChildren(childTag: "card")]
[OutputElementHint(outputElement: "div")]
public class CardColumnsTagHelper : BootstrapTagHelperBase
{
    private const string CardColumnsTag = "card-columns";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.AddCssClasses(ClassNames.Cards.CardColumns);
    }
}
