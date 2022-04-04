using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Content;
using TagHelpers.Content.Typography;
using Xunit;

namespace TagHelpers.UnitTests.Content.Typography;

public class HeadingTagHelperTests
{
    public static TheoryData<string, TagHelperAttributeList, TagHelperAttributeList, TagHelperAttributeList> TestDataSet
    {
        get
        {
            return new TheoryData<string, TagHelperAttributeList, TagHelperAttributeList, TagHelperAttributeList>
            {
                {
                    "h1",
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                    },
                    new TagHelperAttributeList
                    {
                    }
                },
                #region Regular headings
                {
                    "h1",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H1 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    }
                },
                {
                    "h2",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H2 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    }
                },
                {
                    "h3",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H3 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    }
                },
                {
                    "h4",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H4 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    }
                },
                {
                    "h5",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H5 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    }
                },
                {
                    "h6",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H6 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-1" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-1" },
                    }
                },
                #endregion Regular headings
                #region Imitate headings
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H1 },
                        { "imitate", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h1" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H2 },
                        { "imitate", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h2" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H3 },
                        { "imitate", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h3" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H4 },
                        { "imitate", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h4" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H5 },
                        { "imitate", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h5" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H6 },
                        { "imitate", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-1" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-1 h6" },
                    }
                },
                #endregion Imitate headings
                #region Regular display headings
                {
                    "h1",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H1 },
                        { "display-level", DisplayLevel.D1 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 display-1" },
                    }
                },
                {
                    "h2",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H2 },
                        { "display-level", DisplayLevel.D2 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 display-2" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    }
                },
                {
                    "h3",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H3 },
                        { "display-level", DisplayLevel.D3 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 display-3" },
                    }
                },
                {
                    "h4",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H4 },
                        { "display-level", DisplayLevel.D4 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 display-4" },
                    }
                },
                #endregion Regular display headings
                #region Imitate display headings
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H1 },
                        { "imitate", true },
                        { "display-level", DisplayLevel.D1 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h1 display-1" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H2 },
                        { "imitate", true },
                        { "display-level", DisplayLevel.D2 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h2 display-2" },
                        { "role", "heading" },
                        { "aria-level", "2" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H3 },
                        { "imitate", true },
                        { "display-level", DisplayLevel.D3 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h3 display-3" },
                    }
                },
                {
                    "p",
                    new TagHelperAttributeList
                    {
                        { "level", HeadingLevel.H4 },
                        { "imitate", true },
                        { "display-level", DisplayLevel.D4 },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "MyHeading" },
                        { "class", "my-3 h4 display-4" },
                    }
                },
                #endregion Imitate display headings
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestDataSet))]
    public void Process_GeneratesExpectedOutput(
        string exptectedTagName,
        TagHelperAttributeList contextAttributes,
        TagHelperAttributeList outputAttributes,
        TagHelperAttributeList expectedAttributes)
    {
        // Arrange
        const string exptectedContent = "someContent";

        var tagHelperContext = TagHelperTesting.CreateTagHelperContext("spinner", contextAttributes);
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("spinner", outputAttributes);

        tagHelperOutput.Content.SetContent(exptectedContent);

        var headingTagHelper = new HeadingTagHelper();

        if (contextAttributes.TryGetAttribute("level", out var level))
            headingTagHelper.Level = (HeadingLevel)level.Value;

        if (contextAttributes.TryGetAttribute("imitate", out var imitate))
            headingTagHelper.Imitate = (bool)imitate.Value;

        if (contextAttributes.TryGetAttribute("display-level", out var displayLevel))
            headingTagHelper.DisplayLevel = (DisplayLevel?)displayLevel.Value;

        // Act
        headingTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert
        tagHelperOutput.TagName.Should().Be(exptectedTagName);
        tagHelperOutput.TagMode.Should().Be(TagMode.StartTagAndEndTag);
        tagHelperOutput.Content.GetContent().Should().Be(exptectedContent);
        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }
}
