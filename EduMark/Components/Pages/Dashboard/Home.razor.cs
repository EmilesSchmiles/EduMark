using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;

namespace EduMark.Components.Pages
{
    public class HomeBase : ComponentBase
    {
        // Filter & selection
        protected string SelectedFilter = "Students";
        protected string SelectedBy = "Class";
        protected string SelectedTimeframe = "Per Term";
        protected string SelectedSort = "SurnameAsc";

        protected List<Student> Students = new() 
        {
            new Student { Id = 1, Name = "Alice Smith", Mark = 87 }, 
            new Student { Id = 2, Name = "Bob Johnson", Mark = 92 }, 
            new Student { Id = 3, Name = "Charlie Brown", Mark = 75 }, 
            new Student { Id = 4, Name = "Diana Clark", Mark = 80 }, 
            new Student { Id = 5, Name = "Ethan Lewis", Mark = 63 }, 
            new Student { Id = 6, Name = "Fiona Adams", Mark = 55 }, 
            new Student { Id = 7, Name = "George Hall", Mark = 47 }, 
            new Student { Id = 8, Name = "Hannah Scott", Mark = 98 }, 
            new Student { Id = 9, Name = "Ian Walker", Mark = 72 }, 
            new Student { Id = 10, Name = "Julia King", Mark = 100 }, 
            new Student { Id = 11, Name = "Kevin Wright", Mark = 81 }, 
            new Student { Id = 12, Name = "Laura Green", Mark = 69 }, 
            new Student { Id = 13, Name = "Michael Baker", Mark = 34 }, 
            new Student { Id = 14, Name = "Nina Campbell", Mark = 90 }, 
            new Student { Id = 15, Name = "Oliver Young", Mark = 77 }, 
            new Student { Id = 16, Name = "Paula Edwards", Mark = 88 }, 
            new Student { Id = 17, Name = "Quentin Hughes", Mark = 59 }, 
            new Student { Id = 18, Name = "Rachel Price", Mark = 95 }, 
            new Student { Id = 19, Name = "Samuel Perry", Mark = 66 }, 
            new Student { Id = 20, Name = "Tina Foster", Mark = 73 } 
        };

        // Subjects
        protected List<SubjectAverage> subjects = new()
        {
            new SubjectAverage { Name = "Maths", Average = 45 },
            new SubjectAverage { Name = "English", Average = 65 },
            new SubjectAverage { Name = "Art", Average = 83 }
        };

        // Charts
        protected List<ChartSeries> chartSeries = new();
        protected string[] chartLabels = Array.Empty<string>();
        protected ChartOptions chartOptions = new();
        protected AxisChartOptions axisOptions = new();

        protected override void OnInitialized()
        {
            SetupChart();
        }

        private void SetupChart()
        {
            chartLabels = Students.Select(s => s.Name).ToArray();
            chartSeries = new List<ChartSeries>
            {
                new ChartSeries { Name = "Marks", Data = Students.Select(s => (double)s.Mark).ToArray() }
            };

            chartOptions = new ChartOptions
            {
                ChartPalette = new string[] { "#925cf0", "#F803FE", "#925cf0", "#4da6ff", "#ffb84d" },
                YAxisLines = true,
                XAxisLines = false,
                MaxNumYAxisTicks = 10,
                YAxisTicks = 10
            };

            axisOptions = new AxisChartOptions
            {
                LabelRotation = 45,
                LabelExtraHeight = 150,
                MatchBoundsToSize = true,
                StackedBarWidthRatio = 2
            };
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Mark { get; set; }
        }

        public class SubjectAverage
        {
            public string Name { get; set; }
            public double Average { get; set; }
        }
    }
}
