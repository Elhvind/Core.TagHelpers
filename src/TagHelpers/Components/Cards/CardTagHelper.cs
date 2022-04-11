using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Cards;

/// <summary>
/// A card is a flexible and extensible content container.
/// It includes options for headers and footers, a wide variety of content, contextual background colors, and powerful display options.
/// </summary>
[HtmlTargetElement(tag: CardTag, ParentTag = null)]
[RestrictChildren(childTag: "row", "img", "card-header", "card-body", "card-footer")]
[OutputElementHint(outputElement: "div")]
public class CardTagHelper : BootstrapTagHelperBase
{
    private const string CardTag = "card";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.AddCssClasses(ClassNames.Cards.Card);
    }
}
