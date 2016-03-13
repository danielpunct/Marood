using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
    public static Path<TileInteraction> FindPath(
        TileInteraction start,
        TileInteraction destination)
    {
        var closed = new HashSet<TileInteraction>();
        var queue = new PriorityQueue<double, Path<TileInteraction>>();
        queue.Enqueue(0, new Path<TileInteraction>(start));

        while (!queue.IsEmpty)
        {
            var path = queue.Dequeue();

            if (closed.Contains(path.LastStep))
                continue;
            if (path.LastStep.Equals(destination))
                return path;

            closed.Add(path.LastStep);
            //Debug.Log(" last step: " + path.LastStep.X+" "+path.LastStep.Y);
            foreach (TileInteraction n in path.LastStep.GridTile.Neighbours)
            {
                //Debug.Log(" nb: " + n.X + " " + n.Y);
                double d = 1;// distance(path.LastStep.GridTile, n);
                var newPath = path.AddStep(n, d);
                queue.Enqueue(newPath.TotalCost + estimate(n, destination), 
                    newPath);
            }
            //Debug.Log("---------------");
        }

        return null;
    }

    static double distance(Tile tile1, Tile tile2)
    {
        return 1;
    }

    static double estimate(TileInteraction tile, TileInteraction destTile)
    {
        float dx = Mathf.Abs(destTile.GridTile.X - tile.GridTile.X);
        float dy = Mathf.Abs(destTile.GridTile.Y - tile.GridTile.Y);
        int z1 = -(tile.GridTile.X + tile.GridTile.Y);
        int z2 = -(destTile.GridTile.X + destTile.GridTile.Y);
        float dz = Mathf.Abs(z2 - z1);

        return Mathf.Max(dx, dy, dz);
    }
} 