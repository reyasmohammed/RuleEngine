using System.Threading.Tasks;

namespace RuleEngine.Contracts
{
    /// <summary>
    /// Rule Interface
    /// </summary>
    public interface IRule<TContext>
    {
        
        Task Invoke(TContext context);

        /// <summary>
        /// Executes Rule
        /// </summary>
        /// <returns></returns>
        Task Execute(TContext context);

        /// <summary>
        /// Checks whether the rule can be executed
        /// </summary>
        /// <returns></returns>
        bool CanExecute(TContext context);
    }
}
