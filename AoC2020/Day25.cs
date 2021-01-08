namespace AoC2020
{
    public static class Day25
    {
        public static long Task25_1(long publicKey1, long publicKey2)
        {
            var subject = 7;
            var divider = 20201227;

            long loopSize1 = 0;
            var x = 1;
            while (x != publicKey1)
            {
                x *= subject;
                x %= divider;
                loopSize1++;
            }

            long encrKey = 1;
            for (int i = 0; i < loopSize1; i++)
            {
                encrKey *= publicKey2;
                encrKey %= divider;
            }

            return encrKey;
        }
    }
}