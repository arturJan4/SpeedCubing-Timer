using System.IO;
using System.Media;

namespace TimerLibrary
{
    /// <summary>
    /// Controls sound files and plays/mutes them
    /// </summary>
    public class Sound
    {
        private readonly string DirName;                         //path to folder where the sounds are located
        private readonly bool loadedFiles;                       //true if all files loaded successfully
        private static SoundPlayer InspectionStartSound;
        private static SoundPlayer InspectionEndSound;          //urges user to start solving
        private static SoundPlayer SolveEndSound;
        public bool PlaySounds { get; set; }            //audio control, if true then play sounds

        /// <summary>
        /// Check if files exist and loads them
        /// </summary>
        /// <param name="dirName">path to folder where the sounds are located</param>
        public Sound(string dirName)
        {
            DirName = dirName;
            if (!File.Exists($"{DirName}InspectionEndSound.wav") ||
                !File.Exists($"{DirName}SolveEndSound.wav") ||
                !File.Exists($"{DirName}InspectionEndSound.wav"))
            {
                loadedFiles = false;
                return;
            }

            InspectionStartSound = new SoundPlayer($"{DirName}InspectionSound.wav");
            InspectionStartSound.Load();

            SolveEndSound = new SoundPlayer($"{DirName}SolveEndSound.wav");
            SolveEndSound.Load();

            InspectionEndSound = new SoundPlayer($"{DirName}InspectionEndSound.wav");
            InspectionEndSound.Load();
            loadedFiles = true;
        }
        /// <summary>
        /// Plays the sound of inspection begin.
        /// </summary>
        public void PlayInspectionStartSound()
        {
            if (loadedFiles && PlaySounds)
            {
                InspectionStartSound.Play();
            }
        }
        /// <summary>
        /// Plays the sound notyfing of getting close to inspection end.
        /// </summary>
        public void PlayInspectionEndSound()
        {
            if (loadedFiles && PlaySounds)
            {
                InspectionEndSound.Play();
            }
        }
        /// <summary>
        /// Plays the sound of finished solve.
        /// </summary>
        public void PlaySolveEndSound()
        {
            if (loadedFiles && PlaySounds)
            {
                SolveEndSound.Play();
            }
        }
    }
}
