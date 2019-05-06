using System;
using System.Collections.Generic;
using System.Linq;
using RSI.Helpers;
using RSI.Model;

namespace RSI
{
    [GlobalErrorBehaviorAttribute(typeof(GlobalErrorHandler))]
    public class CowService : ICowService
    {
        public IList<Cow> Cows { get; set; }
        private CowHelper CowHelper { get; }

        public CowService()
        {
            this.Cows = new List<Cow>();
            this.CowHelper = new CowHelper();
        }

        public Cow GetCowInfo(int id)
        {
            return CowHelper.GetCowInfo(id);
        }

        public bool AddCow(string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfCalving, string tagNumber)
        {
            return CowHelper.AddCow(name, cowBreed, dateOfBirth, dateOfCalving, tagNumber);
        }

        public bool RemoveCow(int id)
        {
            return CowHelper.RemoveCow(id);
        }

        public bool UpdateCow(int id, string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfCalving, string tagNumber)
        {
            return CowHelper.UpdateCow(id, name, cowBreed, dateOfBirth, dateOfCalving, tagNumber);
        }

        public IList<Cow> GetCowsNearToCalving()
        {
            return CowHelper.GetCowsNearToCalving();
        }

        public IList<Cow> GetCowsNearToDryOff()
        {
            return CowHelper.GetCowsNearToDryOff();
        }

        public IList<Cow> GetAllCows()
        {
            return CowHelper.GetAllCows();
        }
    }
}
