using RuleEngine.Contracts;
using System;

namespace RuleEngine
{
    class RulePipeline<TContext> : IRulePipeline<TContext>
    {
        /// <summary>
        /// Builds delegate to process rules executions.
        /// </summary>
        /// <returns>The rules handling delegate.</returns>
        public RuleHandler<TContext> Build()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a rule to the pipeline.
        /// </summary>
        /// <returns>pipeline</returns>
        public IRulePipeline<TContext> Add<TRule>()
        {
            throw new NotImplementedException();
        }
    }
}
