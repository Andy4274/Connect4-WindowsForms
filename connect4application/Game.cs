using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect4application
{
    class Game
    {
        //properties
        char[,] map;         //holds the data on who has moved where
        int move_counter;   //max is (6*7) 42
        bool win;           //flag to indicate a win has been achieved

        public const char player = 'p';     //for use in map
        public const char computer = 'c';   //for use in map
        public const char empty = ' ';      //for use in map

        //methods
        //constructor
        public Game()
        {
            map = new char[7,6];
            for(int i = 0; i < 7; i++)
            {
                for (int j=0;j<6; j++)
                {
                    map[i, j] = empty;
                }
            }
            move_counter = 0;
            win = false;
        }
        public char getMap(int column, int row)
        {
            return map[column, row];
        }
        public bool getWin()
        {
            return win;
        }

        public bool checkColumn(int c)      //checking if column is full.  true == not full
        {
            if (map[c, 5] == empty)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool move(int column, char c)
        {
            //assign a square of the map to the player indicated by c
            //returns true on success.  
            //check column
            if (checkColumn(column))
            {
                //find top of column
                int j = 0;
                for (; j < 6;j++)
                {
                    if (map[column, j] == empty)
                    {
                        break;
                    }
                }
                if (j == 6)
                {
                    return false;   //just in case the column was full despite checkColumn returning true.
                }
                //assign square
                switch (c)
                {
                    case player:
                    case computer:
                        map[column, j] = c;
                        checkForWin(column, j);
                        return true;
                        break;
                    default:
                        return false;
                        break;
                }            
            } else
            {
                return false;
            }
            
        }

        public void checkForWin(int column, int row)
        {
            //scans for matching squares in each direction, counts them.  if 4 or more, sets win to true

            //get char at the square we are checking
            char match = map[column, row];
            //scan up-down
            int length = 0;
            for (int i=-3;i<4;i++)  //go from row-3 to row+3.  counts the square [column,row] where i=0.
            {
                if (((row + i) >= 0) && ((row + i) < 6)) //if this is a valid square
                {
                    if (map[column, row + i] == match)
                    {
                        length++;
                    }
                }
            }
            if (length > 3)
            {
                win = true;
            }
            //scan left-right
            if (!win)       //if we haven't found a win yet
            {
                length = 0;
                for (int i = -3; i < 4; i++)
                {
                    if (((column + i) >= 0) && ((column + i) < 7))
                    {
                        if (map[column + i, row] == match)
                        {
                            length++;
                        }
                    }
                }
                if (length > 3)
                {
                    win = true;
                }
            }
            //scan up-right--down-left
            if (!win)
            {
                length = 0;
                for (int i= -3;i< 4;i++)
                {
                    if (((column+i)>=0)&&(column+i)<7)
                    {
                        if (((row+i)>=0)&&(row+i)<6)
                        {
                            if (map[column + i, row + i] == match)
                            {
                                length++;
                            }
                        }
                    }
                }
                if (length > 3)
                {
                    win = true;
                }
            }
            //scan up-left--down-right
            if (!win)
            {
                length = 0;
                for (int i = -3; i < 4; i++)
                {
                    if (((column + i) >= 0) && (column + i) < 7)
                    {
                        if (((row - i) >= 0) && (row - i) < 6)
                        {
                            if (map[column + i, row - i] == match)  //- (-i) > +i ... - (-3) = +3
                            {
                                length++;
                            }
                        }
                    }
                }
                if (length > 3)
                {
                    win = true;
                }
            }
        }

        private int checkMove(int column, char match)
        {
            int length = 0;
            int max = length;
            //char match = computer;
            int row = 0;
            for (; row < 6; row++)
            {
                if (map[column, row] == empty)
                {
                    break;
                }
            }
            if (row < 0 || row >= 6)
            {
                return 0;       //can't move here.
            }
            //scan up-down
            length = 1;     //set to one to count the square itself, which is not a match yet.
            for (int i = -3; i < 4; i++)  //go from row-3 to row+3.  counts the square [column,row] where i=0.
            {
                if (((row + i) >= 0) && ((row + i) < 6)) //if this is a valid square
                {
                    if (map[column, row + i] == match)
                    {
                        length++;
                    }
                }
            }
            if (length > max)
            {
                max = length;
            }
            //scan right-left
            length = 1;
                for (int i = -3; i < 4; i++)
                {
                    if (((column + i) >= 0) && ((column + i) < 7))
                    {
                        if (map[column + i, row] == match)
                        {
                            length++;
                        }
                    }
                }
            if (length > max)
            {
                max = length;
            }
            //scan up-right--down-left
                length = 1;
                for (int i = -3; i < 4; i++)
                {
                    if (((column + i) >= 0) && (column + i) < 7)
                    {
                        if (((row + i) >= 0) && (row + i) < 6)
                        {
                            if (map[column + i, row + i] == match)
                            {
                                length++;
                            }
                        }
                    }
                }
            if (length > max)
            {
                max = length;
            }
            //scan up-left--down-right
            
                length = 1;
                for (int i = -3; i < 4; i++)
                {
                    if (((column + i) >= 0) && (column + i) < 7)
                    {
                        if (((row - i) >= 0) && (row - i) < 6)
                        {
                            if (map[column + i, row - i] == match)  //- (-i) > +i ... - (-3) = +3
                            {
                                length++;
                            }
                        }
                    }
                }
            if (length > max)
            {
                max = length;
            }
            return max;
        }

        public int getCompMove()
        {
            int col=0;
            int len=0;
            int[] scores = { 0, 0, 0, 0, 0, 0, 0};
            for (int i = 0; i < 7; i++)
            {
                len = checkMove(i, computer);
                switch (len)
                {
                    case 0:
                        break;
                    case 1:
                        scores[i] += 25;
                        break;
                    case 2:
                        scores[i] += 50;
                        break;
                    case 3:
                        scores[i] += 100;
                        break;
                    case 4:
                    default:
                        scores[i] += 1000;
                        break;
                }
                len = checkMove(i, player);
                switch (len)
                {
                    case 0:
                        break;
                    case 1:
                        scores[i] += 12;
                        break;
                    case 2:
                        scores[i] += 25;
                        break;
                    case 3:
                        scores[i] += 80;
                        break;
                    case 4:
                    default:
                        scores[i] += 1000;
                        break;
                }
            }
            int count = 0;
            int max = 0;
            int choice = 0;
            int[] choices = { 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 7; i++)
            {
                if (scores[i] > max)
                {
                    max = scores[i];
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (scores[i] == max)
                {                
                    choices[count++]=i;
                }
            }
            if (count > 1)
            {
                Random r = new Random();
                double d = r.NextDouble();
                choice = ((int)(d * 100)) % count;                
            }

            return choices[choice];

        }
    }
}
