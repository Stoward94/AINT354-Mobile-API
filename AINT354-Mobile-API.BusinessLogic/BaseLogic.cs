using System;
using System.Globalization;
using System.Threading.Tasks;
using GamingSessionApp.DataAccess;

namespace AINT354_Mobile_API.BusinessLogic
{
    public class BaseLogic
    {
        protected readonly UnitOfWork UoW = new UnitOfWork();

        protected ValidationResult Result = new ValidationResult();

        protected string FormatDateString(string date)
        {
            //Convert the dates in to specific formats
            DateTime dt = DateTime.Parse(date);
            return dt.ToString("dd/MM/yyyy HH:mm:ss");
        }

        protected DateTime ParseUKDate(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        protected Guid? ParseGuid(string src)
        {
            //Convert string to guid
            Guid id;
            if (!Guid.TryParse(src, out id)) return null;

            return id;
        }

        protected ValidationResult AddError(string message)
        {
            Result.Error = message;
            Result.Success = false;
            return Result;
        }

        protected void SaveChanges()
        {
            UoW.Save();
        }

        protected async Task<bool> SaveChangesAsync()
        {
            return await UoW.SaveAsync();
        }

        public void Dispose()
        {
            UoW.Dispose();
        }
    }
}