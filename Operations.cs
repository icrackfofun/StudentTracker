using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Operations
{
	public static void addStudent(List<Student> students)
	{
		string name = Helper.requestValidName();
		int id = Helper.requestUniqueId(students);
		if (id == -1) return;
		students.Add(new Student(name, id));
		Console.WriteLine("\nStudent Added Successfully\n");
	}

	public static void deleteStudent(List<Student> students)
	{
		int id = Helper.requestValidId(students);
		if (id == -1) return;
		Student student = Helper.findStudentById(students, id)!;
		students.Remove(student);
		Console.WriteLine("\nStudent Removed Successfully\n");

	}

	public static void assignGrade(List<Student> students)
	{
		int id = Helper.requestValidId(students);
		if (id == -1) return;
		int grade = Helper.requestValidGrade();
		Student student = Helper.findStudentById(students, id)!;
		student.addGrade(grade);
		Console.WriteLine("\nGrade Assigned Successfully\n");
	}

	public static void showAverage(List<Student> students)
	{
		int id = Helper.requestValidId(students);
		if (id == -1) return;
		string name = students[id].Name;
		double average = students[id].getAverage();
		Console.WriteLine ($"\n{name}'s Average: {average}\n");
	}

	public static void listAllStudents(List<Student> students)
	{
		Console.WriteLine("\n===== Student Records =====");
		if (students.Count == 0)
		{
			Console.WriteLine("No Students Registered\n");
			return;
		}
		foreach (Student student in students)
			Console.WriteLine(student);
	}

	public static void viewStudentGrades(List<Student> students)
	{
		int id = Helper.requestValidId(students);
		if (id == -1) return;
		students[id].displayGrades();
	}

	public static void saveAndExit(List<Student> students)
	{
		try
		{
			string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
			{ 
				WriteIndented = true 
			});
			File.WriteAllText("students.json", json);
			Console.WriteLine("\nStudents saved successfully.");
		}
		catch (Exception e)
		{
			Console.WriteLine($"Error Saving: {e.Message}");
		}
		finally
		{
			Console.WriteLine($"Exiting...\n");
		}
	}
}