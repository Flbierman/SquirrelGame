using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterTests : InputTestFixture
{
    GameObject character = Resources.Load<GameObject>("Character");
    Keyboard keyboard;
    // A Test behaves as an ordinary method
    [Test]
    public void CharacterTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CharacterTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    public override void Setup()
    {
    SceneManager.LoadScene("Scenes/SimpleTesting");
    base.Setup();
    keyboard = InputSystem.AddDevice<Keyboard>();

    var mouse = InputSystem.AddDevice<Mouse>();
    Press(mouse.rightButton);
    Release(mouse.rightButton);;
    }
}
