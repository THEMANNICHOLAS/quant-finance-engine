namespace Option.Calculations
{
    public class OptionPricing
    {

        /*
        Before touching the code, you need the standard Black-Scholes formula for a call option:
        $C = S_0 N(d_1) - K e^{-rT} N(d_2)$

        Where:
        - $S_0$: Current stock price
        - $K$: Strike price
        - $r$: Risk-free interest rate
        - $T$: Time to expiration (in years)
        - $N(\cdot)$: The Cumulative Distribution Function (CDF) of the standard normal distribution.
               * 
               * 
        */
        private double underlyingPrice; //current stock price
        private double strikePrice; //strike price
        private double riskFreeRate; //risk-free interest rate
        private double time; //time to expiration in years
        private double CDF; // CDF of the standard normal distribution

        public void setGreeks(double underlyingPrice, double strikePrice, double riskFreeRate, double time)
        {
            this.underlyingPrice = underlyingPrice;
            this.strikePrice = strikePrice;
            this.riskFreeRate = riskFreeRate;
            this.time = time;
        }

        public double calculateCallOptionPrice()
        {
            double d1 = (Math.Log(underlyingPrice / strikePrice) + (riskFreeRate + 0.5 * Math.Pow(0.2, 2)) * time) / (0.2 * Math.Sqrt(time));
            double d2 = d1 - 0.2 * Math.Sqrt(time);
            CDF = Statistics.Phi(d1);
            double callOptionPrice = underlyingPrice * CDF - strikePrice * Math.Exp(-riskFreeRate * time) * Statistics.Phi(d2);
            return callOptionPrice;
        }

        public double calculatePutOptionPrice()
        {
            double d1 = (Math.Log(underlyingPrice / strikePrice) + (riskFreeRate + 0.5 * Math.Pow(0.2, 2)) * time) / (0.2 * Math.Sqrt(time));
            double d2 = d1 - 0.2 * Math.Sqrt(time);
            CDF = Statistics.Phi(-d1);
            double putOptionPrice = strikePrice * Math.Exp(-riskFreeRate * time) * Statistics.Phi(-d2) - underlyingPrice * CDF;
            return putOptionPrice;
        }


        public double calculateDelta()
        {
            double d1 = (Math.Log(underlyingPrice / strikePrice) + (riskFreeRate + 0.5 * Math.Pow(0.2, 2)) * time) / (0.2 * Math.Sqrt(time));
            return Statistics.Phi(d1);
        }

    }
}
