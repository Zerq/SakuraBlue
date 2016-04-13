using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;

namespace speechTest {


    class Program {





        static void Main(string[] args) {





            System.Speech.Synthesis.SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer();
            List<InstalledVoice> voices = new List<InstalledVoice>();
            voices.AddRange(synth.GetInstalledVoices(new CultureInfo("en-GB")));
            voices.AddRange(synth.GetInstalledVoices(new CultureInfo("en-US")));

            //   synth.Voice.
            synth.SpeakAsync(@"one two three blarg!
Shoe shop event horizon.
bannana puding to the nth degree
poisoning pigeons in the park");

            Console.Read();
            synth.SpeakAsyncCancelAll();
        }
    }
}
