using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Layout.GridSystem;

/// <summary>
/// There are 12 template columns available per row, allowing you to create different combinations of elements that span any number of columns.
/// Column classes indicate the number of template columns to span (e.g., col-4 spans four).
/// widths are set in percentages so you always have the same relative sizing.
/// </summary>
[HtmlTargetElement(tag: "column", ParentTag = "row")]
[OutputElementHint(outputElement: "div")]
public class ColumnTagHelper : BootstrapTagHelperBase
{
    [HtmlAttributeName("cols")]
    public int Cols { get; set; }

    [HtmlAttributeName("sm")]
    public int ColsSmall { get; set; }

    [HtmlAttributeName("md")]
    public int ColsMedium { get; set; }

    [HtmlAttributeName("lg")]
    public int ColsLarge { get; set; }

    [HtmlAttributeName("xl")]
    public int ColsXLarge { get; set; }

    [HtmlAttributeName("offset")]
    public int Offset { get; set; }

    [HtmlAttributeName("offset-sm")]
    public int OffsetSmall { get; set; }

    [HtmlAttributeName("offset-md")]
    public int OffsetMedium { get; set; }

    [HtmlAttributeName("offset-lg")]
    public int OffsetLarge { get; set; }

    [HtmlAttributeName("offset-xl")]
    public int OffsetXLarge { get; set; }

    [HtmlAttributeName("gutter-bottom")]
    public bool GutterBottom { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.TagMode = TagMode.StartTagAndEndTag;

        AddColClasses(output);
        AddColOffsetClasses(output);

        if (GutterBottom)
            output.AddCssClasses("mb-gutter-2");
    }

    private void AddColClasses(TagHelperOutput output)
    {
        var classes = new List<string>();
        AddClass("", Cols);
        AddClass("-sm", ColsSmall);
        AddClass("-md", ColsMedium);
        AddClass("-lg", ColsLarge);
        AddClass("-xl", ColsXLarge);

        if (!classes.Any())
            classes.Add(ClassNames.Cols.Col);

        void AddClass(string prefix, int span)
        {
            if (1 <= span && span <= 12)
                classes.Add($"{ClassNames.Cols.Col}{prefix}-{span}");
        }

        output.AddCssClasses(classes);
    }

    private void AddColOffsetClasses(TagHelperOutput output)
    {
        var classes = new List<string>();
        AddClass("", Offset);
        AddClass("-sm", OffsetSmall);
        AddClass("-md", OffsetMedium);
        AddClass("-lg", OffsetLarge);
        AddClass("-xl", OffsetXLarge);

        void AddClass(string prefix, int span)
        {
            if (1 <= span && span <= 12)
                classes.Add($"offset{prefix}-{span}");
        }

        if (classes.Any())
            output.AddCssClasses(classes);
    }
}
