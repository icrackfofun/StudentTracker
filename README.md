Student Management System
=========================

Overview
--------

This project is a Simple **console-based Student Management System** built in C#.\
It allows users to:

-   Add and remove students

-   Assign grades to students

-   View individual student grades

-   Calculate and display average grades

-   Persist student data across program runs using JSON

The system emphasizes **robust input validation, type safety, modular code structure, and clean user interaction**.

* * * * *

Features
--------

-   **Add Student**: Register a new student with a unique ID and name.

-   **Delete Student**: Remove a student by ID.

-   **Assign Grade**: Assign a numeric grade (0--100) to a student.

-   **List All Students**: Display all registered students.

-   **View Student Grades**: Show all grades for a specific student.

-   **Show Average**: Calculate and display a student's average grade.

-   **Save & Exit**: Persist all data to `students.json` using JSON serialization.

* * * * *

Techniques Practiced
--------------------

1.  **File I/O & Serialization**

    -   Use of `System.Text.Json` to serialize/deserialize `List<Student>` to a JSON file.
  
    -   Upon Startup, if `students.json` file is present, student data will be loaded for use.

    -   Safe reading/writing using `File.ReadAllText` and `File.WriteAllText`.

    -   Handling of empty or missing files to prevent runtime errors.

2.  **Input Validation & Type Safety**

    -   `int.TryParse` to safely parse numeric inputs.

    -   Validation loops to ensure IDs are unique, grades are in range, and names are non-empty.

    -   Null checks for `Console.ReadLine()` and use of null-forgiving operator `!` where logic guarantees non-null.

    -   Ensures no invalid data can enter the system.

3.  **Methods & Modular Design**

    -   Code is split into multiple classes for **modularity**:

        -   `Program` --- Main loop and program entry

        -   `Helper` --- Input validation, data loading, and utility methods

        -   `Operations` --- CRUD operations and grade management

        -   `Student` --- Student object with properties and methods (`addGrade`, `getAverage`, `displayGrades`)

    -   This separation improves readability, maintainability, and scalability.

4.  **Type Safety**

    -   Strongly-typed `List<Student>` and `List<int>` for grades.

    -   Properties with `get`/`set` ensure safe access.

    -   Prevents runtime type errors and improves code reliability.

6.  **User-Friendly Console UI**

    -   Clear menu prompts and informative messages.

    -   Option to cancel inputs using `"back"` keyword.

    -   Graceful handling of invalid input without crashing the program.

* * * * *

Project Structure
-----------------

```
StudentManagement/
│
├── Program.cs           # Main program loop
├── Helper.cs            # Utility and validation methods
├── Operations.cs        # CRUD and grade operations
├── Student.cs           # Student class definition
└── students.json        # Persistent data storage (JSON)
```

* * * * *

Concepts Applied
----------------

-   **Object-Oriented Programming (OOP)**

    -   Encapsulation of student data and behavior in `Student` class

    -   Separation of concerns with helper and operations classes

-   **Data Persistence**

    -   JSON serialization/deserialization for permanent storage

-   **Error Handling**

    -   Try/catch blocks for file operations

    -   Null checks and input validation to avoid exceptions

-   **Modularity & Maintainability**

    -   Logical separation of concerns allows easy extension or modification

-   **Type Safety**

    -   Use of `int`, `string`, `List<T>` ensures only valid data types are processed

    -   Safe parsing and validation prevent invalid runtime behavior

* * * * *

Usage
-----

1.  Run the program with:

```
dotnet run
```

1.  Follow the menu prompts to add students, assign grades, or view records.

2.  All data is automatically saved to `students.json` when exiting.
