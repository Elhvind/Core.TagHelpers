using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers;

public static class TagHelperOutputExtensions
{
    public static IReadOnlyCollection<string> GetCssClasses(this TagHelperOutput output)
    {
        output.Attributes.TryGetAttribute("class", out TagHelperAttribute attribute);

        IEnumerable<string> classes = attribute?.Value != null
            ? attribute.Value.ToString()!.Split(" ").Where(x => !string.IsNullOrEmpty(x))
            : Array.Empty<string>();

        return classes.Distinct().ToList().AsReadOnly();
    }

    public static void AddCssClasses(this TagHelperOutput output, params string[] classes)
        => AddCssClasses(output, classes?.ToList() ?? new List<string>());

    public static void AddCssClasses(this TagHelperOutput output, IEnumerable<string> classes)
    {
        if (classes == null || !classes.Any(x => !string.IsNullOrWhiteSpace(x)))
            return;

        var existingClasses = GetCssClasses(output);

        var updatedClasses = new List<string>();
        updatedClasses.AddRange(existingClasses);
        updatedClasses.AddRange(classes.Where(x => !string.IsNullOrWhiteSpace(x) && !existingClasses.Contains(x)));

        output.Attributes.SetAttribute("class", string.Join(" ", updatedClasses));
    }

    public static bool HasCssClasses(this TagHelperOutput output, string? @class)
    {
        var classes = GetCssClasses(output);
        return classes?.Contains(@class) ?? false;
    }
}
