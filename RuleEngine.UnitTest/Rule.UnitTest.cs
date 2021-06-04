using Moq;
using System.Threading.Tasks;
using Xunit;

namespace RuleEngine.UnitTest
{
    public class RuleUniTest
    {
        [Theory]
        [InlineData(true, 1, 1)]
        [InlineData(false, 1, 0)]
        public void Rule_Invoke_ShouldOnlyCallExecute_When_CanExecuteReturns_True(bool canExecuteResult, int expectedCanExecuteExecutions, int expectedExecuteExecutions)
        {
            //Rule setup
            var rule = new Mock<Rule<object>>(MockBehavior.Loose, null) { CallBase = true };
            rule.Setup(_ => _.CanExecute(It.IsAny<object>())).Returns(canExecuteResult);
            rule.Setup(_ => _.Execute(It.IsAny<object>())).Returns(Task.CompletedTask);

            //Process
            rule.Object.Invoke(new object());

            // Verify
            rule.Verify(_ => _.CanExecute(It.IsAny<object>()), Times.Exactly(expectedCanExecuteExecutions));
            rule.Verify(_ => _.Execute(It.IsAny<object>()), Times.Exactly(expectedExecuteExecutions));
        }

        
    }
}
