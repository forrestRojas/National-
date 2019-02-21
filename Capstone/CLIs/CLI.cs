using Capstone.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Capstone.CLIs
{
    /// <summary>
    /// Represents a CLI
    /// </summary>
    public abstract class CLI
    {
        /// <summary>
        /// This continually prompts the user until they enter a valid string (1 or more characters).
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <returns>The console input as a string.</returns>
        protected string GetString(string message)
        {
            string userInput = String.Empty;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= 2;
                }
                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (String.IsNullOrEmpty(userInput));

            return userInput;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid integer.
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <returns>The console input as a integer.</returns>
        protected int GetInteger(string message)
        {
            string userInput = String.Empty;
            int intValue = 0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= 2;
                }
                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!int.TryParse(userInput, out intValue));

            return intValue;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid double.
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <returns>The console input as a double.</returns>
        protected double GetDouble(string message)
        {
            string userInput = String.Empty;
            double doubleValue = 0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= 2;
                }
                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!double.TryParse(userInput, out doubleValue));

            return doubleValue;
        }

        /// <summary>
        /// This continually prompts the user until they enter a valid bool.
        /// </summary>
        /// <param name="message">A console message to prompt the user for an input.</param>
        /// <returns>The console input as a bool.</returns>
        protected bool GetBool(string message)
        {
            string userInput = String.Empty;
            bool boolValue = false;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.CursorTop -= 2;
                }
                Console.Write(message.Trim(' ') + ' ');
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!bool.TryParse(userInput, out boolValue));

            return boolValue;
        }

        /// <summary>
        /// Writes a line relative to the console cursor's current postion, then returns to the original line.
        /// </summary>
        /// <remarks>This methoed expects that you are statring at the last line written to the console.</remarks>
        /// <param name="message">The line to be displayed.</param>
        /// <param name="rowsAway">The number of rows away from the current line (positive goes up, negitive goes down, zero is the current line).</param>
        protected void InsertLineRelative(string message, int rowsAway)
        {
            this.InsertLineRelative(message, rowsAway, false);
        }

        /// <summary>
        /// Writes a line relative to the console cursor's current postion, then returns to the original line.
        /// </summary>
        /// <remarks>This methoed expects that you are statring at the last line written to the console.</remarks>
        /// <param name="message">The line to be displayed.</param>
        /// <param name="rowsAway">The number of rows away from the current line (positive goes up, negitive goes down, zero is the current line).</param>
        /// <param name="overwrite">Will overwrite the line if TRUE</param>
        protected void InsertLineRelative(string message, int rowsAway, bool overwrite)
        {
            // Remembers the cursor original coordinates
            int y = Console.CursorTop;
            int x = Console.CursorLeft;
            int insertLine = y - rowsAway;

            // Inserts above the current line
            if (insertLine < 0)
            {
                // prevents the insertLine from going beyond the TOP of the buffer
                insertLine = 0;
            }
            if (rowsAway >= 0 && overwrite) // overwrite 
            {
                Console.SetCursorPosition(0, insertLine);
                ClearLine();
                Console.SetCursorPosition(0, insertLine);
                Console.Write(message);
                Console.SetCursorPosition(x, y);
            }
            else if (rowsAway >= 0 && !overwrite) // Dont overwrite
            {
                Console.MoveBufferArea(0, insertLine, (Console.BufferWidth - 1), (rowsAway + 1), 0, (insertLine + 1));
                Console.SetCursorPosition(0, insertLine);
                Console.Write(message);
                Console.SetCursorPosition(x, (y + 1));
            }

            // Inserts below the current line
            if ((rowsAway * -1) >= Console.BufferHeight)
            {
                // prevents the insertLine from going beyond the BOTTOM of the buffer
                rowsAway = Console.BufferHeight - 1;
                insertLine = y - rowsAway;
            }
            if (rowsAway < 0 && overwrite) // overwrite
            {
                Console.SetCursorPosition(0, insertLine);
                ClearLine();
                Console.SetCursorPosition(0, insertLine);
                Console.Write(message);
                Console.SetCursorPosition(x, y);
            }
            else if (rowsAway < 0 && !overwrite) // Dont overwrite
            {
                Console.SetCursorPosition(0, insertLine);
                Console.MoveBufferArea(0, insertLine, (Console.BufferWidth - 1), (Console.BufferHeight - 1 - insertLine), 0, (insertLine + 1));
                Console.Write(message);
                Console.SetCursorPosition(x, y);
            }
        }

        /// <summary>
        /// Clears the current Console Line
        /// </summary>
        protected static void ClearLine()
        {
            Console.Write(new string(' ', (Console.BufferWidth - Console.CursorLeft)));
        }

        public static void WordWrap(string paragraph)
        {
            paragraph = new Regex(@" {2,}").Replace(paragraph.Trim(), @" ");
            var left = Console.CursorLeft; var top = Console.CursorTop; var lines = new List<string>();
            for (var i = 0; paragraph.Length > 0; i++)
            {
                lines.Add(paragraph.Substring(0, Math.Min(Console.WindowWidth, paragraph.Length)));
                var length = lines[i].LastIndexOf(" ", StringComparison.Ordinal);
                if (length > 0) lines[i] = lines[i].Remove(length);
                paragraph = paragraph.Substring(Math.Min(lines[i].Length + 1, paragraph.Length));
                Console.SetCursorPosition(left, top + i); Console.WriteLine(lines[i]);
            }
        }

        //(leading and trailing spaces will be trimed)

        /// <summary>
        /// An abstract method that runs a menu.
        /// </summary>
        public abstract void Run();      
    }
}

