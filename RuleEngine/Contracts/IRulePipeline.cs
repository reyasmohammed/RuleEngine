namespace RuleEngine.Contracts
{
    /// <summary>
    /// Defines rule pipeline
    /// </summary>
    public interface IRulePipeline<TContext>
    {
        /// <summary>
        /// Adds a rule to the pipeline.
        /// </summary>
        /// <returns>pipeline</returns>
        IRulePipeline<TContext> Add<TRule>();

        /// <summary>
        /// delegate to process rules executions.
        /// </summary>
        /// <returns>The rules handling delegate.</returns>
        RuleHandler<TContext> Build();
    }
}
