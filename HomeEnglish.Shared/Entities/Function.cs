using MongoDB.Driver;
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

        public static TimeSpan SubtractDate(DateTime dateFinish, DateTime dateStart)
        {
            return dateFinish.Subtract(dateStart);
        }

        public static DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }

        public static string EncodeHash(string password)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
