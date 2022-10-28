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
}

enum Day
{
    [Description("Понидельник")]
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



class DayOfWeek
{
    public string Name { get; set; }
    public List<string> Lessons { get; set; }
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