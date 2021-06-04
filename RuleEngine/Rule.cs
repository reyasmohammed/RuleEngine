using RuleEngine.Contracts;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class Rule<TContext> : IRule<TContext>
    {
        public Task Invoke(TContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task Execute(TContext context)
        {
            throw new System.NotImplementedException();
        }

        public bool CanExecute(TContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
