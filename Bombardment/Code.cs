using System;
using System.IO;

class Program
{
  public struct ShipType
  {
    public string Name;
    public int Size;
  }
    const int GridSize = 12;
  const string TrainingGame = "Training.txt";
    private const char Miss = 'm';
    private const char Horizontal = 'h';
    private const char Hit = 'h';
    private const char Empty = '-';
    private const char Vertical = 'v';
    private const char AircraftCarrier = 'A';
    private const char BattleShip = 'B';
    private const char Submarine = 'S';
    private const char Destroyer = 'D';
    private const char PatrolBoat = 'P';

    private static void GetRowColumn(ref int Row, ref int Column)
  {
    
    Console.WriteLine();
    Console.Write("Please enter column: ");
    Column = Convert.ToInt32(Console.ReadLine());
    Console.Write("Please enter row: ");
    Row = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
  }

  private static void MakePlayerMove(ref char[,] Board, ref ShipType[] Ships)
  {
    int Row = 0;
    int Column = 0;
    GetRowColumn(ref Row, ref Column);
    if (Board[Row, Column] == Miss || Board[Row, Column] == Hit)
        { 
      Console.WriteLine("Sorry, you have already shot at the square (" + Column + "," + Row + "). Please try again.");
    }
    else if (Board[Row, Column] == Empty)
    {
      Console.WriteLine("Sorry, (" + Column + "," + Row + ") is a miss.");
      Board[Row, Column] = Miss;
    }
    else
    {
      Console.WriteLine("Hit at (" + Column + "," + Row + ").");
      Board[Row, Column] = Hit;
    }
  }

  private static void SetUpBoard(ref char[,] Board)
  {
    for (int Row = 0; Row < GridSize; Row++)
    {
      for (int Column = 0; Column < GridSize; Column++)
      {
        Board[Row, Column] = Empty;
      }
    }
  }

  private static void LoadGame(string TrainingGame, ref char[,] Board)
  {
    string Line = "";
    StreamReader BoardFile = new StreamReader(TrainingGame);
    for (int Row = 0; Row < GridSize; Row++)
    {
                Line = BoardFile.ReadLine();
                for (int Column = 0; Column < GridSize; Column++)
                {
                    Board[Row, Column] = Line[Column];
                }
    }
    BoardFile.Close();
  }

  private static void PlaceRandomShips(ref char[,] Board, ShipType[] Ships)
  {
    Random RandomNumber = new Random();
    bool Valid;
    char Orientation = ' ';
    int Row = 0;
    int Column = 0;
    int HorV = 0;
    foreach (var Ship in Ships)
    {
      Valid = false;
      while (Valid == false)
      {
        Row = RandomNumber.Next(0, GridSize);
        Column = RandomNumber.Next(0, GridSize);
        HorV = RandomNumber.Next(0, 2);
        if (HorV == 0)
        {
          Orientation = Vertical;
        }
        else
        {
          Orientation = Horizontal;
        }
        Valid = ValidateBoatPosition(Board, Ship, Row, Column, Orientation);
      }
      Console.WriteLine("Computer placing the " + Ship.Name);
      PlaceShip(ref Board, Ship, Row, Column, Orientation);
    }
  }

