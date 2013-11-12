//Copyright 2013 MichaelTaylor3D
//www.michaeltaylor3d.com

using UnityEngine;

public sealed class GPSEncoder {

	/////////////////////////////////////////////////
	//////-------------Public API--------------//////
	/////////////////////////////////////////////////
	
	/// <summary>
	/// Convert UCS (X,Y,Z) coordinates to GPS (Lat, Lon) coordinates
	/// </summary>
	/// <returns>
	/// Returns Vector2 containing Latitude and Longitude
	/// </returns>
	/// <param name='position'>
	/// (X,Y,Z) Position Parameter
	/// </param>
	public static Vector2 USCToGPS(Vector3 position)
	{
		return GetInstance().ConvertUCStoGPS(position);
	}
	
	/// <summary>
	/// Convert GPS (Lat, Lon) coordinates to UCS (X,Y,Z) coordinates
	/// </summary>
	/// <returns>
	/// Returns a Vector3 containing (X, Y, Z)
	/// </returns>
	/// <param name='gps'>
	/// (Lat, Lon) as Vector2
	/// </param>
	public static Vector3 GPSToUCS(Vector2 gps)
	{
		return GetInstance().ConvertGPStoUCS(gps);
	}
	
	/// <summary>
	/// Convert GPS (Lat, Lon) coordinates to UCS (X,Y,Z) coordinates
	/// </summary>
	/// <returns>
	/// Returns a Vector3 containing (X, Y, Z)
	/// </returns>
	public static Vector3 GPSToUCS(float latitude, float longitude)
	{
		return GetInstance().ConvertGPStoUCS(new Vector2(latitude,longitude));
	}
	
	/// <summary>
	/// Change the relative GPS offset (Lat, Lon), Default (0,0), 
	/// used to bring a local area to (0,0,0) in UCS coordinate system
	/// </summary>
	/// <param name='localOrigin'>
	/// Referance point.
	/// </param>
	public static void SetLocalOrigin(Vector2 localOrigin)
	{
		GetInstance()._localOrigin = localOrigin;
	}
		
	/////////////////////////////////////////////////
	//////---------Instance Members------------//////
	/////////////////////////////////////////////////
	
	#region Singleton
	private static GPSEncoder _singleton;
	
	private GPSEncoder()
	{
		
	}
	
	private static GPSEncoder GetInstance()
	{
		if(_singleton == null)
		{
			_singleton = new GPSEncoder();
		}
		return _singleton;
	}
	#endregion
	
	#region Instance Variables
	private Vector2 _localOrigin = Vector2.zero;
	private float _LatOrigin { get{ return _localOrigin.x; }}	
	private float _LonOrigin { get{ return _localOrigin.y; }}

	private float metersPerLat;
	private float metersPerLon;
	#endregion
	
	#region Instance Functions
	private void FindMetersPerLat(float lat) // Compute lengths of degrees
	{
	    // Set up "Constants"
	    float m1 = 111132.92f;    // latitude calculation term 1
	    float m2 = -559.82f;        // latitude calculation term 2
	    float m3 = 1.175f;      // latitude calculation term 3
	    float m4 = -0.0023f;        // latitude calculation term 4
	    float p1 = 111412.84f;    // longitude calculation term 1
	    float p2 = -93.5f;      // longitude calculation term 2
	    float p3 = 0.118f;      // longitude calculation term 3
	    
	    lat = lat * Mathf.Deg2Rad;
	
	    // Calculate the length of a degree of latitude and longitude in meters
	    metersPerLat = m1 + (m2 * Mathf.Cos(2 * (float)lat)) + (m3 * Mathf.Cos(4 * (float)lat)) + (m4 * Mathf.Cos(6 * (float)lat));
	    metersPerLon = (p1 * Mathf.Cos((float)lat)) + (p2 * Mathf.Cos(3 * (float)lat)) + (p3 * Mathf.Cos(5 * (float)lat));	   
	}

	private Vector3 ConvertGPStoUCS(Vector2 gps)  
	{
		FindMetersPerLat(_LatOrigin);
		float zPosition  = metersPerLat * (gps.x - _LatOrigin); //Calc current lat
		float xPosition  = metersPerLon * (gps.y - _LonOrigin); //Calc current lat
		return new Vector3((float)xPosition, 0, (float)zPosition);
	}
	
	private Vector2 ConvertUCStoGPS(Vector3 position)
	{
		FindMetersPerLat(_LatOrigin);
		Vector2 geoLocation = new Vector2(0,0);
		geoLocation.x = (_LatOrigin + (position.z)/metersPerLat); //Calc current lat
		geoLocation.y = (_LonOrigin + (position.x)/metersPerLon); //Calc current lon
		return geoLocation;
	}
	#endregion
}
