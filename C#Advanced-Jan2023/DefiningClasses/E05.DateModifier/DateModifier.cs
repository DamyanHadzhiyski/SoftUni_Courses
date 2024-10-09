using System;

namespace E05.DateModifier
{
	public static class DateModifier
    {
        //methods
        public static int GetDifference(string firstDate, string secondDate)
        {
            //split the first date to year, month and day
            int[] firstDateSplit = firstDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

			int firstDateYear = firstDateSplit[0];
			int firstDateMonth = firstDateSplit[1];
			int firstDateDay = firstDateSplit[2];

			//split the second date to year, month and day
			int[] secondDateSplit = secondDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

			int secondDateYear = secondDateSplit[0];
			int secondDateMonth = secondDateSplit[1];
			int secondDateDay = secondDateSplit[2];

			//find earliest date
			if (firstDateYear > secondDateYear)
			{
				secondDateYear = firstDateSplit[0];
				secondDateMonth = firstDateSplit[1];
				secondDateDay = firstDateSplit[2];

				firstDateYear = secondDateSplit[0];
				firstDateMonth = secondDateSplit[1];
				firstDateDay = secondDateSplit[2];
			}

			//calcualte days difference
			int daysDifference = 0;

			for (int year = firstDateYear; year <= secondDateYear; year++)
			{
				int startMonth = 1;
				int endMonth = 12;

				if (year == firstDateYear)
				{
					startMonth = firstDateMonth;
					daysDifference -= firstDateDay;
				}

				if (year == secondDateYear)
				{
					endMonth = secondDateMonth - 1;
					daysDifference += secondDateDay;
				}

				for (int month = startMonth; month <= endMonth; month++)
				{
					daysDifference += DateTime.DaysInMonth(year, month);
				}
			}

			return daysDifference;
        }
    }
}
