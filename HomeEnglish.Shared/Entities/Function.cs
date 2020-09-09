using System;
using System.Collections.Generic;
using System.Text;

namespace HomeEnglish.Shared.Entities
{
    public static class Function
    {
        public static int CompareDate(DateTime dateFinish, DateTime dateStart)
        {
            if (dateFinish == null || dateStart == null)
                throw new Exception("A datas não devem ser nulas");

            return DateTime.Compare(dateFinish, dateStart);
        }
    }
}