  private static void PlaceShip(ref char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
  {
    if (Orientation == Vertical)
    {
      for (int Scan = 0; Scan < Ship.Size; Scan++)
      {
        Board[Row + Scan, Column] = Ship.Name[0];
      }
    }
    else if (Orientation == Horizontal)
    {
      for (int Scan = 0; Scan < Ship.Size; Scan++)
      {
        Board[Row, Column + Scan] = Ship.Name[0];
      }
    }
  }

  private static bool ValidateBoatPosition(char[,] Board, ShipType Ship, int Row, int Column, char Orientation)
  {
<<<<<<< HEAD
    if (Orientation == Vertical && Row + Ship.Size > 10)
    {
      return false;
    }
    else if (Orientation == Horizontal && Column + Ship.Size > 10)
=======
    if (Orientation == 'v' && Row + Ship.Size > GridSize)
    {
      return false;
    }
    else if (Orientation == 'h' && Column + Ship.Size > GridSize)
>>>>>>> origin/master
    {
      return false;
    }
    else
    {
      if (Orientation == Vertical)
      {
        for (int Scan = 0; Scan < Ship.Size; Scan++)
        {
          if (Board[Row + Scan, Column] != Empty)
          {
            return false;
          }
        }
      }
      else if (Orientation == Horizontal)
      {
        for (int Scan = 0; Scan < Ship.Size; Scan++)
        {
          if (Board[Row, Column + Scan] != Empty)
          {
            return false;
          }
        }
      }
    }
    return true;
  }

  private static bool CheckWin(char[,] Board)
  {
    for (int Row = 0; Row < GridSize; Row++)
    {
      for (int Column = 0; Column < GridSize; Column++)
      {
        if (Board[Row, Column] == AircraftCarrier || Board[Row, Column] == BattleShip || Board[Row, Column] == Submarine || Board[Row, Column] == Destroyer || Board[Row, Column] == PatrolBoat)
        {
          return false;
        }
      }
    }
    return true;
  }
    
  private static void PrintBoard(char[,] Board)
  {
    Console.WriteLine();
    Console.WriteLine("The board looks like this: ");
    Console.WriteLine();
    Console.Write(" ");
    for (int Column = 0; Column < GridSize; Column++)
    {
      Console.Write(" " + Column + "  ");
    }
    Console.WriteLine();
    for (int Row = 0; Row < GridSize; Row++)
    {
      Console.Write(Row + " ");
      for (int Column = 0; Column < GridSize; Column++)
      {
        if (Board[Row, Column] == Empty)
        {
          Console.Write(" ");
        }
        else if (Board[Row, Column] == AircraftCarrier || Board[Row, Column] == BattleShip || Board[Row, Column] == Submarine || Board[Row, Column] == Destroyer || Board[Row, Column] == PatrolBoat)
        {
          Console.Write(" ");
        }
        else
        {
          Console.Write(Board[Row, Column]);
        }
        if (Column != 9)
        {
          Console.Write(" | ");
        }
      }
      Console.WriteLine();
    }
  }

  private static void DisplayMenu()
  {
    Console.WriteLine("MAIN MENU");
    Console.WriteLine("");
    Console.WriteLine("1. Start new game");
    Console.WriteLine("2. Load training game");
    Console.WriteLine("9. Quit");
    Console.WriteLine();
  }

  private static int GetMainMenuChoice()
  {
        int Choice = 0;
        try
        {
            
    Console.Write("Please enter your choice: ");
    Choice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
            if (Choice < 3 & Choice != 9) ;
            {
                Console.WriteLine("Invalid input, Try again");
            }
 
        }
        catch (Exception)
        {
          Console.WriteLine("Invalid input, Try again");
        }
        return Choice;
    }

  private static void PlayGame(ref char[,] Board, ref ShipType[] Ships)
  {
    bool GameWon = false;
    while (GameWon == false)
    {
      PrintBoard(Board);
      MakePlayerMove(ref Board, ref Ships);
      GameWon = CheckWin(Board);
      if (GameWon == true)
      {
        Console.WriteLine("All ships sunk!");
        Console.WriteLine();
      }
    }
  }

  private static void SetUpShips(ref ShipType[] Ships)
  {
    Ships[0].Name = "Aircraft Carrier";
    Ships[0].Size = 5;
    Ships[1].Name = "Battleship";
    Ships[1].Size = 4;
    Ships[2].Name = "Submarine";
    Ships[2].Size = 3;
    Ships[3].Name = "Destroyer";
    Ships[3].Size = 3;
    Ships[4].Name = "Patrol Boat";
    Ships[4].Size = 2;
  }

  static void Main(string[] args)
  {
    ShipType[] Ships = new ShipType[5];
    char[,] Board = new char[GridSize, GridSize];
    int MenuOption = 0;
    while (MenuOption != 9)
    {
      SetUpBoard(ref Board);
      SetUpShips(ref Ships);
      DisplayMenu();
      MenuOption = GetMainMenuChoice();
      if (MenuOption == 1)
      {
        PlaceRandomShips(ref Board, Ships);
        PlayGame(ref Board, ref Ships);
      }
      if (MenuOption == 2)
      {
        LoadGame(TrainingGame, ref Board);
        PlayGame(ref Board, ref Ships);
      }
    }
  }
}