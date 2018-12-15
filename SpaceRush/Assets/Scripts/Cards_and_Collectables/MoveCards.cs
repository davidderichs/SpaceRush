using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;   

public class MoveCards {
	
	public List<MoveCard>  card_List;

	public MoveCards(){
		this.card_List = new List<MoveCard>();
	}
	public MoveCards(int number_of_Cards){
		this.card_List = new List<MoveCard>(number_of_Cards);
	}

	public MoveCards(List<MoveCard> cardList){
		this.card_List = cardList;
	}	

	public static MoveCards get_random_Movecards(int amount){
		MoveCards default_stack = JSONParser.read_Default_Stack_from_JSON();
		MoveCards random_stack = new MoveCards(amount);
		for (int i=0; i<amount; i++){
			random_stack.add_MoveCard(default_stack.get_MoveCard((int)UnityEngine.Random.Range(0.0f, 50.0f)));
		}
		return random_stack;
	}

	public void add_MoveCard(MoveCard card){
		// Debug.Log("MoveCards adding Card");
		this.card_List.Add(card);
	}
	public void remove_MoveCard(MoveCard card){
		// Debug.Log("MoveCards removing Card");
		this.card_List.Remove(card);
	}
	public void remove_MoveCard_With_Index(int index){
		// Debug.Log("card_list.count: " + this.card_List.Count);
		// Debug.Log("index: " + index);
		this.card_List.RemoveAt(index);
	}

	public MoveCard get_MoveCard(int index){
		if(this.card_List.Count > 0 ){
			return this.card_List[index];
		} else return null;
		
	}

	public int size(){
		return this.card_List.Count;
	}

	public void fill_Player_Stack(){

	}

}