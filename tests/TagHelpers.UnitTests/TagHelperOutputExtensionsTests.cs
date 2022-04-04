using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace TagHelpers.UnitTests;

public class TagHelperOutputExtensionsTests
{
    public static TheoryData<TagHelperAttributeList, IReadOnlyCollection<string?>> GetCssClassesTestDataSet
    {
        get
        {
            return new TheoryData<TagHelperAttributeList, IReadOnlyCollection<string?>>
            {
                {
                    new TagHelperAttributeList(),
                    new List<string>()
                },
                {
                    new TagHelperAttributeList { { "class", "my-1 my-2 my-3" } },
                    new List<string> { "my-1", "my-2", "my-3" }
                }
            };
        }
    }

    public static TheoryData<IReadOnlyCollection<string>, TagHelperAttributeList, TagHelperAttributeList> AddCssClassesTestDataSet
    {
        get
        {
            return new TheoryData<IReadOnlyCollection<string>, TagHelperAttributeList, TagHelperAttributeList>
                {
                    {
                        new List<string>(),
                        new TagHelperAttributeList(),
                        new TagHelperAttributeList()
                    },
                    {
                        new List<string> { "", "", "" },
                        new TagHelperAttributeList { { "class", "my-1" } },
                        new TagHelperAttributeList { { "class", "my-1" } }
                    },
                    {
                        new List<string> { "my-2", "", "" },
                        new TagHelperAttributeList { { "class", "my-1" } },
                        new TagHelperAttributeList { { "class", "my-1 my-2" } }
                    },
                    {
                        new List<string> { "my-2", "my-3", "my-4" },
                        new TagHelperAttributeList { { "class", "my-1" } },
                        new TagHelperAttributeList { { "class", "my-1 my-2 my-3 my-4" } }
                    },
                    {
                        new List<string> { "my-1", "", "" },
                        new TagHelperAttributeList { { "class", "my-1" } },
                        new TagHelperAttributeList { { "class", "my-1" } }
                    },
                    {
                        new List<string> { "my-1", "my-2", "my-3" },
                        new TagHelperAttributeList { { "class", "my-2 my-1" } },
                        new TagHelperAttributeList { { "class", "my-2 my-1 my-3" } }
                    },
                };
        }
    }

    public static TheoryData<TagHelperAttributeList, string?, bool> HasCssClassesTestDataSet
    {
        get
        {
            return new TheoryData<TagHelperAttributeList, string?, bool>
            {
                {
                    new TagHelperAttributeList(),
                    "someClass",
                    false
                },
                {
                    new TagHelperAttributeList { { "class", "my-1 my-2 my-3" } },
                    "someClass",
                    false
                },
                {
                    new TagHelperAttributeList { { "class", "my-1 my-2 my-3" } },
                    "my-2",
                    true
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(GetCssClassesTestDataSet))]
    public void GetCssClasses_GeneratesExpectedOutput(
        TagHelperAttributeList outputAttributes,
        IReadOnlyCollection<string?> expectedClasses)
    {
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("some-tag", outputAttributes);

        var actual = TagHelperOutputExtensions.GetCssClasses(tagHelperOutput);

        actual.Count.Should().Be(expectedClasses.Count);
        actual.Should().ContainInOrder(expectedClasses);
    }

    [Theory]
    [MemberData(nameof(AddCssClassesTestDataSet))]
    public void AddCssClasses_GeneratesExpectedOutput(
        IReadOnlyCollection<string> classesToAdd,
        TagHelperAttributeList outputAttributes,
        TagHelperAttributeList expectedAttributes)
    {
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("some-tag", outputAttributes);

        tagHelperOutput.AddCssClasses(classesToAdd);

        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }

    [Theory]
    [MemberData(nameof(HasCssClassesTestDataSet))]
    public void HasCssClasses_GeneratesExpectedOutput(
        TagHelperAttributeList outputAttributes,
        string? @class,
        bool hasClass)
    {
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("some-tag", outputAttributes);

        var actual = TagHelperOutputExtensions.HasCssClasses(tagHelperOutput, @class);

        actual.Should().Be(hasClass);
    }
}
