using APIs.Controllers;
using Application.Expenses.Queries.GetExpenseById;
using AutoFixture.NUnit3;
using Domain.Dtos;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Moq;
using UnitTests.AutoFixure;

namespace UnitTesting.CoursesTests
{
    public class CoursesControllerTests
    {
        [Theory]
        [AutoMockData]
        public async Task GetExpenseById_Handle_Success(GetExpenseByIdQuery command, ExpenseDto expense,
        [Frozen] Mock<IMediator> mediator,
          [Greedy] ExpensesController expensesController)
        {

            //Arrange
            mediator.Setup(pa => pa.Send(It.IsAny<GetExpenseByIdQuery>(), new CancellationToken())).ReturnsAsync(expense);

            //Act
            var response = await expensesController.GetExpenseById(command);

            //Assert
            response.Should().BeEquivalentTo(expense);

        }

        [Theory]
        [AutoMockData]
        public async Task GetExpenseById_Handle_Exception(GetExpenseByIdQuery command, ExpenseDto expense,
        [Frozen] Mock<IMediator> mediator,
          [Greedy] ExpensesController expensesController)
        {

            //Arrange
            //getCoursesQueryHandler.Setup(pa => pa.Handle(command, new CancellationToken())).ReturnsAsync(result);
            mediator.Setup(pa => pa.Send(It.IsAny<GetExpenseByIdQuery>(), new CancellationToken())).ThrowsAsync(new Exception());


            //Act
            Func<Task> func = async () => await expensesController.GetExpenseById(command);


            //Assert
            await func.Should().ThrowAsync<Exception>();

        }

    }
}
