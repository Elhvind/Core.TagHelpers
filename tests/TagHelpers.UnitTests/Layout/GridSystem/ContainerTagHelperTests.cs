using FluentAssertions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Layout.GridSystem;
using Xunit;

namespace TagHelpers.UnitTests.Layout.GridSystem;

public class ContainerTagHelperTests
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
                        { "class", "container" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "fluid", false },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "ContainerId" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "ContainerId" },
                        { "class", "my-3 container" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "fluid", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "   my-3      mx-2 " },
                    },
                    new TagHelperAttributeList
                    {
                        { "class", "my-3 mx-2 container-fluid" },
                    }
                },
                {
                    new TagHelperAttributeList
                    {
                        { "fluid", true },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "ContainerId" },
                        { "class", "my-3" },
                    },
                    new TagHelperAttributeList
                    {
                        { "id", "ContainerId" },
                        { "class", "my-3 container-fluid" },
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

        var tagHelperContext = TagHelperTesting.CreateTagHelperContext("container", contextAttributes);
        var tagHelperOutput = TagHelperTesting.CreateTagHelperOutput("container", outputAttributes);

        tagHelperOutput.Content.SetContent(exptectedContent);

        var containerTagHelper = new ContainerTagHelper()
        {
            Fluid = contextAttributes.TryGetAttribute("fluid", out var fluid) && (bool)fluid.Value,
        };

        // Act
        containerTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert
        tagHelperOutput.TagName.Should().Be("div");
        tagHelperOutput.TagMode.Should().Be(TagMode.StartTagAndEndTag);
        tagHelperOutput.Content.GetContent().Should().Be(exptectedContent);
        tagHelperOutput.Attributes.Count.Should().Be(expectedAttributes.Count);
        foreach (var expectedAttribute in expectedAttributes)
            tagHelperOutput.Attributes.Should().ContainSingle(attribute => attribute.Name == expectedAttribute.Name).Which.Should().BeEquivalentTo(expectedAttribute);
    }
}
