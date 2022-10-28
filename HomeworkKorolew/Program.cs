using HomeWork.Data;
using System.ComponentModel;
using DayOfWeek = HomeWork.Data.DayOfWeek;

namespace HomeWork;

public class Program
{
    internal static List<Group> Groups = new List<Group>()
    {
        new Group ("3ПКС9", 09231, new List<DayOfWeek>()
        {
            new DayOfWeek(Day.Monday, new List<LessonField>()
            {
                new LessonField(Lesson.Russian_Language, 09231, new Teacher("Дарина", "Одинцова")),
                new LessonField(Lesson.Drawing, 09231, new Teacher("Виктория", "Мельникова")),
                new LessonField(Lesson.Informatics, 09231, new Teacher("Мария", "Гришина")),
                new LessonField(Lesson.Mathematic, 09231, new Teacher("Полина", "Евсеева"))
            }),
            new DayOfWeek(Day.Tuesday, new List<LessonField>()
            {
                new LessonField(Lesson.Biology, 09231, new Teacher("Михаил", "Леонов")),
                new LessonField(Lesson.Chemistry, 09231, new Teacher("Анастасия", "Токарева")),
                new LessonField(Lesson.Mathematic, 09231, new Teacher("Полина", "Евсеева")),
                new LessonField(Lesson.History, 09231, new Teacher("Алексей", "Матвеев"))
            }),
            new DayOfWeek(Day.Wednesday, new List<LessonField>()
            {
                new LessonField(Lesson.Mathematic, 09231, new Teacher("Полина", "Евсеева")),
                new LessonField(Lesson.Chemistry, 09231, new Teacher("Анастасия", "Токарева")),
                new LessonField(Lesson.History, 09231, new Teacher("Алексей", "Матвеев")),
                new LessonField(Lesson.History, 09231, new Teacher("Алексей", "Матвеев"))
            })
        }),

        new Group ("1ПКС", 99321, new List<DayOfWeek>()
        {
            new DayOfWeek(Day.Friday, new List<LessonField>()
            {
                new LessonField(Lesson.Chemistry, 99321, new Teacher("Анастасия","Токарева")),
                new LessonField(Lesson.Algebra, 99321, new Teacher("Полина","Евсеева")),
                new LessonField(Lesson.History, 99321, new Teacher("Алексей","Матвеев")),
                new LessonField(Lesson.English_Language, 99321, new Teacher("Владимир","Лампов"))
            }),
            new DayOfWeek(Day.Saturday, new List<LessonField>()
            {
                new LessonField(Lesson.Biology, 99321, new Teacher("Михаил","Леонов")),
                new LessonField(Lesson.English_Language, 99321, new Teacher("Владимир","Лампов")),
                new LessonField(Lesson.Algebra, 99321, new Teacher("Полина","Евсеева")),
                new LessonField(Lesson.Algebra, 99321, new Teacher("Полина","Евсеева"))
            })
        })
    };

    public static void Main(string[] args)
    {
        Groups.ForEach(item =>
        {
            Console.WriteLine($"Группа: {item.Name} {item.Num}");
            item.Days.ForEach(day =>
            {
                Console.WriteLine($"\t{day.Name}");
                int numLes = 1;
                day.Lessons.ForEach((les) =>
                {
                    Console.WriteLine($"\t\t{numLes++}. {les.Name} - {les.Teacher.Name} {les.Teacher.SurName}");
                });
            });
            Console.WriteLine();
        });

        Console.ReadKey();
    }
}