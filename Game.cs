using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{

    //initialize variables
    [SerializeField]
    private InputField input;

    bool validInput, correctMonth, correctDate;

    int numberOfPeople;

    Person[] People;

    // Start is called before the first frame update
    void Start()
    {

        //How Many People
        numberOfPeople = Random.Range(1,200);

        //Create People
        People = new Person[numberOfPeople];
        
        //populate
        for(int i = 0; i < numberOfPeople; i++){
            People[i] = new Person(i + 1, Random.Range(1,12));
        }

        //Print the people to the console
        for(int i = 0; i < numberOfPeople; i++){
            Debug.Log(People[i].GetBirthday()); 
        }
        //TEST CODE ^^^^
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Getting the user-input
    public void GetInput(string guess){
        
        //Making sure input is valid
        if(guess.Length != 5){
            validInput = false;
            Debug.Log("Invalid Input!");
            //if input is invalid do something
        }

        //create variables for all values of string... month and date 
        string monthGuess, dateGuess;

        //getting all values of numerals
        monthGuess = guess.Substring(0,2);
        dateGuess = guess.Substring(3);

        //clear input box
        input.text = "";

        //Send input to be compared
        CompareBirthdayGuess(monthGuess, dateGuess);
    }

    //Function to compare guess with People in room
    public void CompareBirthdayGuess(string monthGuess, string dateGuess){

        correctMonth = false;
        correctDate = false;

        //Create char and int to match random number if only 1 digit
        char monthChar = monthGuess[0];
        int monthInt = (int)char.GetNumericValue(monthChar);

        
        char dateChar = dateGuess[0];
        int dateInt = (int)char.GetNumericValue(dateChar);

        
        if(monthInt == 0){
            monthChar = monthGuess[1];
            monthInt = (int)char.GetNumericValue(monthChar);
        }

        
        if(dateInt == 0){
            dateChar = dateGuess[1];
            dateInt = (int)char.GetNumericValue(dateChar);
        }

        //If input is 2 digits 
        monthInt = int.Parse(monthGuess);
        dateInt = int.Parse(dateGuess);

        for(int i = 0; i < numberOfPeople; i++){
            if(monthInt == People[i].month){
                correctMonth = true;
                if(dateInt == People[i].date){
                    correctDate = true;
                    if(correctMonth && correctDate){
                        Debug.Log("Correct Guess!");
                    }
                }
            }

            Debug.Log("Wrong Guess!");

        }
    }

}
