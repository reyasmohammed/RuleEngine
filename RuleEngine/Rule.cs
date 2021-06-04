using RuleEngine.Contracts;
using System.Threading.Tasks;

namespace RuleEngine
{
    public abstract class Rule<TContext> : IRule<TContext>
    {
        protected readonly RuleHandler<TContext> Next;

        protected Rule(RuleHandler<TContext> next)
        {
            Next = next;
        }
        public virtual Task Invoke(TContext context)
        {
            if (CanExecute(context))
                return Execute(context);

            return Next != null
                    ? Next(context)
                    : Task.CompletedTask;
        }

        public abstract Task Execute(TContext context);

        public abstract bool CanExecute(TContext context);
    }
}
