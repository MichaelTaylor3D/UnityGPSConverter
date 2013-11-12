GPS Encoder by Michael Taylor | MichaelTaylor3D
www.michaeltaylor3d.com

API:

public static Vector2 USCToGPS(Vector3 position)
-------------------------------------------------------
To find the GPS equivalent to your (x,y,z) position in the scene
simply pass that position into this function.


public static Vector3 GPSToUCS(Vector2 gps)
public static Vector3 GPSToUCS(float latitude, float longitude)
-------------------------------------------------------
To find the (X,Y,Z) equivalent of a set of GPS coordinates.
Pass the latitude and longitude into one of these functions.




public static void SetLocalOrigin(Vector2 localOrigin)
-------------------------------------------------------
By Default All of your conversions will assume that your using a 
latitude/longitude origin of (0,0). This places you at the real life origin
of the earth’s lat/lon just outside of the gulf of new guinea, Africa. When using
the default (0,0), all your GPS Conversions will be positioned as they would be 
in real life.

However, sometimes you only want to convert your GPS coordinates to a local area
positioned at the UCS (0,0,0) inside of unity. In order to center a local area
at the origin. You need to find the latitude and longitude that corresponds to 
the origin of you scene. If you pass that coordinate into the function. All the 
conversions for the rest of you session will be in relation to the new origin.
