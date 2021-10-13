using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ToDoApp.DataAccess.Repository;
using Xunit;

namespace ToDoApp.Tests
{
    public class IntegrationTests : TestBase
    {
        private TestContext _context;

        public IntegrationTests()
        {
            _context = new();
            _context.Services.AddSingleton<IAssignmentRepository>(repository);
        }

        [Fact]
        public void Index_ListOfAssignmentsIsNotNull()
        {
            var component = _context.RenderComponent<BlazorServerUI.Pages.Index>();

            Assert.NotNull(component.Instance.Assignments);
        }

        [Fact]
        public void Index_InsertNoTextAndClickButton_ShouldNotAddAnAssignment()
        {
            var component = _context.RenderComponent<BlazorServerUI.Pages.Index>();
            var buttons = component.FindAll("button");
            var submitButton = buttons.FirstOrDefault(x => x.OuterHtml.Contains("Add"));

            submitButton.Click();

            var result = repository.GetAll();
            Assert.Equal(5, result.ToList().Count());
        }

        [Fact]
        public void Index_InsertTextAndClickButton_ShouldAddOneAssignment()
        {
            var component = _context.RenderComponent<BlazorServerUI.Pages.Index>();
            var buttons = component.FindAll("button");
            var submitButton = buttons.FirstOrDefault(x => x.OuterHtml.Contains("Add"));

            var input = component.Find("#text");
            input.Input("Lulu");

            submitButton.Click();

            var result = repository.GetAll();
            Assert.Equal(6, result.ToList().Count());
        }
    }
}
