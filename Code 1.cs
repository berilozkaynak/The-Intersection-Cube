using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;



/// <summary>
/// This class will be instantiated on demand by the Script component.
/// </summary>
public class Script_Instance : GH_ScriptInstance
{
#region Utility functions
  /// <summary>Print a String to the [Out] Parameter of the Script component.</summary>
  /// <param name="text">String to print.</param>
  private void Print(string text) { /* Implementation hidden. */ }
  /// <summary>Print a formatted String to the [Out] Parameter of the Script component.</summary>
  /// <param name="format">String format.</param>
  /// <param name="args">Formatting parameters.</param>
  private void Print(string format, params object[] args) { /* Implementation hidden. */ }
  /// <summary>Print useful information about an object instance to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj) { /* Implementation hidden. */ }
  /// <summary>Print the signatures of all the overloads of a specific method to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj, string method_name) { /* Implementation hidden. */ }
#endregion

#region Members
  /// <summary>Gets the current Rhino document.</summary>
  private readonly RhinoDoc RhinoDocument;
  /// <summary>Gets the Grasshopper document that owns this script.</summary>
  private readonly GH_Document GrasshopperDocument;
  /// <summary>Gets the Grasshopper script component that owns this script.</summary>
  private readonly IGH_Component Component;
  /// <summary>
  /// Gets the current iteration count. The first call to RunScript() is associated with Iteration==0.
  /// Any subsequent call within the same solution will increment the Iteration count.
  /// </summary>
  private readonly int Iteration;
#endregion

  /// <summary>
  /// This procedure contains the user code. Input parameters are provided as regular arguments,
  /// Output parameters as ref arguments. You don't have to assign output parameters,
  /// they will have a default value.
  /// </summary>
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