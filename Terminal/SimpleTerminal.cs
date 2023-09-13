using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    class SimpleTerminal
    {
        private List<string> lines;
        private int currentLine;
        private int cursorPosition;

        public SimpleTerminal()
        {
            lines = new List<string>();
            currentLine = 0;
            cursorPosition = 0;
            lines.Add("");
        }

        public void ProcessInput(string input)
        {
            foreach (char c in input)
            {
                switch (c)
                {
                    case 'L':
                        MoveCursorLeft();
                        break;
                    case 'R':
                        MoveCursorRight();
                        break;
                    case 'U':
                        MoveCursorUp();
                        break;
                    case 'D':
                        MoveCursorDown();
                        break;
                    case 'B':
                        MoveCursorToBeginning();
                        break;
                    case 'E':
                        MoveCursorToEnd();
                        break;
                    case 'N':
                        InsertNewLine();
                        break;
                    default:
                        InsertCharacter(c);
                        break;
                }
            }
        }

        public void PrintResult()
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("-");
        }

        private void MoveCursorLeft()
        {
            if (cursorPosition > 0)
            {
                cursorPosition--;
            }
        }

        private void MoveCursorRight()
        {
            if (cursorPosition < lines[currentLine].Length)
            {
                cursorPosition++;
            }
        }

        private void MoveCursorUp()
        {
            if (currentLine > 0)
            {
                currentLine--;
                if (cursorPosition > lines[currentLine].Length)
                {
                    cursorPosition = lines[currentLine].Length;
                }
            }
        }

        private void MoveCursorDown()
        {
            if (currentLine < lines.Count - 1)
            {
                currentLine++;
                if (cursorPosition > lines[currentLine].Length)
                {
                    cursorPosition = lines[currentLine].Length;
                }
            }
        }

        private void MoveCursorToBeginning()
        {
            cursorPosition = 0;
        }

        private void MoveCursorToEnd()
        {
            cursorPosition = lines[currentLine].Length;
        }

        private void InsertNewLine()
        {
            string current = lines[currentLine];
            string remainder = current.Substring(cursorPosition);
            lines[currentLine] = current.Substring(0, cursorPosition);
            lines.Insert(currentLine + 1, remainder);
            currentLine++;
            cursorPosition = 0;
        }

        private void InsertCharacter(char c)
        {
            string current = lines[currentLine];
            lines[currentLine] = current.Insert(cursorPosition, c.ToString());
            cursorPosition++;
        }
    }
}
