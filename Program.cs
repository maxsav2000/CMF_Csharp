using System;

namespace Interpol
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] grid1 = { 0f, 1f, 2f, 3f, 4f, 5f };
            float[] val1 = { 5f, 4f, 3f, 2f, 5f, 3f };
            float[] grid2 = { 0.33f, 0.66f, 1f, 1.5f, 1.9f, 3.9f, 4.1f, 4.3f, 4.7f };
            float[] val2 = linear_interp(grid1, val1, grid2);
            for (int i = 0; i < val2.Length; i++) {
                Console.Write(val2[i]+"     ");
            }
        }

        static float[] linear_interp(float[] x, float[] y, float[] z)
        {
            // x - grid
            // y = f(x)
            // z - interp grid
            // result - f(z), with linear interpolation
            // x, z - sorted
            float[] result = new float[z.Length];

            int x_index = 0;

            int get_first_greater(float z) {
                while (x[x_index+1] < z) {
                    x_index++;
                    if (x_index+1 >= x.Length) {
                        return x_index;
                    }
                }
                return x_index;
            }
            float interp(float x1, float x2, float y1, float y2, float z) {
                float cf = (z - x1) / (x2 - x1);
                return y1 * (1 - cf) + cf * y2;
            }
            for (int i = 0; i < z.Length; i++) {
                int j = get_first_greater(z[i]);
                result[i] = interp(x[j],x[j+1],y[j],y[j+1], z[i]);
            }

            return result;
        }

    }
}
