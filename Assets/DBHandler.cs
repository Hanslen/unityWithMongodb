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
		foreach (var document in shopcollections.FindAll()) {
			Debug.Log ("Get info: \n" + document);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
