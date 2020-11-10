using System;
using System.Collections.Generic;
namespace Games
{
    public enum RoomType
    {
        None,Trap,Enemy,Treasure
    }
    
    class Labirint
    {
        public static Random rand = new Random();
        public struct CELL
        {
            public int x;
            public int y;
            public string type;
            public bool vision;
            public int Way_count;
            public RoomType Room_type;
        }
        private static int Get_count(CELL[,] arr, int x, int y)
        {
            int count = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if ((i % 2 != 0) && (j % 2 != 0) && (i < x - 1) && (j < y - 1) && (!arr[i, j].vision))
                    {count++;}
                }
            }// :c
            return count;
        }
        // список соседних непосещеных клеток через одну
        public static List<CELL> GetCellNeighbours(CELL[,] arr, CELL TargetCell, int dlin, int shirina)
        {
            List<CELL> list_cell = new List<CELL>();
            if (TargetCell.x + 2 < dlin)
            {       //ячейка и не посещеная
                if (arr[TargetCell.x + 2, TargetCell.y].type == " " && !arr[TargetCell.x + 2, TargetCell.y].vision)
                {list_cell.Add(arr[TargetCell.x + 2, TargetCell.y]);}
            }
            if (TargetCell.x - 2 > 0)
            {
                if (arr[TargetCell.x - 2, TargetCell.y].type == " " && !arr[TargetCell.x - 2, TargetCell.y].vision)
                {list_cell.Add(arr[TargetCell.x - 2, TargetCell.y]);}
            }
            if (TargetCell.y + 2 < shirina)
            {
                if (arr[TargetCell.x, TargetCell.y + 2].type == " " && !arr[TargetCell.x, TargetCell.y + 2].vision)
                {
                    list_cell.Add(arr[TargetCell.x, TargetCell.y + 2]);
                }
            }
            if (TargetCell.y - 2 > 0)
            {
                if (arr[TargetCell.x, TargetCell.y - 2].type == " " && !arr[TargetCell.x, TargetCell.y - 2].vision)
                {
                    list_cell.Add(arr[TargetCell.x, TargetCell.y - 2]);
                }
            }
            return list_cell;
        }
        // список соседних клеток
        public static List<CELL> GetNeighbours(CELL[,] arr, CELL TargetCell, int dlin, int shirina)
        {
            List<CELL> list_cell = new List<CELL>();
            if (TargetCell.x + 1 < dlin)
            {        
                if (arr[TargetCell.x + 1, TargetCell.y].type == " ")
                {
                    list_cell.Add(arr[TargetCell.x + 1, TargetCell.y]);
                }
            }
            if (TargetCell.x - 1 > 0)
            {
                if (arr[TargetCell.x - 1, TargetCell.y].type == " ")
                {
                    list_cell.Add(arr[TargetCell.x - 1, TargetCell.y]);
                }
            }
            if (TargetCell.y + 1 < shirina)
            {
                if (arr[TargetCell.x, TargetCell.y + 1].type == " ")
                {
                    list_cell.Add(arr[TargetCell.x, TargetCell.y + 1]);
                }
            }
            if (TargetCell.y - 1 > 0)
            {
                if (arr[TargetCell.x, TargetCell.y - 1].type == " ")
                {
                    list_cell.Add(arr[TargetCell.x, TargetCell.y - 1]);
                }
            }
            return list_cell;
        }
        // список соседних непосещеных клеток
        public static List<CELL> GetCellNeighbours_with_step(CELL[,] arr, CELL TargetCell, int dlin, int shirina)
        {
            List<CELL> list_cell = new List<CELL>();
            if (TargetCell.x + 1 < dlin)
            {       //ячейка и не посещеная
                if (arr[TargetCell.x + 1, TargetCell.y].type == " " && !arr[TargetCell.x + 1, TargetCell.y].vision)
                {
                    list_cell.Add(arr[TargetCell.x + 1, TargetCell.y]);
                }
            }
            if (TargetCell.x - 1 > 0)
            {
                if (arr[TargetCell.x - 1, TargetCell.y].type == " " && !arr[TargetCell.x - 1, TargetCell.y].vision)
                {
                    list_cell.Add(arr[TargetCell.x - 1, TargetCell.y]);
                }
            }
            if (TargetCell.y + 1 < shirina)
            {
                if (arr[TargetCell.x, TargetCell.y + 1].type == " " && !arr[TargetCell.x, TargetCell.y + 1].vision)
                {
                    list_cell.Add(arr[TargetCell.x, TargetCell.y + 1]);
                }
            }
            if (TargetCell.y - 1 > 0)
            {
                if (arr[TargetCell.x, TargetCell.y - 1].type == " " && !arr[TargetCell.x, TargetCell.y - 1].vision)
                {
                    list_cell.Add(arr[TargetCell.x, TargetCell.y - 1]);
                }
            }
            return list_cell;
        }
        /// убрать стену
        private static void RemoveWall(CELL c1, CELL c2, CELL[,] arr)
        {
            int new_x;
            if (c1.x == c2.x)
            {new_x = c1.x;}
            else
            {new_x = (c1.x + c2.x) / 2;}
            int new_y;
            if (c1.y == c2.y)
            {new_y = c1.y;}
            else
            {new_y = (c1.y + c2.y) / 2;}
            arr[new_x, new_y].type = " ";
        }
        public static RoomType SetRandomRoomType(CELL TargetCell)
        {
            int count = rand.Next(0, 3);
            switch (count)
            {                    
                case 0:
                    TargetCell.Room_type = RoomType.Trap;
                    break;
                case 1:
                    TargetCell.Room_type = RoomType.Treasure;
                    //так я открыла комнаты с сокровищем
                    break;
                case 2:
                    TargetCell.Room_type = RoomType.Enemy;
                    // а так закрыла с врагами
                    break;
                default:
                    TargetCell.Room_type = RoomType.None;
                    break;
            }
            return TargetCell.Room_type;
        }
        //Создаем новый лабиринт 
        public static CELL[,] Get_New_labirint(int height, int width)
        {// да

            CELL[,] cellMaze = new CELL[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if((( i % 2 != 0) && (j % 2 != 0)) && ((i < height - 1) && (j < width - 1)))
                    {//room
                        cellMaze[i, j].x = i;
                        cellMaze[i, j].y = j;
                        cellMaze[i, j].type = " ";
                        cellMaze[i, j].vision = false;
                        cellMaze[i,j].Room_type = SetRandomRoomType(cellMaze[i, j]);
                    }
                    else
                    {//стена
                        cellMaze[i, j].x = i;
                        cellMaze[i, j].y = j;
                        cellMaze[i, j].type = "0";
                        cellMaze[i, j].vision = false;
                    }
                }
            }
            CELL Curent_cell = cellMaze[1, 1];
            Stack<CELL> Do_you_know_de_way = new Stack<CELL>();
            Random rand = new Random();
            do
            {
                List<CELL> list_cell = GetCellNeighbours(cellMaze, Curent_cell, height, width);
                if (list_cell.Count != 0)
                {
                    int poryadok = rand.Next(list_cell.Count);
                    CELL NeighbourCell = cellMaze[list_cell[poryadok].x, list_cell[poryadok].y];
                    RemoveWall(Curent_cell, NeighbourCell, cellMaze);
                    Do_you_know_de_way.Push(Curent_cell);
                    cellMaze[Curent_cell.x, Curent_cell.y].vision = true;
                    cellMaze[Curent_cell.x, Curent_cell.y].type = " ";
                    Curent_cell = cellMaze[NeighbourCell.x, NeighbourCell.y];
                }
                else
                {
                    if (Do_you_know_de_way.Count != 0)
                    {
                        cellMaze[Curent_cell.x, Curent_cell.y].vision = true;
                        CELL last_cell = Do_you_know_de_way.Pop();
                        Curent_cell = cellMaze[last_cell.x, last_cell.y];
                    }
                }
            }
            while (Get_count(cellMaze, height, width) != 0);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cellMaze[i, j].vision = false;
                }
            }
            return cellMaze;
        }
        public static CELL GetLongWay(CELL[,] arr, int dlin, int shirina)
        {
            Stack<CELL> Way = new Stack<CELL>();
            for (int i = 0; i < dlin; i++)
            {
                for (int j = 0; j < shirina; j++)
                {
                    if (arr[i, j].type == " ")
                    {arr[i, j].vision = false;}
                }
            }
            Random rand = new Random();
            CELL startCell = arr[1, 1];
            CELL currentCell = startCell;
            Way.Push(currentCell);
            currentCell.Way_count = 0;
            do
            {
                List<CELL> list_cell = GetCellNeighbours_with_step(arr, currentCell, dlin, shirina);
                if (list_cell.Count != 0)
                {
                    int poryadok = rand.Next(list_cell.Count);
                    CELL NeighbourCell = arr[list_cell[poryadok].x, list_cell[poryadok].y];
                    Way.Push(currentCell);
                    arr[currentCell.x, currentCell.y].vision = true;
                    arr[currentCell.x, currentCell.y].type = " ";
                    arr[NeighbourCell.x, NeighbourCell.y].Way_count = arr[currentCell.x,currentCell.y].Way_count + 1;
                    currentCell = arr[NeighbourCell.x, NeighbourCell.y];
                }
                else
                {
                    if (Way.Count != 0)
                    {
                        arr[currentCell.x, currentCell.y].vision = true;
                        CELL last_cell = Way.Pop();
                        currentCell = arr[last_cell.x, last_cell.y];
                        currentCell.Way_count -= 1; 
                    }
                }
            } while (Get_count(arr,dlin,shirina)!=0);
            int max_value = 0;
            CELL max_value_cell = new CELL();
            for (int i = 0; i < dlin; i++)
            {
                for (int j = 0; j < shirina; j++)
                {
                    if (max_value < arr[i, j].Way_count)
                    {
                        max_value = arr[i, j].Way_count;
                        max_value_cell = arr[i, j];
                    }
                }
            }
            return max_value_cell;
        }
    }
}
