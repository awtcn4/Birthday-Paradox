using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Person{

    public int personNumber;
    public int month;
    public int date;

    public Person(int personNumber, int month){

        this.personNumber = personNumber;
        this.month = month;

        switch (month)
        {
            case 1:
                this.date = Random.Range(1,31);
                break;
            case 2:
                this.date = Random.Range(1,28);
                break; 
            case 3:
                this.date = Random.Range(1,31);
                break;
            case 4:
                this.date = Random.Range(1,30);
                break;
            case 5:
                this.date = Random.Range(1,31);
                break;
            case 6:
                this.date = Random.Range(1,30);
                break;
            case 7:
                this.date = Random.Range(1,31);
                break;
            case 8:
                this.date = Random.Range(1,31);
                break;
            case 9:
                this.date = Random.Range(1,30);
                break;
            case 10:
                this.date = Random.Range(1,31);
                break;
            case 11:
                this.date = Random.Range(1,30);
                break;
            case 12:
                this.date = Random.Range(1,31);
                break;
            default:
                this.date = Random.Range(1,31);
                break;
        }
    }

    //To test and make sure everything worked... output to log
    public string GetBirthday(){
        string birthday = " ";
        birthday += "Number: " + this.personNumber + " ";
        birthday += "Month: " + this.month + " ";
        birthday += "Date: " + this.date + " ";
        return birthday;
    }

}
