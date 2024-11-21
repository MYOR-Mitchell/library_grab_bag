using System.Text.RegularExpressions;


namespace LibraryRefresh.Library
{
    public class LibraryBRB
    {
        //PARSERS

            //Parse input for int
            public bool ParseInt(string selection, out int validSelection)
            {
                return int.TryParse(selection, out validSelection);
            }

            //Parse input for Datime
            public bool ParseDateTime(string hireDate, out DateTime validHireDate, string format = "yyyy/MM/dd")
            {
                return DateTime.TryParseExact(hireDate, format, null, System.Globalization.DateTimeStyles.None, out validHireDate);
            }

        //RANGE CHECKS

            //Check if int range above 0 and below/equal to max range
            public bool CheckIntRange(int checkInt, int maxRange)
            {
                return checkInt > 0 && checkInt <= maxRange;
            }

        //INPUT VALIDATIONS

            //Uses methods ParseInt && CheckIntRange to confirm user selection is both a valid input && within range of 0 - maxRange.
            public bool NumericSelection(string input, int maxRange, out int validSelection)
            {
                return ParseInt(input, out validSelection) && CheckIntRange(validSelection, maxRange);
            }

            /* Checks if a single name input is valid (e.g., first name or last name).
                 * - Not be null or empty.
                 * - Contain only word characters.
                 * - Not contain digits or whitespace.
             */

            public bool IsValidName(string input)
            {
                return !string.IsNullOrEmpty(input) && !Regex.IsMatch(input, @"[^\w]|[\d\s]");
            }

        //STRING ALTERATIONS

            //Make string all uppercase
            public string AllUppercase(string input)
            {
                return input.ToUpper();
            }

            //Make string all lowercase
            public string AllLowercase(string input)
            {
                return input.ToLower();
            }

        //DATA CALCULATIONS

            //Calculate the duration from a given start date to now - Example: Time employed
            public TimeSpan CalculateTimeInvolved(DateTime startDate)
            {
                return DateTime.Now - startDate;
            }

        //GENERATORS

            //Generate random number within provided ranges
            public int GenerateNumber(int minRange, int maxRange)
            {
                Random random = new Random(); //Come back to this and avoid reseeding.
                                              //Ideas: remove this line and define randon as private
                                              //private readonly Random random = new Random();  
                                              //Use static, but I don't like static.. lol
                return random.Next(minRange, maxRange + 1);
            }

        //LIST,ARRAY, ENUMERABLE...

            //DISPLAYS

                    //Use foreach to display a set of data
                    public IEnumerable<T> DisplaySet<T>(IEnumerable<T> set)
                    {
                        foreach (var item in set)
                        {
                            Console.WriteLine(item);
                        }
                        return set;
                    }

            //COMPARE

                //Compare two collections for any matches (case-sensitive)
                public IEnumerable<T> CheckMatches<T>(IEnumerable<T> setOne, IEnumerable<T> setTwo)
                {
                    var Matches = setOne.Intersect(setTwo).ToList(); //Come back to this and make it so it return the passed in type. Not always list.
                    return Matches;
                }

                // Compare two collections for any matches (case-insensitive)
                public IEnumerable<string> CsCheckMatches(IEnumerable<string> setOne, IEnumerable<string> setTwo)
                {
                    return setOne.Intersect(setTwo, StringComparer.OrdinalIgnoreCase);
                }

            //VALIDATE

                //check if all items in collection are strings
                public bool IsStringCollection<T>(IEnumerable<T> collection)
                {
                    return collection.All(item => item is string);
                }

                //check if all items in collection are int
                public bool IsIntCollection<T>(IEnumerable<T> collection)
                {
                    return collection.All(item => item is int);
                }
    }
}
