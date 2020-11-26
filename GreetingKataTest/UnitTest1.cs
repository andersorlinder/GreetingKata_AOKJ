using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreetingKata;

namespace GreetingKataTest
{
    [TestClass]
    public class ProgramTest
    {
        //Requirement 1

        //Write a method greet(name) that interpolates name in a simple greeting.
        //For example, when name is "Bob", the method should return a string "Hello, Bob.".

        [TestMethod]
        public void SayGreetingCheckStringTest()
        {
            var sut = new Program();
            var actual = sut.SayGreeting("Gösta");
            Assert.AreEqual("Hello Gösta.", actual);
        }


        //Requirement 2

        //Handle nulls by introducing a stand-in. 
        //For example, when name is null, then the method should return the string "Hello, my friend."
        
        [TestMethod]
        public void SayGreetingCheckForNullsTest() 
        {
            var sut=new Program();
            var expected  = "Hello, my friend.";
            var actual = sut.SayGreeting();
            Assert.AreEqual(expected, actual);
        }

        //Requirement 3

        //Handle shouting.When name is all uppercase, 
        //then the method should shout back to the user.
        //For example, when name is "JERRY" then the method should return the string "HELLO JERRY!"

        [TestMethod]
        public void SayGreetingCheckUpperCase()
        {
            var sut = new Program();
            var expected = "HELLO YNGVE!";
            var actual = sut.SayGreeting("YNGVE");
            Assert.AreEqual(expected, actual);
        }


        //Requirement 4

        //Handle two names of input.When name is an array of two names(or, in languages that support it, varargs or a splat),
        //then both names should be printed.
        //For example, when name is ["Jill", "Jane"],
        //then the method should return the string "Hello, Jill and Jane."

        [TestMethod]
        public void SayGreetingArrayOfTwoNamesTest()
        {
            var sut = new Program();
            var namesArray  = new[] {  "Khosro",  "Anders" };
            var actual = sut.SayGreeting(namesArray);
            var expected = "Hello, Khosro and Anders.";
            Assert.AreEqual(actual, expected);
        }

        // Requirement 5

        // Handle an arbitrary number of names as input.
        // When name represents more than two names, 
        // separate them with commas and close with an Oxford comma and "and". 
        // For example, when name is ["Amy", "Brian", "Charlotte"], 
        // then the method should return the string "Hello, Amy, Brian, and Charlotte."

        [TestMethod]
        public void SayGreetingArrayOfAnyNumberOFNamesTest()
        {
            var sut = new Program();
            var namesArray = new[] { "Khosro", "Anders", "David" };
            var actual = sut.SayGreeting(namesArray);
            var expected = "Hello, Khosro, Anders and David.";
            Assert.AreEqual(actual, expected);
        }

        //Requirement 6

        //Allow mixing of normal and shouted names by separating the response into two greetings.
        //For example, when name is ["Amy", "BRIAN", "Charlotte"],
        //then the method should return the string "Hello, Amy and Charlotte. AND HELLO BRIAN!"

        [TestMethod]
        public void SayGreetingArrayOfAnyNumberOFMixedNamesTest()
        {
            var sut = new Program();
            var namesArray = new[] { "Khosro", "ANDERS", "David" };
            var actual = sut.SayGreeting(namesArray);
            var expected = "Hello, Khosro and David. AND HELLO ANDERS!";
            Assert.AreEqual(actual, expected);
        }

        //Requirement 7

        //If any entries in name are a string containing a comma, 
        //split it as its own input.For example, 
        //when name is ["Bob", "Charlie, Dianne"], 
        //then the method should return the string "Hello, Bob, Charlie, and Dianne.".

        [TestMethod]
        public void SayGreetingArrayOfValuesWithManyNames()
        {
            var sut = new Program();
            var namesArray = new string[] { "Khosro", "Anders, David" };
            var actual = sut.SayGreeting(namesArray);
            var expected = "Hello, Khosro, Anders and David.";
            Assert.AreEqual(actual, expected);
        }

        //AC: Om jag har hälsat på[”a”, ”b”, ”c”]. När jag skickar in ”repeat” 
        //så repeteras den senaste hälsningen och svaret blir samma som förra gången.

        [TestMethod]
        public void SayGreetingWithRepeat()
        {
            var sut = new Program();
            var namesArray = new string[] { "Khosro", "Anders, David" };
            var expected = sut.SayGreeting(namesArray);
            var actual = sut.SayGreeting( "repeat" );
            Assert.AreEqual(expected, actual);
        }

        //AC: Om man skickar in (1, [”a”, ”b”, ”c”]) så läggs den till i favoriter på plats 1.
        //AC: Om vi har[”a”, ”b”] sparat på plats ett, så om skickar in siffran 1, så hälsas a och b på.
        

        [TestMethod]
        public void GetFavoriteGreetingByIndex()
        {
            var sut = new Program();
            var namesArray = new string[] { "Khosro", "Anders, David" };
            var expected = sut.SayGreeting(namesArray, 1);
            var actual = sut.GetFavoriteGreetingByIndex(1);

            Assert.AreEqual(expected, actual);
        }

    }
}
