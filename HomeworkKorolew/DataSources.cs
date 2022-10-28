using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace HomeWork.Data;

internal static class Data
{
    private static readonly ConcurrentDictionary<string, string> DisplayNameCache = new ConcurrentDictionary<string, string>();
    internal static string DisplayName(this Enum value)
    {
        var key = $"{value.GetType().FullName}.{value}";

        var displayName = DisplayNameCache.GetOrAdd( key, x =>
        {
            var name = (DescriptionAttribute[])value
                        .GetType()
                        .GetTypeInfo()
                        .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return name.Length > 0 ? name[0].Description : value.ToString();
        });

        return displayName;
    }

    public static string GetDescription(this Enum enumValue)
    {
        return enumValue.GetType()
                   .GetMember(enumValue.ToString())
                   .First()
                   .GetCustomAttribute<DescriptionAttribute>()?
                   .Description ?? string.Empty;
    }
}

enum Day
{
    [Description("Понедельник")]
    Monday,
    [Description("Вторник")]
    Tuesday,
    [Description("Среда")]
    Wednesday,
    [Description("Четверг")]
    Thursday,
    [Description("Пятница")]
    Friday,
    [Description("Суббота")]
    Saturday,
    [Description("Воскресенье")]
    Sunday
}
enum Lesson
{
    [Description("Русский язык")]
    Russian_Language,
    [Description("Английский язык")]
    English_Language,
    [Description("Математика")]
    Mathematic,
    [Description("Литература")]
    Literature,
    [Description("Химия")]
    Chemistry,
    [Description("Информатика")]
    Informatics,
    [Description("Алгебра")]
    Algebra,
    [Description("Биология")]
    Biology,
    [Description("Рисование")]
    Drawing,
    [Description("Геометрия")]
    Geometry,
    [Description("География")]
    Geography,
    [Description("История")]
    History
}

class LessonField
{
    public LessonField(Lesson name, int group, Teacher teacher)
    {
        Name = name.GetDescription();
        GroupNum = group;
        Teacher = teacher;
    }

    public string Name { get; set; }
    public int GroupNum { get; set; }
    public Teacher Teacher { get; set; }

}
class Group
{
    public Group(string name, int num, List<DayOfWeek> days)
    {
        Name = name;
        Num = num;
        Days = days;
    }

    public string Name { get; set; }
    public int Num { get; set; }
    public List<DayOfWeek> Days { get; set; }
}
class DayOfWeek
{
    public DayOfWeek(Day name, List<LessonField> lessons)
    {
        Name = name.GetDescription();
        Lessons = lessons;
    }

    public string Name { get; set; }
    public List<LessonField> Lessons { get; set; }
}
class Teacher
{
    public Teacher(string name, string surName)
    {
        Name = name;
        SurName = surName;
    }

    public string Name { get; set; }
    public string SurName { get; set; }
}