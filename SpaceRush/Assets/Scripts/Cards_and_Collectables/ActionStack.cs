using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionStack{
    public List<ActionCard> actionList;

    public ActionStack(){
        this.actionList = new List<ActionCard>();
    }

    public ActionStack(int capacity){
        this.actionList = new List<ActionCard>();
    }

    public void addActionCard(ActionCard action){
        actionList.Add(action);
    }

    public void removeActionCard(ActionCard action){
        actionList.Remove(action);
    }

    public void removeActionCardwithIndex(int index){
        actionList.RemoveAt(index);
    }

    public ActionCard getActionCard(int index){
        if(index < actionList.Count){
            return actionList[index];
        }
        else return ActionCardStorage.getEmpty();
    }

    public int getSize(){
        return actionList.Count;
    }
}