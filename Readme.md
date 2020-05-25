GPS Encoder by Michael Taylor | MichaelTaylor3D
-----------------------------------------
www.michaeltaylor.dev

Author: Michael Taylor:

If this library was useful to you, please consider a small donation.

ENS: michaeltaylor.dev.eth

ETHER ADDRESS: 0x411b4F2dCFE158114d9396A30c625Bf7DefAD880

Copyright (c) Michael Taylor

This program is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License along with this program. If not, see http://www.gnu.org/licenses/.

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
of the earth's lat/lon just outside of the gulf of new guinea, Africa. When using
the default (0,0), all your GPS Conversions will be positioned as they would be 
in real life.

However, sometimes you only want to convert your GPS coordinates to a local area
positioned at the UCS (0,0,0) inside of unity. In order to center a local area
at the origin. You need to find the latitude and longitude that corresponds to 
the origin of your scene. If you pass that coordinate into the function. All the 
conversions for the rest of your session will be in relation to the new origin.
