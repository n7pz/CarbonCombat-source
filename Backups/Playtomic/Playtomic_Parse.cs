using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtomic_Parse : Playtomic_Responder
{
	private static string SECTION;

	private static string SAVE;

	private static string DELETE;

	private static string LOAD;

	private static string FIND;

	internal static void Initialise(string apikey)
	{
		SECTION = Playtomic_Encode.MD5("parse-" + apikey);
		SAVE = Playtomic_Encode.MD5("parse-save-" + apikey);
		DELETE = Playtomic_Encode.MD5("parse-delete-" + apikey);
		LOAD = Playtomic_Encode.MD5("parse-load-" + apikey);
		FIND = Playtomic_Encode.MD5("parse-find-" + apikey);
	}

	public IEnumerator Save(PFObject pobject)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, SAVE, ObjectPostData(pobject), out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			pobject.ObjectId = (string)data["id"];
			pobject.CreatedAt = DateTime.Parse((string)data["created"]);
			pobject.UpdatedAt = DateTime.Parse((string)data["updated"]);
			response.PObject = pobject;
		}
		SetResponse(response, "Save");
	}

	public IEnumerator Delete(PFObject pobject)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, DELETE, ObjectPostData(pobject), out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		SetResponse(response, "Delete");
	}

	public IEnumerator Load(string pobjectid, string classname)
	{
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(postdata: ObjectPostData(new PFObject
		{
			ObjectId = pobjectid,
			ClassName = classname
		}), section: SECTION, action: LOAD, url: out url, post: out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			Hashtable data = response.JSON;
			PFObject po = new PFObject
			{
				ClassName = (string)data["classname"],
				ObjectId = (string)data["id"],
				Password = (string)data["password"],
				CreatedAt = DateTime.Parse((string)data["created"]),
				UpdatedAt = DateTime.Parse((string)data["updated"])
			};
			Hashtable fields = (Hashtable)data["fields"];
			foreach (object key in fields.Keys)
			{
				po.Data.Add((string)key, (string)fields[key]);
			}
			Hashtable pointers = (Hashtable)data["pointers"];
			foreach (object key2 in pointers.Keys)
			{
				ArrayList pdata = (ArrayList)pointers[key2];
				PFObject pchild = new PFObject
				{
					ObjectId = (string)pdata[0],
					ClassName = (string)pdata[1]
				};
				po.Pointers.Add(new PFPointer((string)key2, pchild));
			}
			response.PObject = po;
		}
		SetResponse(response, "Load");
	}

	public IEnumerator Find(PFQuery pquery)
	{
		Dictionary<string, string> postdata = new Dictionary<string, string>
		{
			{ "classname", pquery.ClassName },
			{
				"limit",
				pquery.Limit.ToString()
			},
			{
				"order",
				string.IsNullOrEmpty(pquery.Order) ? "created_at" : pquery.Order
			}
		};
		foreach (string key in pquery.WhereData.Keys)
		{
			postdata.Add("data" + key, pquery.WhereData[key]);
		}
		for (int i = pquery.WherePointers.Count - 1; i > -1; i--)
		{
			postdata["pointer" + i + "fieldname"] = pquery.WherePointers[i].FieldName;
			postdata["pointer" + i + "classname"] = pquery.WherePointers[i].PObject.ClassName;
			postdata["pointer" + i + "id"] = pquery.WherePointers[i].PObject.ObjectId;
		}
		string url;
		WWWForm post;
		Playtomic_Request.Prepare(SECTION, FIND, postdata, out url, out post);
		WWW www = new WWW(url, post);
		yield return www;
		Playtomic_Response response = Playtomic_Request.Process(www);
		if (response.Success)
		{
			response.PObjects = new List<PFObject>();
			ArrayList array = response.ARRAY;
			foreach (Hashtable data in array)
			{
				PFObject po = new PFObject
				{
					ClassName = (string)data["classname"],
					ObjectId = (string)data["id"],
					Password = (string)data["password"],
					CreatedAt = DateTime.Parse((string)data["created"]),
					UpdatedAt = DateTime.Parse((string)data["updated"])
				};
				Hashtable fields = (Hashtable)data["fields"];
				foreach (object key2 in fields.Keys)
				{
					po.Data.Add((string)key2, (string)fields[key2]);
				}
				Hashtable pointers = (Hashtable)data["pointers"];
				foreach (object key3 in pointers.Keys)
				{
					ArrayList pdata = (ArrayList)pointers[key3];
					PFObject pchild = new PFObject
					{
						ObjectId = (string)pdata[0],
						ClassName = (string)pdata[1]
					};
					po.Pointers.Add(new PFPointer((string)key3, pchild));
				}
				response.PObjects.Add(po);
			}
		}
		SetResponse(response, "Find");
	}

	private static Dictionary<string, string> ObjectPostData(PFObject pobject)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("classname", pobject.ClassName);
		dictionary.Add("id", (pobject.ObjectId != null) ? pobject.ObjectId : string.Empty);
		dictionary.Add("password", (pobject.Password != null) ? pobject.Password : string.Empty);
		foreach (string key in pobject.Data.Keys)
		{
			dictionary.Add("data" + key, pobject.Data[key]);
		}
		for (int num = pobject.Pointers.Count - 1; num > -1; num--)
		{
			dictionary.Add("pointer" + num + "fieldname", pobject.Pointers[num].FieldName);
			dictionary.Add("pointer" + num + "classname", pobject.Pointers[num].PObject.ClassName);
			dictionary.Add("pointer" + num + "id", pobject.Pointers[num].PObject.ObjectId);
		}
		return dictionary;
	}
}
