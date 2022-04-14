using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUiHandler
{
    void OnReStartGame();

    void OnGotoMenu();

    void OnStartGame();

    void OnQuit();

    void LoadAScene(string name);
}
