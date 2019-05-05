using RSI.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace RSI
{
    [ServiceContract]
    public interface ICowService
    {
        [OperationContract]
        IList<Cow> GetAllCows();

        [OperationContract]
        Cow GetCowInfo(int id);

        [OperationContract]
        bool AddCow(string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfCalving, string tagNumber);

        [OperationContract]
        bool RemoveCow(int id);

        [OperationContract]
        bool UpdateCow(int id, string name, CowBreed cowBreed, DateTime dateOfBirth, DateTime dateOfCalving, string tagNumber);

        [OperationContract]
        IList<Cow> GetCowsNearToCalving();

        [OperationContract]
        IList<Cow> GetCowsNearToDryOff();

    }
}
