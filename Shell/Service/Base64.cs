namespace Shell.Data
{

    public class Base64
    {
        public Base64()
        {
            initCodecs();
        }
        string KEY_CODE = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        string BASE_64_MAP_INIT = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        string[] Base64EncMap = new string[64];
        string[] Base64DecMap = new string[128];
        string nl = "";

        public void initCodecs()
        {
            nl = "<P>" + Convert.ToChar(13) + Convert.ToChar(10);
            int max = BASE_64_MAP_INIT.Length;
            for (int idx = 0; idx < max; idx++)
            {
                Base64EncMap[idx] = BASE_64_MAP_INIT.Substring(idx, 1);
            }
            for (int idy = 0; idy < max; idy++)
            {
                Base64DecMap[KEY_CODE.IndexOf(Base64EncMap[idy]) + 33] = Convert.ToString(idy);
            }
        }

        public string base64Encode(string plain)
        {
            if (plain.Trim() != "")
            {
                string ret = "";
                int ndx = 1, by3 = 0, first = 0, second = 0, third = 0;
                by3 = (plain.Length / 3) * 3;
                while (ndx <= by3)
                {
                    first = KEY_CODE.IndexOf(plain.Substring(ndx - 1, 1)) + 33;
                    second = KEY_CODE.IndexOf(plain.Substring(ndx + 0, 1)) + 33;
                    third = KEY_CODE.IndexOf(plain.Substring(ndx + 1, 1)) + 33;
                    if (first / 4 < 63)
                    {
                        ret += Base64EncMap[first / 4];
                    }
                    else
                    {
                        ret += Base64EncMap[(first / 4) & 63];
                    }

                    if (first * 16 < 48)
                    {
                        if (second / 16 < 15)
                        {
                            ret += Base64EncMap[(first * 16) + (second / 16)];
                        }
                        else
                        {
                            ret += Base64EncMap[(first * 16) + ((second / 16) & 15)];
                        }
                    }
                    else
                    {
                        if (second / 16 < 15)
                        {
                            ret += Base64EncMap[((first * 16) & 48) + (second / 16)];
                        }
                        else
                        {
                            ret += Base64EncMap[((first * 16) & 48) + ((second / 16) & 15)];
                        }
                    }

                    if (second * 4 < 60)
                    {
                        if (third / 64 < 3)
                        {
                            ret += Base64EncMap[(second * 4) + (third / 64)];
                        }
                        else
                        {
                            ret += Base64EncMap[(second * 4) + ((third / 64) & 3)];
                        }
                    }
                    else
                    {
                        if (third / 64 < 3)
                        {
                            ret += Base64EncMap[(second * 4 & 60) + (third / 64)];
                        }
                        else
                        {
                            ret += Base64EncMap[(second * 4 & 60) + ((third / 64) & 3)];
                        }
                    }

                    if (third < 63)
                    {
                        ret += Base64EncMap[third];
                    }
                    else
                    {
                        ret += Base64EncMap[third & 63];
                    }
                    ndx = ndx + 3;
                }
                if (by3 < plain.Length)
                {
                    first = KEY_CODE.IndexOf(plain.Substring(ndx - 1, 1)) + 33;
                    if (first / 4 < 63)
                    {
                        ret += Base64EncMap[first / 4];
                    }
                    else
                    {
                        ret += Base64EncMap[(first / 4) & 63];
                    }
                    if (plain.Length % 3 == 2)
                    {
                        second = KEY_CODE.IndexOf(plain.Substring(ndx + 0, 1)) + 33;
                        if (first * 16 < 48)
                        {
                            if (second / 16 < 15)
                            {
                                ret += Base64EncMap[(first * 16) + (second / 16)];
                            }
                            else
                            {
                                ret += Base64EncMap[(first * 16) + ((second / 16) & 15)];
                            }
                        }
                        else
                        {
                            if (second / 16 < 15)
                            {
                                ret += Base64EncMap[(first * 16 & 48) + (second / 16)];
                            }
                            else
                            {
                                ret += Base64EncMap[(first * 16 & 48) + ((second / 16) & 15)];
                            }
                        }

                        if (second * 4 < 60)
                        {
                            ret += Base64EncMap[second * 4];
                        }
                        else
                        {
                            ret += Base64EncMap[(second * 4) & 60];
                        }
                    }
                    else
                    {
                        if (first * 16 < 48)
                        {
                            ret += Base64EncMap[first * 16];
                        }
                        else
                        {
                            ret += Base64EncMap[(first * 16) & 48];
                        }
                        ret += "=";
                    }
                    ret += "=";
                }
                plain = ret;
            }
            return plain;
        }

        public string base64Decode(string scrambled)
        {
            if (scrambled.Trim() != "")
            {
                int realLen = scrambled.Length - 1;
                while (scrambled.Substring(realLen, 1) == "=")
                {
                    realLen = realLen - 1;
                }
                string ret = "";
                int ndx = 1, first = 0, second = 0, third = 0, fourth = 0;
                int by4 = Convert.ToInt32((Convert.ToDouble(realLen) / 4)) * 4;
                while (ndx <= by4)
                {
                    first = Convert.ToInt32(Base64DecMap[KEY_CODE.IndexOf(scrambled.Substring(ndx - 1, 1)) + 33]);
                    second = Convert.ToInt32(Base64DecMap[KEY_CODE.IndexOf(scrambled.Substring(ndx + 0, 1)) + 33]);
                    third = Convert.ToInt32(Base64DecMap[KEY_CODE.IndexOf(scrambled.Substring(ndx + 1, 1)) + 33]);
                    fourth = Convert.ToInt32(Base64DecMap[KEY_CODE.IndexOf(scrambled.Substring(ndx + 2, 1)) + 33]);

                    if (first * 4 < 255)
                    {
                        if (second / 16 < 3)
                        {
                            ret += Convert.ToChar((first * 4) + (second / 16));
                        }
                        else
                        {
                            ret += Convert.ToChar((first * 4) + ((second / 16) & 3));
                        }
                    }
                    else
                    {
                        if (second / 16 < 3)
                        {
                            ret += Convert.ToChar((first * 4 & 255) + (second / 16));
                        }
                        else
                        {
                            ret += Convert.ToChar((first * 4 & 255) + ((second / 16) & 3));
                        }
                    }

                    if (second * 16 < 255)
                    {
                        if (third / 4 < 15)
                        {
                            ret += Convert.ToChar((second * 16) + (third / 4));
                        }
                        else
                        {
                            ret += Convert.ToChar((second * 16) + ((third / 4) & 15));
                        }
                    }
                    else
                    {
                        if (third / 4 < 15)
                        {
                            ret += Convert.ToChar((second * 16 & 255) + (third / 4));
                        }
                        else
                        {
                            ret += Convert.ToChar((second * 16 & 255) + ((third / 4) & 15));
                        }
                    }

                    if (third * 64 < 255)
                    {
                        if (fourth < 63)
                        {
                            ret += Convert.ToChar((third * 64) + (fourth));
                        }
                        else
                        {
                            ret += Convert.ToChar((third * 64) + ((fourth) & 63));
                        }
                    }
                    else
                    {
                        if (fourth < 63)
                        {
                            ret += Convert.ToChar((third * 64 & 255) + (fourth));
                        }
                        else
                        {
                            ret += Convert.ToChar((third * 64 & 255) + ((fourth) & 63));
                        }
                    }
                    ndx = ndx + 4;
                }
                if (ndx < realLen + 1)
                {
                    first = Convert.ToInt32(Base64DecMap[KEY_CODE.IndexOf(scrambled.Substring(ndx - 1, 1)) + 33]);
                    second = Convert.ToInt32(Base64DecMap[KEY_CODE.IndexOf(scrambled.Substring(ndx + 0, 1)) + 33]);
                    if (first * 4 < 255)
                    {
                        if (second / 16 < 3)
                        {
                            ret += Convert.ToChar((first * 4) + (second / 16));
                        }
                        else
                        {
                            ret += Convert.ToChar((first * 4) + ((second / 16) & 3));
                        }
                    }
                    else
                    {
                        if (second / 16 < 3)
                        {
                            ret += Convert.ToChar((first * 4 & 255) + (second / 16));
                        }
                        else
                        {
                            ret += Convert.ToChar((first * 4 & 255) + ((second / 16) & 3));
                        }
                    }
                    if ((realLen + 1) % 4 == 3)
                    {
                        third = Convert.ToInt32(Base64DecMap[KEY_CODE.IndexOf(scrambled.Substring(ndx + 1, 1)) + 33]);
                        if (second * 16 < 255)
                        {
                            if (third / 4 < 15)
                            {
                                ret += Convert.ToChar((second * 16) + (third / 4));
                            }
                            else
                            {
                                ret += Convert.ToChar((second * 16) + ((third / 4) & 15));
                            }
                        }
                        else
                        {
                            if (third / 4 < 15)
                            {
                                ret += Convert.ToChar((second * 16 & 255) + (third / 4));
                            }
                            else
                            {
                                ret += Convert.ToChar((second * 16 & 255) + ((third / 4) & 15));
                            }
                        }
                    }
                }
                scrambled = ret;
            }
            return scrambled;
        }
    }
}
