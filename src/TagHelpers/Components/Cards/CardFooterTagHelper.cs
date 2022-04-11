using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Cards;

/// <summary>
/// To add an optional footer within a card, see <see cref="CardTagHelper"/>.
/// </summary>
[HtmlTargetElement(tag: CardFooterTag, ParentTag = null)]
[OutputElementHint(outputElement: "div")]
public class CardFooterTagHelper : BootstrapTagHelperBase
{
    private const string CardFooterTag = "card-footer";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.AddCssClasses(ClassNames.Cards.CardFooter);
    }
}
