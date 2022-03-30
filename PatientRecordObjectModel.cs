/* 
    Here will define Object Model that defines the data that you can store within Realm Database.
    Example of data: Patient records:
    - name: required (string)
    - birth date: required (array/struct)
    - contact details: { 
                           adresss: {
                                        city:,
                                        street:,
                                        no:
                                     }
                           phone:
                        }
    
 */
using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;

public class record : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId? Id { get; set; } = ObjectId.GenerateNewId();

    [MapTo("_partitionKey")]
    [Required]
    public string PartitionKey { get; set; }

    [MapTo("contact")]
    public record_contact Contact { get; set; }

    [MapTo("dateOfBirth")]
    public IList<int> DateOfBirth { get; }

    [MapTo("name")]
    [Required]
    public string Name { get; set; }
}

public class record_contact : EmbeddedObject
{
    [MapTo("address")]
    public record_contact_address Address { get; set; }

    [MapTo("phone")]
    public string Phone { get; set; }
}

public class record_contact_address : EmbeddedObject
{
    public string Street { get; set; }

    [MapTo("city")]
    public string City { get; set; }

    [MapTo("no")]
    public int? No { get; set; }
}
