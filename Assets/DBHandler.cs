using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;  
using MongoDB.Driver.GridFS;  
using MongoDB.Driver.Linq; 

public class DBHandler : MonoBehaviour {

	string connectionString = "mongodb://localhost:27017";
	// Use this for initialization
	void Start () {
		var client = new MongoClient(connectionString);
		var server = client.GetServer(); 
		var database = server.GetDatabase("unity");
		var shopcollections= database.GetCollection<BsonDocument>("vrshop");
		Debug.Log ("Connected!!0.0");

		//insert into collections
		BsonDocument [] batch={
			new BsonDocument{
				{"name", "nike"},
				{"price", "100"}
			}, 
			new BsonDocument{
				{"name", "adidas"},
				{"price", "200"}
			},
			new BsonDocument{
				{"name", "Lining"},
				{"price", "300"}
			} 
		};
		shopcollections.InsertBatch (batch);

		//print all collections
		foreach (var document in shopcollections.FindAll()) {
			Debug.Log ("Get all info: \n" + document);
		}
		//print one collection
		foreach (var document in shopcollections.Find(new QueryDocument("name", "nike"))){
			Debug.Log ("Get one info: \n" + document);
		}
		//find the first one:
		Debug.Log("5. SELECT FIRST DOC: \n" + shopcollections.FindOne ().ToString());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
