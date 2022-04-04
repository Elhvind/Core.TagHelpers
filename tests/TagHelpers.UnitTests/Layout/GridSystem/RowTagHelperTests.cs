using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Layout.GridSystem;
using Xunit;

namespace TagHelpers.UnitTests.Layout.GridSystem;

public class RowTagHelperTests
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
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "row" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "RowId" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "RowId" },
                        { "class", "my-3 row" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "   my-3      mx-2 " },
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "my-3 mx-2 row" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "no-gutters", true },
                        { "cols", 4 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "RowId" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "RowId" },
                        { "class", "my-3 row no-gutters row-cols-4" },
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
        const string exptectedContent = "someContent";

        var tagHelperContext = TagHelperTesting.CreateTagHelperContext("row", contextAttributes);
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("row", outputAttributes);

        tagHelperOutput.Content.SetContent(exptectedContent);

        var rowTagHelper = new RowTagHelper()
        {
            NoGutters = contextAttributes.TryGetAttribute("no-gutters", out var noGutters) && (bool)noGutters.Value,
            Cols = contextAttributes.TryGetAttribute("cols", out var cols) ? (int)cols.Value : default,
        };

        // Act
        rowTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert
        tagHelperOutput.TagName.Should().Be("div");
        tagHelperOutput.TagMode.Should().Be(TagMode.StartTagAndEndTag);
        tagHelperOutput.Content.GetContent().Should().Be(exptectedContent);
        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }
}
