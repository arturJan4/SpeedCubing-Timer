using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    public class Sound
    {
        private string DirName;
        private bool loadedFiles;
        static SoundPlayer InspectionStartSound;
        static SoundPlayer InspectionEndSound;
        static SoundPlayer SolveEndSound;
        public bool PlaySounds { get; set; }
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

        public void PlayInspectionStartSound()
        {
            if(loadedFiles && PlaySounds)
            {
                InspectionStartSound.Play();
            }
        }

        public void PlaySolveEndSound()
        {
            if (loadedFiles && PlaySounds)
            {
                SolveEndSound.Play();
            }
        }

        public void PlayInspectionEndSound()
        {
            if (loadedFiles && PlaySounds)
            {
                InspectionEndSound.Play();
            }
        }

    }
}
