using Tumultu.Domain.Exceptions;

namespace Tumultu.Domain.Extensions;

public static class EntropyExtensions
{
    private static long _sampleSize;
    public static List<double> CalculateEntropy(this byte[] payload, int amountOfSamples)
    {
        if(amountOfSamples > payload.Length)
        {
            throw new InvalidAmountOfSamplesException(payload.Length, amountOfSamples);
        }

        _sampleSize = payload.Length / amountOfSamples;

        Func<byte[], double> GetSampleEntropy = bytes =>
        {
            var entropy = 0.0;
            Dictionary<byte, int> histogram = new Dictionary<byte, int>();

            for(byte b = 0; b < 0xFF; b++) 
                histogram.Add(b, 0);

            foreach (byte b in bytes)
                histogram[b]++;


            foreach (var b in histogram)
                entropy += ((double)b.Value * b.Value) / bytes.Length;

            entropy = 1 - (entropy / bytes.Length);
            return Math.Pow(entropy, 2);
        };

        var entropyOfSamples = new List<double>();

        for(int i = 0; i < amountOfSamples; i++)
        {
            byte[] bytes = new byte[_sampleSize];

            for (int j = 0; j < _sampleSize; j++)
                bytes[j] = payload[(i * _sampleSize) + j];

            entropyOfSamples.Add(
                    GetSampleEntropy(bytes)
                );
        }

        return entropyOfSamples;
    }
}
