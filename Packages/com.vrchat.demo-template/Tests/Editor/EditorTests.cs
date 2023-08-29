using NUnit.Framework;
using UnityEngine.TestTools;

namespace VRChatPackageTemplate.Editor.Tests
{
    public class EditorTests
    {
        // Ensure that the Example Editor Script logs properly
        [Test]
        public void ExampleEditorTest()
        {
            ExampleEditorScript.Test();
            LogAssert.Expect(UnityEngine.LogType.Log, ExampleEditorScript.MESSAGE);
        }
    }
}
