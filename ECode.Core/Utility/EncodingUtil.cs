using System.Collections.Generic;

namespace ECode.Utility
{
    public static class EncodingUtil
    {
        static bool IsAscii(byte b)
        {
            if (b > 127)
            { return false; }

            return true;
        }

        /// <summary>
        /// �ж��Ƿ�ΪGBK���ݱ���
        /// </summary>
        public static bool IsGbkEncoding(string charset)
        {
            if (string.IsNullOrWhiteSpace(charset))
            { return false; }

            switch (charset.Trim().ToLower())
            {
                case "gbk":
                case "gb2312":
                case "gb18030":
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// �ж��Ƿ�ΪUTF8���ݱ���
        /// </summary>
        public static bool IsUtf8Encoding(string charset)
        {
            if (string.IsNullOrWhiteSpace(charset))
            { return false; }

            switch (charset.Trim().ToLower())
            {
                case "utf8":
                case "utf-8":
                case "ascii":
                case "us-ascii":
                case "iso-8859-1":
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// �ж��Ƿ�ΪGBK��������
        /// </summary>
        public static bool IsGbkEncodedData(byte[] bytes)
        {
            AssertUtil.ArgumentNotNull(bytes, nameof(bytes));

            int nBytes = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (nBytes == 0 && IsAscii(bytes[i]))
                { continue; }

                if (nBytes == 0)
                {
                    if (bytes[i] >= 0x80)
                    {
                        nBytes = 2;
                        nBytes--;
                    }
                    else
                    { return false; }
                }
                else
                {
                    if (bytes[i] == 10 || bytes[i] == 13)
                    { continue; }

                    nBytes--;
                }
            }

            return nBytes == 0;
        }

        /// <summary>
        /// �ж��Ƿ�ΪUTF8��������
        /// </summary>
        public static bool IsUtf8EncodedData(byte[] bytes)
        {
            AssertUtil.ArgumentNotNull(bytes, nameof(bytes));

            int nBytes = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (nBytes == 0 && IsAscii(bytes[i]))
                { continue; }

                if (nBytes == 0) // �������ASCII�룬Ӧ���Ƕ��ֽڷ��������ֽ���
                {
                    if (bytes[i] >= 0x80)
                    {
                        if (bytes[i] >= 0xFC && bytes[i] <= 0xFD)
                        { nBytes = 6; }
                        else if (bytes[i] >= 0xF8)
                        { nBytes = 5; }
                        else if (bytes[i] >= 0xF0)
                        { nBytes = 4; }
                        else if (bytes[i] >= 0xE0)
                        { nBytes = 3; }
                        else if (bytes[i] >= 0xC0)
                        { nBytes = 2; }
                        else
                        { return false; }

                        nBytes--;
                    }
                    else
                    { return false; }
                }
                else
                {
                    if (bytes[i] == 10 || bytes[i] == 13)
                    { continue; }

                    if ((bytes[i] & 0xC0) != 0x80) //���ֽڷ��ķ����ֽ�,ӦΪ 10xxxxxx
                    { return false; }

                    nBytes--;
                }
            }

            return nBytes == 0;
        }

        /// <summary>
        /// ����GBK�������ݱ��ضϵ�����
        /// </summary>
        public static byte[] ProcessGbkEncodedData(byte[] bytes)
        {
            AssertUtil.ArgumentNotNull(bytes, nameof(bytes));

            int nBytes = 0;
            var temp = new List<byte>(bytes.Length);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (nBytes == 0 && IsAscii(bytes[i]))
                {
                    temp.Add(bytes[i]);
                    continue;
                }

                if (nBytes == 0)
                {
                    if (bytes[i] >= 0x80)
                    {
                        nBytes = 2;
                        nBytes--;
                        temp.Add(bytes[i]);
                    }
                }
                else
                {
                    if (bytes[i] == 10 || bytes[i] == 13)
                    { continue; }

                    nBytes--;
                    temp.Add(bytes[i]);
                }
            }

            return temp.ToArray();
        }

        /// <summary>
        /// ����UTF8�������ݱ��ضϵ�����
        /// </summary>
        public static byte[] ProcessUtf8EncodedData(byte[] bytes)
        {
            AssertUtil.ArgumentNotNull(bytes, nameof(bytes));

            int nBytes = 0;
            var temp = new List<byte>(bytes.Length);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (nBytes == 0 && IsAscii(bytes[i]))
                {
                    temp.Add(bytes[i]);
                    continue;
                }

                if (nBytes == 0) // �������ASCII�룬Ӧ���Ƕ��ֽڷ��������ֽ���
                {
                    if (bytes[i] >= 0x80)
                    {
                        if (bytes[i] >= 0xFC && bytes[i] <= 0xFD)
                        { nBytes = 6; }
                        else if (bytes[i] >= 0xF8)
                        { nBytes = 5; }
                        else if (bytes[i] >= 0xF0)
                        { nBytes = 4; }
                        else if (bytes[i] >= 0xE0)
                        { nBytes = 3; }
                        else if (bytes[i] >= 0xC0)
                        { nBytes = 2; }
                        else
                        { continue; }

                        nBytes--;
                        temp.Add(bytes[i]);
                    }
                }
                else
                {
                    if (bytes[i] == 10 || bytes[i] == 13)
                    { continue; }

                    if ((bytes[i] & 0xC0) != 0x80) //���ֽڷ��ķ����ֽ�,ӦΪ 10xxxxxx
                    { continue; }

                    nBytes--;
                    temp.Add(bytes[i]);
                }
            }

            return temp.ToArray();
        }
    }
}
