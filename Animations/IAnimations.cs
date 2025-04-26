using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekota_McLauncher.Animations
{
    public interface IAnimations
    {
        /// <summary>
        /// The delay of the animation
        /// </summary>
        TimeSpan Delay { get; set; }

        /// <summary>
        /// Demonstrates if the animation should wait
        /// </summary>
        bool Wait { get; set; }

        /// <summary>
        /// Runs the animation asynchronously
        /// </summary>
        /// <returns><see cref="Task"/> The task</returns>
        Task RunAsync();

        /// <summary>
        /// Cancels the animation
        /// </summary>
        void Cancel();
    }
}
