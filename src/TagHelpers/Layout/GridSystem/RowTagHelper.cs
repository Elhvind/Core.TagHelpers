using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Layout.GridSystem;

/// <summary>
/// Rows are wrappers for columns.
/// Each column has horizontal padding (called a gutter) for controlling the space between them.
/// This padding is then counteracted on the rows with negative margins to ensure the content in your columns is visually aligned down the left side.
/// Rows also support modifier classes to uniformly apply column sizing and gutter classes to change the spacing of your content.
/// </summary>
[HtmlTargetElement(tag: "row", ParentTag = null)]
[RestrictChildren(childTag: "column")]
[OutputElementHint(outputElement: "div")]
public class RowTagHelper : BootstrapTagHelperBase
{
    /// <summary>
    /// Removes the margin from rows and padding from columns.
    /// </summary>
    [HtmlAttributeName("no-gutters")]
    public bool NoGutters { get; set; }

    [HtmlAttributeName("cols")]
    public int Cols { get; set; }

    [HtmlAttributeName("cols-sm")]
    public int ColsSmall { get; set; }

    [HtmlAttributeName("cols-md")]
    public int ColsMedium { get; set; }

    [HtmlAttributeName("cols-lg")]
    public int ColsLarge { get; set; }

    [HtmlAttributeName("cols-xl")]
    public int ColsXLarge { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.AddCssClasses(ClassNames.Rows.Row);

        if (NoGutters)
            output.AddCssClasses(ClassNames.Rows.NoGutters);

        AddColClasses(output);
    }

    private void AddColClasses(TagHelperOutput output)
    {
        var classes = new List<string>();
        AddClass("", Cols);
        AddClass("-sm", ColsSmall);
        AddClass("-md", ColsMedium);
        AddClass("-lg", ColsLarge);
        AddClass("-xl", ColsXLarge);

        void AddClass(string prefix, int cols)
        {
            if (1 <= cols && cols <= 6)
                classes.Add($"{ClassNames.Rows.Cols}{prefix}-{cols}");
        }

        output.AddCssClasses(classes);
    }
}
