using System.Collections.Generic;

namespace RuleEngine.Contracts
{
    /// <summary>
    /// Context Interface
    /// </summary>
    public interface IRuleContext<TContext>
    {
        /// <summary>
        /// Values for the Contaxt
        /// </summary>
        IDictionary<string, object> Properties { get; }

        /// <summary>
        /// Context
        /// </summary>
        TContext Context { get; }
    }
}
