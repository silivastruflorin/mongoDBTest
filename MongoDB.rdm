# MongoDB
Tutorial MongoDB

Cluster: one or multiple servers
Replica Set: one server running an instance( mongoDB instance)

Ex Cluster0: Replica Set 3: Means that the Cluster0 has 3 servers and each one of them are running an instance of MongoDB( one primary and 2 secondary instances). Each database is replicated over all ReplicaSet in the Cluster(redundancy)

Database:
    - Collection1:
        -Document1
        -Document2
        .
        .
        .
    - Collection2:
        ...

    - Collection999

Document is a <key> : value pair
    {
        "id" : 2202022 ,
        "date" : 28-03-2022
    }

Multiple documents are stored in a collection(like paper doc files in a phisical folder). A database comprise of multiple Collections(like folders in a drawer).

How are Documents represented in memory?
    In BSON (Binary JSON) and contains additional data types. But Documents are viewed in JSON format because is easier to read then BSON


Import/Export:

- JSON : mongoimport / mongoexport
- BSON : mongostore / mongodump 


mongodump --uri "mongodb+srv://<your username>:<your password>@<your cluster>.mongodb.net/sample_supplies"

mongoexport --uri="mongodb+srv://<your username>:<your password>@<your cluster>.mongodb.net/sample_supplies" --collection=sales --out=sales.json
//out = filename.json

mongorestore --uri "mongodb+srv://<your username>:<your password>@<your cluster>.mongodb.net/sample_supplies"  --drop dump
// --drop used for removing the existing database on that location. helps to avoid duplicate entries in DB

mongoimport --uri="mongodb+srv://<your username>:<your password>@<your cluster>.mongodb.net/sample_supplies" --drop sales.json
// --drop used for removing the existing database on that location. helps to avoid duplicate entries in DB


Connection to the DB:
- go to web: Cluster : connect : I have a shell installed : copy link
- run cmd and paste link
- hit enter

DB comands:
- show dbs : lists all available databases
- use database_name: to access a database . now the 'db' object is pointing to database_name this can be used later
- show collections: to access the existing collections in our database 
- find() command: db.<collectionName>.find({"fieldQuery": "valueQuery"})
                  db.<collectionName>.find({"fieldQuery": "valueQuery"}).count()
-  findOne(): returns a random document in the collection
- it iterates through the cursor.
- pretty() : db.<collectionName>.find({"fieldQuery": "valueQuery"}).pretty() : to see results in a nicer format
- insert() : db.<collectionName>.insert({"test" : 1}) 
            or multiple documents at the same time: db.<collectionName>.insert( [{ "_id": 1, "test": 1 },{ "_id": 1, "test": 2 },
                       { "_id": 3, "test": 3 }])
    Note: it tries to insert the documents in the order that is specified between ([]) because parameter "ordered" is true, by default.Now it will insert the first document ( test": 1) and when it tries to insert the second document "test": 2 which 
    has the same "_id" it will throw an error and the rest of the documents will not be inserted because of it, even if the id is correct. To resolve this we pass { "ordered": false } 
    db.inspections.insert([{ "_id": 1, "test": 1 },{ "_id": 1, "test": 2 },
                       { "_id": 3, "test": 3 }],{ "ordered": false })

Note: if we try to insert a document in a collection that not exists then MongoDB will automically create it.

Update operators: https://www.mongodb.com/docs/manual/reference/operator/update/


Array operators: https://www.mongodb.com/docs/manual/reference/operator/query-array/


React: https://www.mongodb.com/docs/realm/web/react-web-quickstart/
