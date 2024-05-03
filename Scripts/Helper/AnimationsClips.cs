using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianMikeMono.Scripts.Helper;
/// <summary>
/// Conatins reference to the game animations clips names
/// </summary>
public class AnimationsClips
{
    /// <summary>
    /// Contains references to the player animation names
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Reference to the<c>Fall</c>animation clip
        /// </summary>
        public const string FALL = "Fall";

        /// <summary>
        /// Reference to the<c>Idle</c>animation clip
        /// </summary>
        public const string IDLE = "Idle";

        /// <summary>
        /// Reference to the<c>Jump</c>animation clip
        /// </summary>
        public const string JUMP = "Jump";

        /// <summary>
        /// Reference to the<c>Run</c>animation clip
        /// </summary>
        public const string RUN = "Run";
    }

    
    public class JumpPad
    {
        /// <summary>
        /// Reference to the<c>Idle</c>animation clip
        /// </summary>
        public const string IDLE = "Idle";

        /// <summary>
        /// Reference to the<c>Catapult</c>animation clip
        /// </summary>
        public const string CATAPULT = "Catapult";
    }
}
