using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Components.Cards;

/// <summary>
/// Use it whenever you need a padded section within a card, see <see cref="CardTagHelper"/>.
/// </summary>
[HtmlTargetElement(tag: CardBodyTag, ParentTag = null)]
[OutputElementHint(outputElement: "div")]
public class CardBodyTagHelper : BootstrapTagHelperBase
{
    private const string CardBodyTag = "card-body";

    /// <summary>
    /// Turn an image into a card background and overlay your card's text.
    /// </summary>
    [HtmlAttributeName("img-overlay")]
    public bool ImageOverlay { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.AddCssClasses(ImageOverlay ? ClassNames.Cards.CardImageOverlay : ClassNames.Cards.CardBody);
    }
}
