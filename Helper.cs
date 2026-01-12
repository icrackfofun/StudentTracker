using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Helper
{
	public static void loadData(List<Student> students)
	{
		if (File.Exists("students.json"))
		{
			try
			{
				string jsonString = File.ReadAllText("students.json");
				var loaded = JsonSerializer.Deserialize<List<Student>>(jsonString);
				students.AddRange(loaded!);
				Console.WriteLine($"\nStudents Loaded Successfully\n");
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error loading students: {e.Message}");
			}
		}
	}

	public static void printMenu()
	{
		Console.WriteLine("====== Student Management System ======");
		Console.WriteLine("1. Add Student");
		Console.WriteLine("2. Delete Student");
		Console.WriteLine("3. Assign Grade to Student");
		Console.WriteLine("4. List All Students");
		Console.WriteLine("5. View Student Grades");
		Console.WriteLine("6. Show Student Average");
		Console.WriteLine("7. Save & Exit");
		Console.Write("Please select an option: ");
	}

	public static Student? findStudentById(List<Student> students, int id)
	{
		foreach (Student student in students)
		{
			if (id == student.Id) return student;
		}
		return null;
	}

	public static int requestUniqueId(List<Student> students)
	{
		int id = -1;
		bool validId = false;
		while (!validId)
		{
			Console.Write("Insert ID (\'back\' to return to menu): ");
			string? sid = Console.ReadLine();
			if (sid?.Trim() == "back")
			{
				Console.WriteLine();
				return -1;
			}
			if (!int.TryParse(sid, out id))
			{
				Console.WriteLine("Please enter a valid number");
				continue;
			}
			if (id < 0 || findStudentById(students, id) != null)
			{
				Console.WriteLine("Student ID already Exists");
				continue;
			}
			validId = true;
		}
		return id;
	}

	public static int requestValidId(List<Student> students)
	{
		int id = -1;
		bool validId = false;
		while (!validId)
		{
			Console.Write("Insert ID (\'back\' to return to menu): ");
			string? sid = Console.ReadLine();
			if (sid?.Trim() == "back")
			{
				Console.WriteLine();
				return -1;
			}
			if (!int.TryParse(sid, out id))
			{
				Console.WriteLine("Please enter a valid number");
				continue;
			}
			if (id < 0 || findStudentById(students, id) == null)
			{
				Console.WriteLine("Student ID Doesn't Exist");
				continue;
			}
			validId = true;
		}
		return id;
	}

	public static string requestValidName()
	{
		string? name = "";
		bool validName = false;
		while (!validName)
		{
			Console.Write("Insert Name: ");
			name = Console.ReadLine();
			if (string.IsNullOrEmpty(name))
			{
				Console.WriteLine("Insert a non-empty Name");
				continue;
			}
			validName = true;
		}
		return name!;
	}

	public static int requestValidGrade()
	{
		int grade = 0;
		bool validGrade = false;
		while (!validGrade)
		{
			Console.Write("Insert Grade: ");
			string? sgrade = Console.ReadLine();
			if (!int.TryParse(sgrade, out grade))
			{
				Console.WriteLine("Please enter a valid number'");
				continue;
			}
			if (grade < 0 || grade > 100)
			{
				Console.WriteLine("Grade out of Range (0 - 100)");
				continue;
			}
			validGrade = true;
		}
		return grade;
	}
}