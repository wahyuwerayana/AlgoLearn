using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterAndLevelUnlocker : MonoBehaviour
{
    public List<Button> chaptersOrLevels;
    [SerializeField] private bool checkChapters;
    [SerializeField] private bool checkLevelsBasics;
    [SerializeField] private bool checkLevelsArithmeticOperations;
    [SerializeField] private bool checkLevelsConditions;
    

    private void Start() {
        int levelCount = GetValue();

        UnlockLevel(levelCount);
    }

    private void UnlockLevel(int levelCount){
        for(int i = 0; i < levelCount; i++){
            chaptersOrLevels[i].interactable = true;
        }
    }

    private int GetValue(){
        if(checkChapters){
            return LevelHandler.ChapterCountCProgramming;
        } else if(checkLevelsBasics){
            return LevelHandler.LevelCountBasicsCProgramming;
        } else if(checkLevelsArithmeticOperations){
            return LevelHandler.LevelCountArithmeticOperationCProgramming;
        } else if(checkLevelsConditions){
            return LevelHandler.LevelCountConditionsCProgramming;
        } else{
            return 1;
        }
    }
}
