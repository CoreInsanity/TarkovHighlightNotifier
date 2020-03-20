using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTHighlightDetector.models
{
    class TarkovConfig
    {
        public class Variant
        {
            public bool isAxis { get; set; }
            public List<object> keyCode { get; set; }
            public string axisName { get; set; }
            public bool positiveAxis { get; set; }
            public double deadZone { get; set; }
            public double sensitivity { get; set; }
        }

        public class KeyBinding
        {
            public string keyName { get; set; }
            public List<Variant> variants { get; set; }
            public string pressType { get; set; }
            public bool pressAvailable { get; set; }
        }

        public class Positive
        {
            public bool isAxis { get; set; }
            public List<object> keyCode { get; set; }
            public string axisName { get; set; }
            public bool positiveAxis { get; set; }
            public double deadZone { get; set; }
            public double sensitivity { get; set; }
        }

        public class Negative
        {
            public bool isAxis { get; set; }
            public List<object> keyCode { get; set; }
            public string axisName { get; set; }
            public bool positiveAxis { get; set; }
            public double deadZone { get; set; }
            public double sensitivity { get; set; }
        }

        public class Pair
        {
            public Positive positive { get; set; }
            public Negative negative { get; set; }
        }

        public class AxisBinding
        {
            public string axisName { get; set; }
            public List<Pair> pairs { get; set; }
            public bool isInverted { get; set; }
            public double gravity { get; set; }
            public bool snapToZero { get; set; }
            public string modificator { get; set; }
        }

        public class GetBoundItemNames
        {
            public string ItemV { get; set; }
            public string Item1 { get; set; }
            public string Item2 { get; set; }
            public string Item3 { get; set; }
            public string Item4 { get; set; }
            public string Item5 { get; set; }
            public string Item6 { get; set; }
            public string Item7 { get; set; }
            public string Item8 { get; set; }
            public string Item9 { get; set; }
            public string Item10 { get; set; }
        }

        public class RootObject
        {
            public List<KeyBinding> keyBindings { get; set; }
            public List<AxisBinding> axisBindings { get; set; }
            public bool StatedInvertedXAxisValue { get; set; }
            public bool StatedInvertedYAxisValue { get; set; }
            public bool InvertedXAxis { get; set; }
            public bool InvertedYAxis { get; set; }
            public double MouseSensitivity { get; set; }
            public double MouseAimingSensitivity { get; set; }
            public double DoubleClickTimeout { get; set; }
            public double StatedFieldOfView { get; set; }
            public double StatedHeadbobbing { get; set; }
            public string Language { get; set; }
            public bool Subtitles { get; set; }
            public bool TutorialHints { get; set; }
            public bool AlwaysShowInterfaceElements { get; set; }
            public bool DontAllowToAddMe { get; set; }
            public int AimingDeadzone { get; set; }
            public int Fov { get; set; }
            public int Headbobbing { get; set; }
            public bool NVidiaHighlightsEnabled { get; set; }
            public bool ClearRAM { get; set; }
            public bool SetAffinityToLogicalCores { get; set; }
            public bool Blood { get; set; }
            public bool BadLanguage { get; set; }
            public int RagfairLinesCountIndex { get; set; }
            public string EnvironmentUiType { get; set; }
            public object CharacterVoiceLanguage { get; set; }
            public int OverallVolume { get; set; }
            public int EffectsVolume { get; set; }
            public int InterfaceVolume { get; set; }
            public int ChatVolume { get; set; }
            public int MusicVolume { get; set; }
            public int VoiceVolume { get; set; }
            public int HideoutVolume { get; set; }
            public int MicrophoneSensitivity { get; set; }
            public bool MuteOtherPlayers { get; set; }
            public bool MusicOnRaidEnd { get; set; }
            public GetBoundItemNames GetBoundItemNames { get; set; }
            public int XInvert { get; set; }
            public int YInvert { get; set; }
            public int HideoutVolumeValue { get; set; }
        }
    }
}
