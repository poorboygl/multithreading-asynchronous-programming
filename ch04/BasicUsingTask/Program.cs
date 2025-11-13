//Thread thread = new Thread(Work);
//thread.Start();

//Task task = new Task(Work);
//task.Start();

var t = Task.Run(Work);
Console.ReadLine();

void Work()
{
    Console.WriteLine("I love Programming!");
}