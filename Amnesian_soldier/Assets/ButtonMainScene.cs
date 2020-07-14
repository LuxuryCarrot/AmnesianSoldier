using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainScene : ButtonParent
{
    public override void Execute()
    {
        base.Execute();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
