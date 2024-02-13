using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;


  private void RunScript(double radius, int count, ref object A, ref object B)
  {

    //lets create a sphere first
    Point3d origin = new Point3d(0, 0, 0);
    Vector3d normal = new Vector3d(0, 0, 1);
    Plane plane = new Plane(origin, normal);


    Sphere s = new Sphere(plane, radius);

    //create a list for the random points on sphere
    List <Point3d> pList = new List <Point3d>();

    Random rnd = new Random();
    for (int i = 0; i < count; i++)
    {
      //generate spherical coordinates
      double u = 2 * Math.PI * rnd.NextDouble(); //longitudinal
      double v = Math.Acos(2 * rnd.NextDouble() - 1); //latitudinal

      //generate a random radius value that is less than or equal to the sphere's radius
      double randomRadius = radius * Math.Pow(rnd.NextDouble(), 1.0 / 3.0); //cubic root for uniform distribution

      //convert spherical coordinates to cartesian coordinates inside the sphere
      double x = origin.X + randomRadius * Math.Sin(v) * Math.Cos(u);
      double y = origin.Y + randomRadius * Math.Sin(v) * Math.Sin(u);
      double z = origin.Z + randomRadius * Math.Cos(v);

      //add the point to the list
      pList.Add(new Point3d(x, y, z));
    }

    B = pList; //output for the points
    A = s; //output for the sphere




  }

  // <Custom additional code> 


  // </Custom additional code> 
}
