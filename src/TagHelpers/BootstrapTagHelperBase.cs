using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers;

public class BootstrapTagHelperBase : TagHelper
{
    /// <summary>
    /// Generates the class name from the given prefix and colour. The method returns <c>{prefix}-{colour}</c>.
    /// </summary>
    /// <param name="prefix">
    /// The prefix (without a dash) for the class name, for instance <c>btn</c>.
    /// </param>
    /// <param name="color">The colour to create the class name from.</param>
    /// <returns>
    /// Returns the class name as <c>{prefix}-{color}</c> or <c>null</c> if <paramref name="color"/> is <c>null</c>.
    /// </returns>
    protected static string GetColorClassName(string prefix, ThemeColor color) => $"{prefix}-{color.ToString().ToLower()}";
}
