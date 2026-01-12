class Program
{
	private static readonly List<Student> students = new List<Student>();


	public static void Main(string[] args)
	{
		Helper.loadData(students);

		bool running = true;
		while (running)
		{
			Helper.printMenu();

			string? selection = Console.ReadLine();
			if (selection == null) {Console.WriteLine("Invalid Choice"); continue; }
			selection = selection.Trim();
			switch (selection)
			{
				case "1": Operations.addStudent(students); break;
				case "2": Operations.deleteStudent(students); break;
				case "3": Operations.assignGrade(students); break;
				case "4": Operations.listAllStudents(students); break;
				case "5": Operations.viewStudentGrades(students); break;
				case "6": Operations.showAverage(students); break;
				case "7": Operations.saveAndExit(students); running = false; break;
				default: Console.WriteLine("Invalid Choice"); break;
			}
		}
	}
}
