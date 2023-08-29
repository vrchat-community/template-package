using UnityEditor;
using UnityEngine;

namespace VRChatPackageTemplate.Editor
{
    public class ExampleEditorScript
    {
        public const string MESSAGE = "Hello VRChat!";

        [MenuItem("Example Editor Script/Test")]
        public static void Test() => Debug.Log(MESSAGE);
    }
}
