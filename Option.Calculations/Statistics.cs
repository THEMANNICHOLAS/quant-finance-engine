using MathNet.Numerics;



namespace Option.Calculations
{
    public static class Statistics
    {
        // TODO: Implement mathematical utility functions
        public static double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
        ///<summaryNewton-Raphson method for finding roots of a function</summary>
        /// Newton-Raphson method for finding roots of a function
        /// <param name="function">The function for which to find the root</param
        /// <param name="initialGuess">The initial guess for the root</param
        /// <param name="order">The order of the derivative to use (1 for first derivative, 2 for second derivative, etc.)</param>
        /// <param name="tolerance">The tolerance for convergence</param>
        /// <param name="maxIterations">The maximum number of iterations to perform</param>
        public static double NewtonRaphson(
            Func<double, double> function,
            double initialGuess,
            int order,
            double tolerance = 1e-7,
            int maxIterations = 100)

        {
            double x = initialGuess; 
            for (int i = 0; i < maxIterations; i++)
            {
                double fx = function(x);
                double dfx = Differentiate.Derivative(function, x, order);

                if (Math.Abs(dfx) < 1e-12) break;

                double nextX = x - fx / dfx;
                if (Math.Abs(nextX - x) < tolerance)
                    return nextX;

                x = nextX;
            }
            return x;
        }

        public static double MonteCarloOptionPrice(Func<double, double> payoff, Func<double, double> pricePath, int simulations = 100000)
        {
            double sum = 0;
            Random rand = new Random();
            for (int i = 0; i < simulations; i++)
            {
                sum += payoff(pricePath(rand.NextDouble()));
            }
            return sum / simulations;
        }

        }
    }

