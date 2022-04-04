using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Components.Buttons;
using Xunit;

namespace TagHelpers.UnitTests.Components.Buttons;

public class ButtonToolbarTagHelperTests
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
                        { "role", "toolbar" },
                        { "class", "btn-toolbar" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "label", "Testing toolbar SR labels" }
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyToolbar" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyToolbar" },
                        { "role", "toolbar" },
                        { "aria-label", "Testing toolbar SR labels" },
                        { "class", "btn-toolbar" },
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

        var tagHelperContext = TagHelperTesting.CreateTagHelperContext("btn-toolbar", contextAttributes);
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("btn-toolbar", outputAttributes);

        tagHelperOutput.Content.SetContent(exptectedContent);

        var buttonToolbarTagHelper = new ButtonToolbarTagHelper()
        {
            Label = contextAttributes.TryGetAttribute("label", out var label) ? label.Value?.ToString() : null,
        };

        // Act
        buttonToolbarTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert
        tagHelperOutput.TagName.Should().Be("div");
        tagHelperOutput.TagMode.Should().Be(TagMode.StartTagAndEndTag);
        tagHelperOutput.Content.GetContent().Should().Be(exptectedContent);
        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }
}
