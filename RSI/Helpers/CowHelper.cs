using RSI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RSI.Helpers
{
    public class CowHelper
    {
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

        public bool AddCow(string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfCalving, string tagNumber)
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
                            DateOfCalving = dateOfCalving,
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

        public bool UpdateCow(int id, string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfCalving, string tagNumber)
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
                        currentCow.DateOfCalving = dateOfCalving;
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

        public IList<Cow> GetCowsNearToCalving()
        {
            try
            {
                using (var context = new RmiContext())
                {
                    var dateFrom = DateTime.Now.AddDays(-14);
                    var dateTo = DateTime.Now.AddDays(14);
                    var cows = context.Cows.Where(x =>
                        x.DateOfCalving >= dateFrom && x.DateOfCalving <= dateTo).ToList();
                    return cows;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get cows.", ex);
            }
        }

        public IList<Cow> GetCowsNearToDryOff()
        {
            try
            {
                using (var context = new RmiContext())
                {
                    var dateFrom = DateTime.Now.AddMonths(2).AddDays(-14);
                    var dateTo = DateTime.Now.AddMonths(2).AddDays(14);
                    var cows = context.Cows.Where(x =>
                        x.DateOfCalving >= dateFrom && x.DateOfCalving <= dateTo).ToList();
                    return cows;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get cows.", ex);
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
