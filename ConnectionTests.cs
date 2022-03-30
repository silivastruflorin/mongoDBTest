using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using Realms.Sync;
using Realms.Exceptions;

namespace mongoDBTest
{
    class MongoDB
    {
        private User user;

        public async Task<Realm> ConnectToDB() {
            Console.Write("I am trying to connect! \n");
            var app = App.Create("mongodb-react-test-guhph");
            /*
            authentificate as an anonimous user. This option is available only if
            Data Access - Authentificatio - Authentification Providers->
            Option "Allow users to log in anonimously" is enabled. else see docs
             to authentificate with specific user
            https://www.mongodb.com/docs/realm/sdk/dotnet/examples/open-a-realm/
            */
           
            user = await app.LogInAsync(Credentials.EmailPassword("silivastruflorin@yahoo.ro", "testtest"));
            Console.Write("UserID {0} \n", user.Identities);
            /*
            Configured on BUILD->Sync (Web ui)
            Partition key must be a field in each document and based on the value of this field
            we retreive and modify data :  example<filed> : value => "_partition":"TestPartitionKey"
             Also make sure to have permission defined 
             */
            var config = new PartitionSyncConfiguration("TestPartitionKey", user);
            var realmInstance = await Realm.GetInstanceAsync(config);

            var session = realmInstance.SyncSession;
           
            try
            {
                Console.WriteLine("Trying to write to local DB using Realm \n");
                /* 
                    Sync App logic https://www.mongodb.com/docs/realm/sync/local-to-sync/ 
                */

                // Write transaction to the realm
                //realmInstance.Write(() =>
                //{
                //    //Populate schema object with data
                //    var address = new record_contact_address();
                //    address.City = "Bucharest";
                //    address.Street = "Riot Street";
                //    address.No = 1001;

                //    var contact = new record_contact();
                //    contact.Address = address;
                //    contact.Phone = "023-021-13456";
                    
                //    // 
                //    realmInstance.Add(new record()
                //    {
                //        Name = "Ion Iliescu",
                //        PartitionKey = "TestPartitionKey",
                //        Contact = contact,
                //        DateOfBirth = {29, 08, 1940 }

                //    });
                //});

                //wait until syncronization si done before going out of scope
                Console.WriteLine(" Waits for the Realms.Sync.Session to finish all pending uploads... \n");
                await session.WaitForUploadAsync();

                //Read the entire collection
                var allPatientRecords = realmInstance.All<record>();
                Console.WriteLine("I am reading from DB  \n");
                foreach (var result in allPatientRecords)
                {
                    Console.WriteLine("Name: {0}, \n _partitionKey:{1}, \n Id:{2} \n  ", result.Name, result.PartitionKey, result.Id);
                }

                /*
                     //Removes everything from the realm associated with _partitionKey selected in 'config'
                    realmInstance.Write(() =>
                    {
                        // Remove all objects from the realm.
                        realmInstance.RemoveAll();
                    });

                */

                var filteredResult = allPatientRecords.Filter("contact.address.city == 'NY'");
                foreach(var property in filteredResult) {
                    Console.WriteLine(" Filter collection to return patients from NY {0} \n", property.Name);
                }

            }
            catch (RealmFileAccessErrorException ex)
            {
                Console.WriteLine($@"Error creating or opening the realm file. {ex.Message}");
               
            }
            return realmInstance;


   

        }


        static void Main(string[] args)
        {
            MongoDB obj = new MongoDB();

            obj.ConnectToDB().Wait();


        }
    }
}
