class Program
{
  static void Main(string[] args)
  {    
    while (true)
        {
         Bird bird; 
         Console.Write("\nPress P for pigeon 🕊️, O for ostrich 🦩, S for swallow 🐦: ");
         char key = Char.ToUpper(Console.ReadKey().KeyChar);
         if (key == 'P') {bird = new Pigeon();}
         else if (key == 'O') {bird = new Ostrich();}
         else if (key == 'S') {bird =new Swallow();}
         else return;
         
         Console.WriteLine("\nHow many eggs should it lay?");
         if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
         Egg[] eggs = bird.LayEggs(numberOfEggs);
         foreach(Egg egg in eggs)
          {
              Console.WriteLine(egg.Description);
          } 
        }
   }
}


class Egg
{
    public double Size {get; private set;}
    public string Color{get; private set;}
    public string EggEmoji{get; private set;}

    public Egg(double size, string color, string eggemoji)
    {
        Size = size;
        Color = color;
        EggEmoji = eggemoji;
    }

    public string Description
    {
        get {return $"A {Size:0.0} {Color} egg {EggEmoji}";}
    }

}

class BrokenEgg : Egg
{
  public BrokenEgg(string color, string eggemoji) : base ($"broken{color}", eggemoji)
  {
    Console.WriteLine("A bird laid a broken egg");
  }
}

abstract class Bird
{
    protected static Random randomizer = new Random();
    public abstract Egg[] LayEggs(int numberOfEggs); 
}


class Pigeon : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
      Egg[] eggs = new Egg[numberOfEggs]; 
      for (int l = 0; l < numberOfEggs; l++)
         {
           if (randomizer.Next(4) == 0)
              {
                eggs[l] = new BrokenEgg("white", "🍳");
              } else
                eggs[l] = new Egg(Bird.randomizer.NextDouble() * 2, "white","🐣");
         }
         return eggs;
    }
}

class Ostrich : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
      Egg[] eggs = new Egg[numberOfEggs]; 
      for (int l = 0; l < numberOfEggs; l++)
      {
        eggs[l] = new Egg(randomizer.NextDouble() + 12 , "speckled", "🥚");
      }
      return eggs;
    }
}

class Swallow : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] eggs = new Egg[numberOfEggs];
        for (int i = 0; i < numberOfEggs; i++)
        {
           eggs[i] = new Egg(randomizer.NextDouble() * (0.9 - 0.6) + 0.6, "pale blue", "🪺");
        }
        return eggs;
    }
}