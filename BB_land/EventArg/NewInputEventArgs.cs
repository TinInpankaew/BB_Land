using System;

namespace BB_land.EventArg
{
    internal class NewInputEventArgs : EventArgs
    {
        public Common.Inputs Inputs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System,EventArgs"/> class.
        /// </summary>
        public NewInputEventArgs(Common.Inputs inputs)
        {
            Inputs = inputs;
        }

    }
}
