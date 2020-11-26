using System;
using System.Collections.Generic;
using System.Linq;

namespace GreetingKata
{
    public class Program
    {
        private string _latestGreetingsList;
        private static Dictionary<int, string> _bookmarkGreetings = new Dictionary<int, string>();

        static void Main(string[] args)
        {
        }

        //Requirement 1

        //Write a method greet(name) that interpolates name in a simple greeting.
        //For example, when name is "Bob", the method should return a string "Hello, Bob.".

        //Requirement 3

        //Handle shouting.When name is all uppercase, 
        //then the method should shout back to the user.
        //For example, when name is "JERRY" then the method should return the string "HELLO JERRY!"

        public string SayGreeting(string name)
        {
            if (name == "repeat")
            {
                return _latestGreetingsList;
            }

            if (name.All(char.IsUpper))
            {
                return "HELLO " + name + "!";
            }

            return "Hello " + name + ".";
        }

        //Requirement 2

        //Handle nulls by introducing a stand-in. 
        //For example, when name is null, then the method should return the string "Hello, my friend."

        public string SayGreeting()
        {
            return "Hello, my friend.";
        }

        //Requirement 4

        //Handle two names of input.When name is an array of two names(or, in languages that support it, varargs or a splat),
        //then both names should be printed.
        //For example, when name is ["Jill", "Jane"],
        //then the method should return the string "Hello, Jill and Jane."

        // Requirement 5

        // Handle an arbitrary number of names as input.
        // When name represents more than two names, 
        // separate them with commas and close with an Oxford comma and "and". 
        // For example, when name is ["Amy", "Brian", "Charlotte"], 
        // then the method should return the string "Hello, Amy, Brian, and Charlotte."

        //Requirement 6

        //Allow mixing of normal and shouted names by separating the response into two greetings.
        //For example, when name is ["Amy", "BRIAN", "Charlotte"],
        //then the method should return the string "Hello, Amy and Charlotte. AND HELLO BRIAN!"

        //Requirement 7

        //If any entries in name are a string containing a comma, 
        //split it as its own input.For example, 
        //when name is ["Bob", "Charlie, Dianne"], 
        //then the method should return the string "Hello, Bob, Charlie, and Dianne.".

        //Requirement DavidA

        //AC: Om jag har hälsat på[”a”, ”b”, ”c”]. När jag skickar in ”repeat” 
        //så repeteras den senaste hälsningen och svaret blir samma som förra gången.

        //Requirement DavidB

        //AC: Om man skickar in (1, [”a”, ”b”, ”c”]) så läggs den till i favoriter på plats 1.
        

        public string SayGreeting( string[] array, int bookmarkIndex=0)
        {
            if (array.Length < 2)
                throw new Exception("Insufficient number of names");

            var listOfNames = ConvertToList(array);

            var lowerCaseNames = GetLowerCaseNames(listOfNames);
            if (lowerCaseNames.Count == 0)
                throw new Exception("Insufficient number of lower case names");

            var upperCaseNames = GetUpperCaseNames(listOfNames);

            var stringResult = GetGreetingLowerCaseString(lowerCaseNames);
            stringResult += AddGreetingUpperCaseNames(upperCaseNames);

            _latestGreetingsList  =  stringResult;

            if  (bookmarkIndex > 0)
                _bookmarkGreetings.Add(bookmarkIndex, stringResult);

            return stringResult;
        }

        //Requirement DavidC

        //AC: Om vi har[”a”, ”b”] sparat på plats ett, så om skickar in siffran 1, så hälsas a och b på.

        public string GetFavoriteGreetingByIndex(int index)
        {
            if (index <= 0)
                throw new Exception("Favorites is a number larger than 0");

            string greeting;            
            _bookmarkGreetings.TryGetValue(index,  out greeting);
            return greeting; 
        }
        private string AddGreetingUpperCaseNames(List<string> upperCaseNames)
        {
            var stringResult = string.Empty;
            if (upperCaseNames.Count > 0)
            {
                stringResult += $" AND HELLO {upperCaseNames[0]}";
                for (int i = 1; i < upperCaseNames.Count; i++)
                {
                    stringResult += ", " + upperCaseNames[i];
                }
                stringResult += "!";
            }
            return stringResult;
        }

        private string GetGreetingLowerCaseString(List<string> lowerCaseNames)
        {
            var stringResult = $"Hello, {lowerCaseNames[0]}";
            if (lowerCaseNames.Count > 2)
            {
                for (int i = 1; i < lowerCaseNames.Count - 1; i++)
                {
                    stringResult += ", " + lowerCaseNames[i];
                }
            }
            if (lowerCaseNames.Count > 1)
            {
                stringResult += " and " + lowerCaseNames[lowerCaseNames.Count - 1];
            }
            stringResult += ".";

            return stringResult;
        }

        private List<string> GetLowerCaseNames(List<string> listOfNames)
        {
            var listOfLowerCaseNames = new List<string>();
            for (int i = 0; i < listOfNames.Count; i++)
            {
                if (!listOfNames[i].All(char.IsUpper))
                {
                    listOfLowerCaseNames.Add(listOfNames[i]);
                }
            }

            return listOfLowerCaseNames;
        }

        private List<string> GetUpperCaseNames(List<string> listOfNames)
        {
            var listOfUpperCaseNames = new List<string>();
            for (int i = 0; i < listOfNames.Count; i++)
            {
                if (listOfNames[i].All(char.IsUpper))
                {
                    listOfUpperCaseNames.Add(listOfNames[i]);
                }
            }
            return listOfUpperCaseNames;
        }

        private List<string> ConvertToList(string[] array)
        {
            var listOfNames = new List<string> { };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains(","))
                {
                    var indexOfComma = array[i].IndexOf(",");
                    Console.WriteLine(indexOfComma);
                    Console.WriteLine(array[i].Length);
                    listOfNames.Add(array[i].Substring(0, indexOfComma));
                    listOfNames.Add(array[i].Substring(indexOfComma + 2, array[i].Length - indexOfComma - 2));

                    continue;
                }
                listOfNames.Add(array[i]);
            }
            return listOfNames;
        }
    }
}
