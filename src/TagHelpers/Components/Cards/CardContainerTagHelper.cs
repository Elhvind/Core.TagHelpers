using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Cards;

[HtmlTargetElement(tag: CardContainerTag, ParentTag = null)]
[RestrictChildren(childTag: "card")]
[OutputElementHint(outputElement: "div")]
public class CardContainerTagHelper : BootstrapTagHelperBase
{
    private const string CardContainerTag = "card-container";

    [HtmlAttributeName("type")]
    public CardContainerType Type { get; set; } = CardContainerType.Columns;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        switch (Type)
        {
            case CardContainerType.Group:
                new CardGroupTagHelper().Process(context, output);
                break;

            case CardContainerType.Deck:
                new CardDeckTagHelper().Process(context, output);
                break;

            case CardContainerType.Columns:
                new CardColumnsTagHelper().Process(context, output);
                break;
        }
    }
}
