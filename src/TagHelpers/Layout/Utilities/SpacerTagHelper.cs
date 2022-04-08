using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Layout.Utilities;

[HtmlTargetElement(tag: "*", Attributes = SpacerAttributeName)]
[HtmlTargetElement(tag: "*", Attributes = SpacerVerticalAttributeName)]
[HtmlTargetElement(tag: "*", Attributes = SpacerHorizontalAttributeName)]
[HtmlTargetElement(tag: "*", Attributes = SpacerTopAttributeName)]
[HtmlTargetElement(tag: "*", Attributes = SpacerBottomAttributeName)]
[HtmlTargetElement(tag: "*", Attributes = SpacerLeftAttributeName)]
[HtmlTargetElement(tag: "*", Attributes = SpacerRightAttributeName)]
public class SpacerTagHelper : BootstrapTagHelperBase
{
    private const string SpacerAttributeName = "spacer";
    private const string SpacerVerticalAttributeName = "spacer-y";
    private const string SpacerHorizontalAttributeName = "spacer-x";
    private const string SpacerTopAttributeName = "spacer-t";
    private const string SpacerBottomAttributeName = "spacer-b";
    private const string SpacerLeftAttributeName = "spacer-l";
    private const string SpacerRightAttributeName = "spacer-r";

    [HtmlAttributeName(SpacerAttributeName)]
    public Spacer? Spacer { get; set; }

    [HtmlAttributeName(SpacerVerticalAttributeName)]
    public Spacer? SpacerVertical { get; set; }

    [HtmlAttributeName(SpacerHorizontalAttributeName)]
    public Spacer? SpacerHorizontal { get; set; }

    [HtmlAttributeName(SpacerTopAttributeName)]
    public Spacer? SpacerTop { get; set; }

    [HtmlAttributeName(SpacerBottomAttributeName)]
    public Spacer? SpacerBottom { get; set; }

    [HtmlAttributeName(SpacerLeftAttributeName)]
    public Spacer? SpacerLeft { get; set; }

    [HtmlAttributeName(SpacerRightAttributeName)]
    public Spacer? SpacerRight { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        void AddSpacerClass(string prefix, Spacer? spacer)
        {
            if (spacer.HasValue)
                output.AddCssClasses($"{prefix}{(int)spacer.Value}");
        }

        AddSpacerClass("m-", Spacer);
        AddSpacerClass("my-", SpacerVertical);
        AddSpacerClass("mx-", SpacerHorizontal);
        AddSpacerClass("mt-", SpacerTop);
        AddSpacerClass("mb-", SpacerBottom);
        AddSpacerClass("ml-", SpacerLeft);
        AddSpacerClass("mr-", SpacerRight);
    }
}
