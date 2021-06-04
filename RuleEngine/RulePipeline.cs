using RuleEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuleEngine
{
    class RulePipeline<TContext> : IRulePipeline<TContext>
    {
        private readonly IServiceProvider _services;
        private readonly Stack<Func<RuleHandler<TContext>, RuleHandler<TContext>>> _components =
            new Stack<Func<RuleHandler<TContext>, RuleHandler<TContext>>>();

        public RulePipeline(IServiceProvider services) => _services = services;


        /// <summary>
        /// Builds delegate to process rules executions.
        /// </summary>
        /// <returns>The rules handling delegate.</returns>
        public RuleHandler<TContext> Build()
        {
            var next = new RuleHandler<TContext>(context => Task.CompletedTask);
            while (_components.Any())
            {
                var component = _components.Pop();
                next = component(next);
            }
            return next;
        }

        /// <summary>
        /// Adds a rule to the pipeline.
        /// </summary>
        /// <returns>pipeline</returns>
        public IRulePipeline<TContext> Add<TRule>()
        {
            //Create a delegate
            _components.Push(CreateDelegate<TRule>);
            return this;
        }

        private RuleHandler<TContext> CreateDelegate<TRule>(RuleHandler<TContext> next)
        {
            //Create the rule instance and return the delegate for the rule
            return null;
        }
    }
}
