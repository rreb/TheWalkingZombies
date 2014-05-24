﻿using UnityEngine;
using System.Collections;

public class ResourcesScript : MonoBehaviour {

	private float _resourcesLevel;
	private bool _dead; //to prevent multiple destroyAfterDeath calls

	// Use this for initialization
	void Start () {
		_resourcesLevel = 150.0f;
		_dead = false;
	}

	// Update is called once per frame
	void Update () {
		if(_dead){
			this.rigidbody.AddForce(0,2000.0f,0, ForceMode.Force);
		}
		this.transform.root.gameObject.transform.position += new Vector3(0.0f, 0.0f, -0.00001f);
	}

    public float getResourcesLevel()
    {
        return _resourcesLevel;
    }

	public float catchResources(){
		//to make it "disappear"
		_resourcesLevel -= 25.0f;

		if(_resourcesLevel <= 0){
			float ammountTaken = 25.0f + _resourcesLevel; 
			_dead = true;
			foreach(Transform child in transform){
				Destroy(child.gameObject);
			}
			StartCoroutine("destroyAfterDeath");
			return ammountTaken;
		}else
			return 25.0f;
	}

    public bool catchResources(out float val)
    {
        //to make it "disappear"
        _resourcesLevel -= 25.0f;

        if (_resourcesLevel <= 0)
        {
            float ammountTaken = 25.0f + _resourcesLevel;
            _dead = true;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            StartCoroutine("destroyAfterDeath");
            val = ammountTaken;
            return true;
        }
        else
            val = 25.0f;
        return false;
    }

	private IEnumerator destroyAfterDeath(){
		yield return new WaitForSeconds(3.0F);
		Destroy(this.gameObject);
	}
}