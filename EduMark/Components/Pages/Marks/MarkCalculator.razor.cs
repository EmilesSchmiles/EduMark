using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduMark.Components.Pages
{
    public class MarkCalculatorBase : ComponentBase
    {
        protected int TotalMark = 30;
        protected int EnteredMark;
        protected string SelectedStudent = string.Empty;
        protected bool CountsTowardsFinal { get; set; } = true; // or false by default


        protected bool _addTestDialogOpen = false;

        protected void OpenAddTestDialog() => _addTestDialogOpen = true;
        protected void CloseAddTestDialog() => _addTestDialogOpen = false;

        protected void SaveNewTest()
        {
            // TODO: save the test here

            _addTestDialogOpen = false;
        }

        protected void CancelAddTest()
        {
            _addTestDialogOpen = false;
        }

        protected void ClearInputs()
        {
            SelectedStudent = string.Empty;
            EnteredMark = 0;
        }

        protected List<StudentMark> StudentMarks = new()
        {
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 5, Name = "Student 5", Class = "Math", Mark = 20, Total = 30, Percentage = 66 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },
            new StudentMark { Id = 1, Name = "Student 1", Class = "English", Mark = 18, Total = 30, Percentage = 60 },
            new StudentMark { Id = 2, Name = "Student 2", Class = "Math", Mark = 22, Total = 30, Percentage = 73 },
            new StudentMark { Id = 3, Name = "Student 3", Class = "Art", Mark = 25, Total = 30, Percentage = 83 },
            new StudentMark { Id = 4, Name = "Student 4", Class = "English", Mark = 27, Total = 30, Percentage = 90 },



        };

        protected Task<IEnumerable<string>> SearchStudents(string value, CancellationToken token)
        {
            var list = new List<string> { "Student 1", "Student 2", "Student 3", "Student 4", "Student 5" };
            return Task.FromResult(list.Where(s => s.Contains(value, StringComparison.OrdinalIgnoreCase)));
        }

        protected void AddStudentMark()
        {
            if (string.IsNullOrWhiteSpace(SelectedStudent))
                return;

            var newId = StudentMarks.Count + 1;
            var percentage = (int)((EnteredMark / (double)TotalMark) * 100);

            StudentMarks.Add(new StudentMark
            {
                Id = newId,
                Name = SelectedStudent,
                Class = "Demo Class",
                Mark = EnteredMark,
                Total = TotalMark,
                Percentage = percentage
            });

            ClearInputs();
        }

        protected void DiscardAll() => StudentMarks.Clear();

        protected void SaveAll()
        {
            Console.WriteLine("Saved " + StudentMarks.Count + " entries.");
        }

        protected class StudentMark
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Class { get; set; } = "";
            public int Mark { get; set; }
            public int Total { get; set; }
            public int Percentage { get; set; }
        }
    }
}
