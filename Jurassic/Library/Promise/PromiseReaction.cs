namespace Jurassic.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class PromiseReaction
    {
        /// <summary>
        /// 
        /// </summary>
        public PromiseCapability Capabilities { get; set; }

        /// <summary>
        /// The function to call when the reaction is triggered.
        /// </summary>
        public FunctionInstance Handler { get; set; }
    }
}