using Moq;
using UnitTests.AutoFixure;
using AutoFixture.NUnit3;
using FluentAssertions;
using Infrastructure.Interfaces;
using Application.Expenses.Commands.UpdateExpenses;

namespace UnitTesting.CoursesTests.Commands
{
    public class UpdateExpenseCommandTests
    {

        [Theory]
        [AutoMockData]
        public async Task UpdateExpense_Handle_Success(UpdateExpenseCommand request, [Frozen] Mock<IWriteExpenseRepository> expenseRepository,int expenseId,
       [Greedy] UpdateExpenseCommandHandler handler)
        {

            //Arrange
            expenseRepository.Setup(pa => pa.UpdateExpense(It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<int>(), new CancellationToken()))
                .ReturnsAsync(expenseId);
          
            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Should().Be(expenseId);

        }


        [Theory]
        [AutoMockData]
        public async Task UpdateExpense_Handle_Exception(UpdateExpenseCommand request, [Frozen] Mock<IWriteExpenseRepository> expenseRepository,
       [Greedy] UpdateExpenseCommandHandler handler)
        {

            //Arrange
            expenseRepository.Setup(pa => pa.UpdateExpense(It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<int>(), new CancellationToken()))
                 .ThrowsAsync(new Exception());


            //Act
            Func<Task> func = async () => await handler.Handle(request, CancellationToken.None);

            //Assert
            await func.Should().ThrowAsync<Exception>();
        }


    }
}
