using System;
using System.Collections.Generic;

namespace Jurassic.Library
{
    /// <summary>
    /// Represents an instance of the Promise object.
    /// </summary>
    public partial class PromiseInstance : ObjectInstance
    {
        internal enum PromiseState
        {
            Pending,
            Fulfilled,
            Rejected,
        }

        // Governs how a promise will react to incoming calls to its then() method.
        private PromiseState state = PromiseState.Pending;

        // The value with which the promise has been fulfilled or rejected, if any.  Only
        // meaningful if state is not Pending.
        private object result;

        // 	A list of PromiseReaction records to be processed when/if the promise transitions
        // from the Pending state to the Fulfilled state.
        private readonly List<PromiseReaction> fulfillReactions = new List<PromiseReaction>();

        // 	A list of PromiseReaction records to be processed when/if the promise transitions
        // from the Pending state to the Rejected state.
        private readonly List<PromiseReaction> rejectReactions = new List<PromiseReaction>();


        /// <summary>
        /// Creates a new Promise instance.
        /// </summary>
        /// <param name="prototype"></param>
        /// <param name="executor"></param>
        internal PromiseInstance(ObjectInstance prototype, FunctionInstance executor) : base(prototype)
        {
            FunctionInstance resolveFunc = new ClrStubFunction(Engine.FunctionInstancePrototype, (engine, thisObj, param) =>
            {
                return Undefined.Value;
            });
            FunctionInstance rejectFunc = new ClrStubFunction(Engine.FunctionInstancePrototype, (engine, thisObj, param) =>
            {
                return Undefined.Value;
            });
            try
            {
                executor.Call(Undefined.Value, resolveFunc, rejectFunc);
            }
            catch (JavaScriptException ex)
            {
                rejectFunc.Call(Undefined.Value, ex.ErrorObject);
            }
        }

        /// <summary>
        /// Creates the Map prototype object.
        /// </summary>
        /// <param name="engine"> The script environment. </param>
        /// <param name="constructor"> A reference to the constructor that owns the prototype. </param>
        internal static ObjectInstance CreatePrototype(ScriptEngine engine, PromiseConstructor constructor)
        {
            var result = engine.Object.Construct();
            var properties = GetDeclarativeProperties(engine);
            properties.Add(new PropertyNameAndValue("constructor", constructor, PropertyAttributes.NonEnumerable));
            properties.Add(new PropertyNameAndValue(engine.Symbol.ToStringTag, "Promise", PropertyAttributes.Configurable));
            result.FastSetProperties(properties);
            return result;
        }



        //     JAVASCRIPT FUNCTIONS
        //_________________________________________________________________________________________

        /// <summary>
        /// Returns a Promise and deals with rejected cases only. It behaves the same as calling
        /// Promise.prototype.then(undefined, onRejected).
        /// </summary>
        /// <param name="onRejected"> A Function called when the Promise is rejected. This function
        /// has one argument, the rejection reason. </param>
        /// <returns></returns>
        [JSInternalFunction(Name = "catch")]
        public PromiseInstance Catch(FunctionInstance onRejected)
        {
            return Then(null, onRejected);
        }

        /// <summary>
        /// Returns a Promise. It takes two arguments: callback functions for the success and
        /// failure cases of the Promise.
        /// </summary>
        /// <param name="onFulfilled"> A Function called when the Promise is fulfilled. This
        /// function has one argument, the fulfillment value. </param>
        /// <param name="onRejected"> A Function called when the Promise is rejected. This function
        /// has one argument, the rejection reason. </param>
        /// <returns></returns>
        [JSInternalFunction(Name = "then")]
        public PromiseInstance Then(object onFulfilled, object onRejected)
        {
            // Note: parameters cannot be of type FunctionInstance because then they will be
            // rejected if the caller passes in too few arguments, or explicitly passes in
            // a value of the wrong type.

            throw new NotSupportedException();

            //var promise = new PromiseInstance(InstancePrototype, );
            //
            //var capabilities = new PromiseCapability();
            //capabilities.Promise = this;
            //capabilities.Resolve = 
            //capabilities.Reject
            //
            //FunctionInstance onFulfilledFunction = onFulfilled as FunctionInstance;
            //if (onFulfilledFunction == null)
            //    onFulfilledFunction = Engine.FunctionInstancePrototype; // Identity.
            //var fulfillReaction = new PromiseReaction() { Capabilities = capabilities, Handler = onFulfilledFunction };
            //
            //FunctionInstance onRejectedFunction = onRejected as FunctionInstance;
            //if (onRejectedFunction == null)
            //    onRejectedFunction = new ClrStubFunction(Engine.FunctionInstancePrototype, (engine, thisObj, param) =>
            //    {
            //        throw new JavaScriptException(engine, ErrorType.TypeError, "");
            //    });
            //var rejectReaction = new PromiseReaction() { Capabilities = capabilities, Handler = onRejectedFunction };
            //
            //
            //
            //if (state == PromiseState.Pending)
            //{
            //    fulfillReactions.Add(fulfillReaction);
            //    rejectReactions.Add(rejectReaction);
            //}
            //else if (state == PromiseState.Fulfilled)
            //{
            //    // a. Let value be the value of promise's [[PromiseResult]] internal slot.
            //    // b. Perform EnqueueJob("PromiseJobs", PromiseReactionJob, «fulfillReaction, value»).
            //    Engine.EnqueueJob(() => PromiseReactionJob(fulfillReaction, this.result));
            //}
            //else if (state == PromiseState.Rejected)
            //{
            //    // a. Let reason be the value of promise's [[PromiseResult]] internal slot.
            //    // b. Perform EnqueueJob("PromiseJobs", PromiseReactionJob, «rejectReaction, reason»).
            //    Engine.EnqueueJob(() => PromiseReactionJob(rejectReaction, this.result));
            //}
            //
            //return new PromiseInstance(this.Prototype, null);
        }

        private static void PromiseReactionJob(PromiseReaction reaction, object argument)
        {
            try
            {
                // Call the handler.
                var handlerResult = reaction.Handler.Call(Undefined.Value, argument);

                // Success; resolve the promise.
                reaction.Capabilities.Resolve.Call(Undefined.Value, handlerResult);
            }
            catch (JavaScriptException ex)
            {
                // The handler failed; reject the promise.
                reaction.Capabilities.Reject.Call(Undefined.Value, ex.ErrorObject);
            }
        }
    }
}