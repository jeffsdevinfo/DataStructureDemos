namespace DataStructureDemosCSharp.Graph
{
    internal class GraphGenericRunner : BaseRunner
    {
        public override void Run()
        {
            base.Run();
            Console.WriteLine("\n\n***Running GraphGenericRunner***");
            GraphGeneric<Point> graphOfPointData = new GraphGeneric<Point>();

            Point point1 = new  Point(1, 1, 1);
            graphOfPointData.AddNode(point1);

            Point point2 = new Point(2, 2, 2);
            graphOfPointData.AddNode(point2);

            Point point3 = new Point(3, 3, 3);
            graphOfPointData.AddNode(point3);

            Point point4 = new Point(4, 4, 4);
            graphOfPointData.AddNode(point4);

            Point point5 = new Point(5, 5, 5);
            graphOfPointData.AddNode(point5);

            Point point6 = new Point(6,6,6);
            graphOfPointData.AddNode(point6);

            graphOfPointData.AddEdgeWithDataLookups(point1, point2, 2);
            graphOfPointData.AddEdgeWithDataLookups(point1, point6, 9);
            graphOfPointData.AddEdgeWithDataLookups(point2, point4, 5);
            graphOfPointData.AddEdgeWithDataLookups(point4, point6, 2);
            graphOfPointData.AddEdgeWithDataLookups(point6, point3, 5);
            graphOfPointData.AddEdgeWithDataLookups(point6, point5, 4);

            graphOfPointData.PrintGraph();

        }
    }
}
