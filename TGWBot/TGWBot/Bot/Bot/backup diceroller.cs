using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParser
{
    public class DiceRoller
    {
        public static int Parse(string phrase)
        {
            // gange, dividere, plus, minus, diceroll, parse som int
            Console.WriteLine($"Parsing phrase: {phrase}");
            if (phrase.Contains("*"))
            {
                var parts = phrase.Split('*');
                string before = parts[0];
                string after = phrase.Substring(before.Length + 1);
                int result1 = Parse(before);
                int result2 = Parse(after);
                return result1 * result2;
            }
            if (phrase.Contains("/"))
            {
                var parts = phrase.Split('/');
                string before = parts[0];
                string after = phrase.Substring(before.Length + 1);
                int result1 = Parse(before);
                int result2 = Parse(after);
                return result1 / result2;
            }
            else if (phrase.Contains("+"))
            {
                var parts = phrase.Split('+');
                string before = parts[0];
                string after = phrase.Substring(before.Length + 1);
                int result1 = Parse(before);
                int result2 = Parse(after);
                return result1 + result2;
            }
            else if (phrase.Contains("-"))
            {
                var parts = phrase.Split('-');
                string before = parts[0];
                string after = phrase.Substring(before.Length + 1);
                int result1 = Parse(before);
                int result2 = Parse(after);
                return result1 - result2;
            }
            else if (phrase.Contains("d"))
            {
                var parts = phrase.Split('d');
                string before = parts[0];
                string after = phrase.Substring(before.Length + 1);
                int numberOfDice = Parse(before);
                int numberOfSides = Parse(after);
                return (new DiceRoll(numberOfDice, numberOfSides)).Total();
            }
            else
            {
                return int.Parse(phrase);
            }
        }
    }
    class DiceRoll
    {
        Random rnd = new Random();
        public List<int> values;
        public DiceRoll(int numberOfDice, int numberOfSides)
        {
            values = new List<int>();
            for (int i = 0; i < numberOfDice; i++)
            {
                int roll = 1 + rnd.Next(numberOfSides);
                Console.WriteLine($"Rolling : {roll}");
                values.Add(roll);
            }
        }
        public override string ToString()
        {
            return string.Join(" ", values);
        }
        public int Total()
        {
            return values.Sum();
        }
        public static int operator +(DiceRoll diceRoll, int other)
        {
            return diceRoll.Total() + other;
        }
        public static int operator +(int other, DiceRoll diceRoll)
        {
            return diceRoll + other;
        }
    }
}