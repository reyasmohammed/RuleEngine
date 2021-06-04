using System.Threading.Tasks;

namespace RuleEngine.Contracts
{
    /// <summary>
    /// A function to process rule.
    /// </summary>
    /// <param name="context"></param>
    /// <returns>Task representing completion of processed rule</returns>
    public delegate Task RuleHandler<TContext>(TContext context);
}
