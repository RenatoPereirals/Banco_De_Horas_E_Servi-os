using Bsd.Domain.Services.Interfaces;
using Bsd.Domain.Enums;

namespace Bsd.Domain.Services;

public class DayTypeChecker : IDayTypeChecker
{
    private readonly IHolidayChecker _holidayChecker;

    public DayTypeChecker(IHolidayChecker holidayChecker)
    {
        _holidayChecker = holidayChecker;
    }

    public DayType GetDayType(DateTime date)
    {
        if (IsSundayAndHoliday(date))
            return DayType.SundayAndHoliday;
        else if (IsSunday(date))
            return DayType.Sunday;
        else if (_holidayChecker.IsHoliday(date))
            return DayType.Holiday;
        else
            return DayType.Workday;
    }

    private bool IsSundayAndHoliday(DateTime date)
    {
        bool isSunday = date.DayOfWeek == DayOfWeek.Sunday;
        bool isHoliday = _holidayChecker.IsHoliday(date);

        return isSunday && isHoliday;
    }

    private static bool IsSunday(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Sunday)
            return true;

        return false;
    }
}