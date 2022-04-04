using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Components.Buttons;
using Xunit;

namespace TagHelpers.UnitTests.Components.Buttons;

public class ButtonGroupTagHelperTests
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
                        { "role", "group" },
                        { "class", "btn-group" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "vertical", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "role", "group" },
                        { "class", "btn-group-vertical" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "vertical", false },
                        { "size", ButtonSize.Large },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "role", "group" },
                        { "class", "btn-group btn-group-lg" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "vertical", true },
                        { "size", ButtonSize.Small },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "role", "group" },
                        { "class", "btn-group-vertical btn-group-sm" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "label", "Testing group SR labels" },
                        { "size", ButtonSize.Small },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyGroup" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyGroup" },
                        { "role", "group" },
                        { "aria-label", "Testing group SR labels" },
                        { "class", "btn-group btn-group-sm" },
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

        var tagHelperContext = TagHelperTesting.CreateTagHelperContext("btn-group", contextAttributes);
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("btn-group", outputAttributes);

        tagHelperOutput.Content.SetContent(exptectedContent);

        var buttonGroupTagHelper = new ButtonGroupTagHelper()
        {
            Size = contextAttributes.TryGetAttribute("size", out var size) ? (ButtonSize)size.Value : default,
            Label = contextAttributes.TryGetAttribute("label", out var label) ? label.Value?.ToString() : null,
            Vertical = contextAttributes.TryGetAttribute("vertical", out var vertical) && (bool)vertical.Value,
        };

        // Act
        buttonGroupTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert
        tagHelperOutput.TagName.Should().Be("div");
        tagHelperOutput.TagMode.Should().Be(TagMode.StartTagAndEndTag);
        tagHelperOutput.Content.GetContent().Should().Be(exptectedContent);
        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }
}
