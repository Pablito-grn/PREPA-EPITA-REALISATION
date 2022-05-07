using System;

namespace tp14
{
    public class Neurone
    {

        /// <summary>
        /// Value of the neurone after the propagation
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Weights of the neurone
        /// </summary>
        public double[] Weights { get; }

        /// <summary>
        /// Bias of the neurones
        /// </summary>
        public double Bias { get; set; }

        /// <summary>
        /// Create new neurone
        /// </summary>
        /// <param name="prevSize"> size of the last layer </param>
        public Neurone(int prevSize)
        {
            Value = 0;
            Weights = new double[prevSize];
            
            Random rand = new Random();
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = __RandomDouble(-1, 1);
            }
            Bias = __RandomDouble(-1, 1);

        }

        public static double __RandomDouble(double min, double max){
            
            Random rand = new Random();
            return (rand.NextDouble() * (max - min) + min);;
        }
        
        /// <summary>
        /// Mutate a neurone
        /// </summary>
        /// <param name="neurone"> old neurone </param>
        /// <param name="mutate"> apply mutation </param>
        public Neurone(Neurone neurone, bool mutate)
        {
            Weights = new double[neurone.Weights.Length];
            for (var i = 0; i < neurone.Weights.Length; i++)
            {
                Weights[i] = neurone.Weights[i];
            }

            Bias = neurone.Bias;

            Value = 0;

            if (mutate)
            {
                Mutate();
            }
        }

        /// <summary>
        /// Random function using Box-Muller transform
        /// </summary>
        /// <returns></returns>
        private static double RandomGaussian()
        {
            var u1 = -2.0 * Math.Log(FlappIA.Rnd.NextDouble());
            var u2 = 2.0 * Math.PI * FlappIA.Rnd.NextDouble();
            return Math.Sqrt(u1) * Math.Cos(u2);
        }
        
        /// <summary>
        /// Apply the mutation depending on a chosen algorithm
        /// </summary>
        /// <param name="probability"> probability of applying the mutation </param>
        /// <returns> true to mutate, false otherwise </returns>
        private bool ShouldMutate(double probability)
        {
            return probability > 0.2;
        }

        /// <summary>
        /// Mutate the neurone
        /// </summary>
        public void Mutate()
        {
            Bias = ShouldMutate(__RandomDouble(0, 1)) ? Bias + RandomGaussian() : Bias;

            for (var i = 0; i < Weights.Length; i++)
            {
                Weights[i] = ShouldMutate(__RandomDouble(0, 1)) ? Weights[i] + RandomGaussian() : Weights[i];
            }
        }

        /// <summary>
        /// Mix the neurone with its partner
        /// </summary>
        /// <param name="partner"> the partner to be mixed with </param>
        public void Crossover(Neurone partner)
        {
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = (Weights[i] + partner.Weights[i]) / 2;
            }
        }

        /// <summary>
        /// Apply the front propagation to the current neurone and update its value
        /// </summary>
        /// <param name="prevLayer"></param>
        public void FrontProp(Layer prevLayer)
        {
            double res = 0;
            foreach (var neurone in prevLayer.Neurones)
            {
                res += neurone.Bias * neurone.Value;
            }
            Value = Activation(res + this.Bias);
        }

        /// <summary>
        /// Activation function
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static double Activation(double x)
        {
            return Math.Log(1 + Math.Exp(x));
        }
    }
}