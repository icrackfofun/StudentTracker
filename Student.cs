public class Student
{
	public string Name {get;set;}
	public int Id {get;set;}
	public List<int> Grades {get;set;}

	public Student (string name, int id)
	{
		Name = name;
		Id = id;
		Grades = new List<int>();
	}

	public override string ToString()
	{
		return  $"\nName: {Name}\nID: {Id}\n";
	}

	public void addGrade(int grade)
	{
		Grades.Add(grade);
	}

	public void displayGrades()
	{
		if (Grades.Count == 0)
			Console.WriteLine("\nNo Grades to Show\n");
		int i = 0;
		Console.WriteLine($"==== {Name}'s Grades ====\n");
		foreach (int grade in Grades)
		{
			Console.WriteLine($"{i + 1}. {grade}");
			i++;
		}
		Console.WriteLine();
	}

	public double getAverage()
	{
		if (Grades.Count == 0) return 0;
		int average = 0;
		foreach (int grade in Grades)
			average += grade;
		return (double)average / Grades.Count;
	}
}