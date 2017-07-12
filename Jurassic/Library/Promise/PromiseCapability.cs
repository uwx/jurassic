namespace Jurassic.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class PromiseCapability
    {
        /// <summary>
        /// A reference to the promise.
        /// </summary>
        public PromiseInstance Promise { get; set; }

        /// <summary>
        /// A function that resolves the promise.
        /// </summary>
        public FunctionInstance Resolve { get; set; }

        /// <summary>
        /// A function that rejects the promise.
        /// </summary>
        public FunctionInstance Reject { get; set; }
    }
}