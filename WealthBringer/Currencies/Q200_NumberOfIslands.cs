using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthBringer.Currencies
{
    public partial class Currency
    {
        public int NumIslands(char[][] grid)
        {

            var res = 0;

            if (grid == null || grid.Length < 1)
                return res;

            var q = new Queue<int>();
            var visited = new HashSet<int>();
            var M = grid.Length;
            var N = grid[0].Length;

            var moves = new List<int> { 1, 0, -1, 0, 1 };

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    var offset = i * N + j;

                    if (grid[i][j] != '1' || visited.Contains(offset))
                        continue;

                    q.Enqueue(offset);
                    visited.Add(offset);

                    while (q.Count > 0)
                    {
                        offset = q.Dequeue();
                        int X = offset / N;
                        int Y = offset % N;

                        for (var k = 0; k < 4; k++)
                        {
                            var x = X + moves[k];
                            var y = Y + moves[(k + 1)];
                            offset = x * N + y;

                            if (x < 0 || x >= M || y < 0 || y >= N || grid[x][y] != '1' || !visited.Add(offset))
                                continue;

                            q.Enqueue(offset);
                        }
                    }

                    res++;
                }
            }

            return res;
        }
    }
}
