using System;
using System.Data;
             
namespace Dapper
{
    /// <summary>
    /// Arguments for 
    /// </summary>
    public class AfterCommandConstructedEventArgs : EventArgs
    {
        /// <summary>
        /// The command
        /// </summary>
        public IDbCommand Command { get; set; }
    }

    /// <summary>
    /// delegate
    /// </summary>
    /// <param name="args"></param>
    public delegate void CommandConstructed(AfterCommandConstructedEventArgs args);

    /// <summary>
    /// Allows to subscribe to global events
    /// </summary>
    public static class GlobalHooks
    {
        /// <summary>
        /// Fires after command was built
        /// </summary>
        public static event CommandConstructed AfterCommandConstructed;

        internal static void AfterCommandConstruction(IDbCommand command)
        {
            AfterCommandConstructed?.Invoke(new AfterCommandConstructedEventArgs()
            {
                Command = command
            });
        }
    }
}
