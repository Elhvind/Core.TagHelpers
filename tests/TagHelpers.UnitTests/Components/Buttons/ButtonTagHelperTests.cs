using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Components.Buttons;
using Xunit;

namespace TagHelpers.UnitTests.Components.Buttons;

public class ButtonTagHelperTests
{
    public static TheoryData<string, TagHelperAttributeList, TagHelperAttributeList, TagHelperAttributeList> TestDataSet
    {
        get
        {
            return new TheoryData<string, TagHelperAttributeList, TagHelperAttributeList, TagHelperAttributeList>
            {
                {
                    "button",
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "type", "button" },
                        { "class", "btn btn-primary" },
                    }
                },
                {
                    "button",
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "active" },
                    },
                    new TagHelperAttributeList
                    {
                        { "type", "button" },
                        { "class", "active btn btn-primary" },
                        { "aria-pressed", "true" },
                    }
                },
                {
                    "button",
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "disabled" },
                    },
                    new TagHelperAttributeList
                    {
                        { "type", "button" },
                        { "class", "disabled btn btn-primary" },
                        { "disabled", null },
                        { "aria-disabled", "true" },
                    }
                },
                {
                    "a",
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                        { "role", "button" },
                        { "class", "btn btn-primary" },
                    }
                },
                {
                    "a",
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                        { "link", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                        { "role", "button" },
                        { "class", "btn btn-link" },
                    }
                },
                {
                    "button",
                    new TagHelperAttributeList
                    {
                        { "variant", ThemeColor.Secondary },
                        { "submit", true },
                        { "block", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "type", "submit" },
                        { "class", "btn btn-block btn-secondary" },
                    }
                },
                {
                    "button",
                    new TagHelperAttributeList
                    {
                        { "variant", ThemeColor.Secondary },
                        { "submit", true },
                        { "block", true },
                        { "outline", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "type", "submit" },
                        { "class", "btn btn-block btn-outline-secondary" },
                    }
                },
                {
                    "button",
                    new TagHelperAttributeList
                    {
                        { "variant", ThemeColor.Secondary },
                        { "size", ButtonSize.Large },
                        { "submit", true },
                        { "block", true },
                        { "outline", true },
                        { "disabled", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "type", "submit" },
                        { "class", "btn btn-lg btn-block btn-outline-secondary" },
                        { "disabled", null },
                        { "aria-disabled", "true" },
                    }
                },
                {
                    "button",
                    new TagHelperAttributeList
                    {
                        { "variant", ThemeColor.Secondary },
                        { "size", ButtonSize.Small },
                        { "submit", true },
                        { "block", true },
                        { "outline", true },
                        { "active", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "type", "submit" },
                        { "class", "btn btn-sm btn-block btn-outline-secondary active" },
                        { "aria-pressed", "true" },
                    }
                },
                {
                    "a",
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                        { "variant", ThemeColor.Secondary },
                        { "size", ButtonSize.Large },
                        { "submit", true },
                        { "block", true },
                        { "outline", true },
                        { "disabled", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                        { "role", "button" },
                        { "class", "btn btn-lg btn-block btn-outline-secondary disabled" },
                        { "aria-disabled", "true" },
                    }
                },
                {
                    "a",
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                        { "variant", ThemeColor.Secondary },
                        { "size", ButtonSize.Small },
                        { "submit", true },
                        { "block", true },
                        { "outline", true },
                        { "active", true },
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                        { "href", "#" },
                        { "role", "button" },
                        { "class", "btn btn-sm btn-block btn-outline-secondary active" },
                        { "aria-pressed", "true" },
                    }
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataSet))]
    public void Process_GeneratesExpectedOutput(
        string expectedTagName,
        TagHelperAttributeList contextAttributes,
        TagHelperAttributeList outputAttributes,
        TagHelperAttributeList expectedAttributes)
    {
        // Arrange
        const string exptectedContent = "someContent";

        var tagHelperContext = TagHelperTesting.CreateTagHelperContext("btn", contextAttributes);
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("btn", outputAttributes);

        tagHelperOutput.Content.SetContent(exptectedContent);

        var buttonTagHelper = new ButtonTagHelper()
        {
            Href = contextAttributes.TryGetAttribute("href", out var href) ? href.Value?.ToString() : null,
            Size = contextAttributes.TryGetAttribute("size", out var size) ? (ButtonSize)size.Value : default,
            Variant = contextAttributes.TryGetAttribute("variant", out var variant) ? (ThemeColor)variant.Value : default,
            Block = contextAttributes.TryGetAttribute("block", out var block) && (bool)block.Value,
            Link = contextAttributes.TryGetAttribute("link", out var link) && (bool)link.Value,
            Disabled = contextAttributes.TryGetAttribute("disabled", out var disabled) && (bool)disabled.Value,
            Submit = contextAttributes.TryGetAttribute("submit", out var submit) && (bool)submit.Value,
            Active = contextAttributes.TryGetAttribute("active", out var active) && (bool)active.Value,
            Outline = contextAttributes.TryGetAttribute("outline", out var outline) && (bool)outline.Value,
        };

        // Act
        buttonTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert
        tagHelperOutput.TagName.Should().Be(expectedTagName);
        tagHelperOutput.TagMode.Should().Be(TagMode.StartTagAndEndTag);
        tagHelperOutput.Content.GetContent().Should().Be(exptectedContent);
        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }
}
