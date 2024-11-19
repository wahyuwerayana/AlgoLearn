using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateValue : MonoBehaviour
{
    private void Start() {
        LevelHandler.ChapterCountCProgramming= 1;
        LevelHandler.LevelCountBasicsCProgramming = 1;
        LevelHandler.LevelCountArithmeticOperationCProgramming = 1;
        LevelHandler.LevelCountConditionsCProgramming = 1;
    }
}
