using Domain.Dtos;
using Moq;
using UnitTests.AutoFixure;
using AutoFixture.NUnit3;
using FluentAssertions;
using Infrastructure.Interfaces;
using Application.Expenses.Queries.GetExpenseById;

namespace UnitTesting.CoursesTests.Queries
{
    public class GetCoursesQueryTest
    {

        [Theory]
        [AutoMockData]
        public async Task GetExpense_Handle_Success(GetExpenseByIdQuery request, [Frozen] Mock<IReadExpenseRepository> expenseRepository,
          ExpenseDto expense,
         [Greedy] GetExpenseByIdQueryHandler handler)
        {

            //Arrange
            expenseRepository.Setup(pa => pa.GetExpenseById(It.IsAny<int>(), new CancellationToken())).ReturnsAsync(expense);

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Should().BeEquivalentTo(expense);


        }

        [Theory]
        [AutoMockData]
        public async Task GetExpense_Handle_Exception(GetExpenseByIdQuery request, [Frozen] Mock<IReadExpenseRepository> expenseRepository,

         [Greedy] GetExpenseByIdQueryHandler handler)
        {

            //Arrange
            expenseRepository.Setup(pa => pa.GetExpenseById(It.IsAny<int>(), new CancellationToken())).ThrowsAsync(new Exception());

            //Act
            Func<Task> func = async () => await handler.Handle(request, CancellationToken.None);

            //Assert
            await func.Should().ThrowAsync<Exception>();

        }
    }


}
