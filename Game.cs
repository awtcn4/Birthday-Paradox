using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour
{

    //initialize variables
    [SerializeField]
    private InputField input;

    [SerializeField]
    private InputField guessInput;

    [SerializeField]
    private InputField wager;

    [SerializeField]
    private Text incorrectInput;

    [SerializeField]
    private Text gameText;

    [SerializeField]
    private Text cashText;

    [SerializeField]
    private Text enterGuessBet;
    
    [SerializeField]
    private Text betSubmit;
    
    [SerializeField]
    private Text invalidBet;

    [SerializeField]
    private Text guessSubmit;

    [SerializeField]
    private Text invalidGuess;

    bool validInput, correctMonth, correctDate, validMonth, ValidDate, ValidSlash, guessEntered, betEntered;

    int numberOfPeople, cash, playerAttempts, betAmount;

    Person[] People;

    // Start is called before the first frame update
    void Start()
    {
        //set cash
        cash = 500;
        cashText.text = cash.ToString();

        //set texts
        enterGuessBet.text = "";
        betSubmit.text = "";
        invalidBet.text = "";
        guessSubmit.text = "";
        invalidGuess.text = "";

        //Set fields to not visible
        incorrectInput.enabled = false;
        input.enabled = false;
        guessInput.enabled = false;
        wager.enabled = false;
        guessInput.enabled = true;

        //set bool values
        guessEntered = false;
        betEntered = false;

        //How Many People
        numberOfPeople = Random.Range(1,200);

        //set Game text
        gameText.text = "There are " + numberOfPeople + " people in the room. How many guesses will it take for you to guess a birthday?";

        //Create People
        People = new Person[numberOfPeople];
        
        //populate
        for(int i = 0; i < numberOfPeople; i++){
            People[i] = new Person(i + 1, Random.Range(1,12));
        }

        //Print the people to the console
        // for(int i = 0; i < numberOfPeople; i++){
        //     Debug.Log(People[i].GetBirthday()); 
        // }
        //TEST CODE ^^^^
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GetGuessInput(int attempts){

        if(guessEntered == true){
            //Change text
        }

        if(guessEntered == false){
            playerAttempts = attempts;
            guessEntered = true;
        }

    }

    public void GetBetInput(int bet){

        if(betEntered == true){
            //Change text
        }

        if(betEntered == false){
            //chnage text
            betAmount = bet;
            betEntered = true;
        }

    }


    //Getting the user-input
    public void GetInput(string guess){

        //create variables for all values of string... month and date 
        string monthGuess, dateGuess, forwardSlash;
        
        //dummy value
        int dummyNumericalValue;

        //Making sure input is valid
        if(guess.Length != 5){
            validInput = false;
            //Debug.Log("Invalid Input!");
            incorrectInput.enabled = true;
            //clear input box
            input.text = "";
        }

        //getting all values of numerals
        monthGuess = guess.Substring(0,2);
        dateGuess = guess.Substring(3);
        forwardSlash = guess.Substring(2,2);
        char forwardSlashChar = forwardSlash[0];

        validMonth = int.TryParse(monthGuess, out dummyNumericalValue);
        ValidDate = int.TryParse(dateGuess, out dummyNumericalValue);

        if(forwardSlashChar == '/'){
            ValidSlash = true;
        }else{
            ValidSlash = false;
        }

        // Debug.Log(validMonth);
        // Debug.Log(ValidDate);
        // Debug.Log(ValidSlash);

        if(!(validMonth && ValidDate && ValidSlash)){
            validInput = false;
            //Debug.Log("Invalid Input!");
            incorrectInput.enabled = true;
            //clear input box
            input.text = "";
        }

        if((validMonth && ValidDate && ValidSlash)){
        playerAttempts++;
        //Send input to be compared
        CompareBirthdayGuess(monthGuess, dateGuess);
        }
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

            //Debug.Log("Wrong Guess!");

        }
    }

}
