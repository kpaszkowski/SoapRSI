using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RSI.Model;

namespace RSI
{
    public class CowService : ICowService
    {
        public IList<Cow> Cows { get; set; }

        public CowService()
        {
            this.Cows = new List<Cow>();
        }

        public Cow GetCowInfo(int id)
        {
            try
            {
                using (RmiContext context = new RmiContext())
                {
                    Cow currentCow = context.Cows.FirstOrDefault(x => x.Id == id);

                    return currentCow ?? null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get cow info.", ex);
            }
        }

        public bool AddCow(string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfFertilization, string tagNumber)
        {
            try
            {
                using (RmiContext context = new RmiContext())
                {
                    if (context.Cows.FirstOrDefault(x => x.Name == name) == null)
                    {
                        context.Cows.Add(new Cow
                        {
                            Name = name,
                            CowBreed = cowBreed,
                            DateOfBirth = dateOfBirth,
                            DateOfFertilization = dateOfFertilization,
                            TagNumber = tagNumber
                        });
                        context.SaveChanges();
                        return true;
                    }
                    return false;

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Cannot add new cow.", ex);
            }
        }

        public bool RemoveCow(int id)
        {
            try
            {
                using (RmiContext context = new RmiContext())
                {
                    Cow currentCow = context.Cows.FirstOrDefault(x => x.Id == id);

                    if (currentCow != null)
                    {
                        context.Cows.Remove(currentCow);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Cannot remove cow.", ex);
            }
        }

        public bool UpdateCow(int id, string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfFertilization, string tagNumber)
        {
            try
            {
                using (RmiContext context = new RmiContext())
                {
                    Cow currentCow = context.Cows.FirstOrDefault(x => x.Id == id);

                    if (currentCow != null)
                    {
                        currentCow.Name = name;
                        currentCow.CowBreed = cowBreed;
                        currentCow.DateOfBirth = dateOfBirth;
                        currentCow.DateOfFertilization = dateOfFertilization;
                        currentCow.TagNumber = tagNumber;

                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Cannot update cow.", ex);
            }
        }

        public IList<Cow> GetAllCows()
        {
            try
            {
                using (RmiContext context = new RmiContext())
                {
                    return context.Cows.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get cows info.", ex);
            }
        }
    }
}
