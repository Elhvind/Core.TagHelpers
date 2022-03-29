using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.UnitTests;

public static class TagHelperTesting
{
    public static TagHelperContext CreateTagHelperContext(
            string tagName,
            TagHelperAttributeList attributes)
    {
        return new TagHelperContext(
            tagName: tagName,
            allAttributes: attributes ?? new TagHelperAttributeList(),
            items: new Dictionary<object, object>(),
            uniqueId: "test");
    }

    public static TagHelperOutput CreateTagHelperOutput(
        string tagName,
        TagHelperAttributeList attributes)
    {
        return new TagHelperOutput(
            tagName: tagName,
            attributes: attributes ?? new TagHelperAttributeList(),
            getChildContentAsync: (useCachedResult, encoder) =>
            {
                var tagHelperContent = new DefaultTagHelperContent();
                tagHelperContent.SetContent("Something Else");
                return Task.FromResult<TagHelperContent>(tagHelperContent);
            });
    }
}
