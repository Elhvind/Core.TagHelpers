using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Components.Spinners;
using Xunit;

namespace TagHelpers.UnitTests.Components.Spinners;

public class SpinnerTagHelperTests
{
    public static TheoryData<TagHelperAttributeList, TagHelperAttributeList, TagHelperAttributeList> TestDataSet
    {
        get
        {
            return new TheoryData<TagHelperAttributeList, TagHelperAttributeList, TagHelperAttributeList>
            {
                {
                    new TagHelperAttributeList
                    {
                        { "type", SpinnerType.Border },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "role", "status" },
                        { "class", "spinner-border" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "type", SpinnerType.Grow },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MySpinner" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MySpinner" },
                        { "class", "my-3 spinner-grow" },
                        { "role", "status" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "variant", ThemeColor.Primary },
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "   my-3      mx-2 " },
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "my-3 mx-2 spinner-border text-primary" },
                        { "role", "status" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "variant", ThemeColor.Secondary },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MySpinner" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MySpinner" },
                        { "class", "my-3 spinner-border text-secondary" },
                        { "role", "status" },
                    }
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataSet))]
    public void Process_GeneratesExpectedOutput(
        TagHelperAttributeList contextAttributes,
        TagHelperAttributeList outputAttributes,
        TagHelperAttributeList expectedAttributes)
    {
        // Arrange
        const string exptectedTagName = "div";
        const string exptectedContent = @"<span class=""sr-only"">Loading...</span>";

        var tagHelperContext = TagHelperTesting.CreateTagHelperContext("spinner", contextAttributes);
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("spinner", outputAttributes);

        var spinnerTagHelper = new SpinnerTagHelper()
        {
            Variant = contextAttributes.TryGetAttribute("variant", out var variant) ? (ThemeColor?)variant.Value : null,
        };

        if (contextAttributes.TryGetAttribute("type", out var type))
            spinnerTagHelper.Type = (SpinnerType)type.Value;

        // Act
        spinnerTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert
        tagHelperOutput.TagName.Should().Be(exptectedTagName);
        tagHelperOutput.TagMode.Should().Be(TagMode.StartTagAndEndTag);
        tagHelperOutput.Content.GetContent().Should().Be(exptectedContent);
        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }
}
