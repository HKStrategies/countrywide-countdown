using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace AoC.Questionnaire
{
    public static class Extensions
    {
        public static void Write(this Stream stream, string text)
        {
            Write(stream, text, Encoding.UTF8);
        }

        public static void Write(this Stream stream, string text, Encoding encoding)
        {
            using (var sw = new StreamWriter(stream, encoding, 4096, true))
            {
                sw.Write(text);
            }
        }

        public static void Write(this Stream stream, string text, params object[] values)
        {
            Write(stream, Encoding.UTF8, text, values);
        }

        public static void Write(this Stream stream, Encoding encoding, string text, params object[] values)
        {
            Write(stream, string.Format(text, values), encoding);
        }

        public static IEnumerable<FileInfo> RecursiveFileSearch(this DirectoryInfo dir)
        {
            Queue<DirectoryInfo> q = new Queue<DirectoryInfo>();
            q.Enqueue(dir);

            while (q.Count > 0)
            {
                var directory = q.Dequeue();
                foreach (var file in directory.GetFiles())
                {
                    yield return file;
                }

                foreach (var d in directory.GetDirectories())
                {
                    q.Enqueue(d);
                }
            }
        }

        public static string Hash(this string clear_text)
        {
            using (HashAlgorithm hash = new SHA256CryptoServiceProvider())
            {
                return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(clear_text)));
            }
        }

        private static readonly Regex EMAIL_REGEX = new Regex(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool ValidateEmail(this string email)
        {
            return EMAIL_REGEX.IsMatch(email);
        }

        public static void CopyTo(this Stream input, Stream output)
        {
            input.CopyTo(output, short.MaxValue);
            return;
        }
        public static void CopyTo(this Stream input, Stream output, int buffer_size)
        {
            if (!input.CanRead)
                throw new InvalidOperationException("input must be open for reading");
            if (!output.CanWrite)
                throw new InvalidOperationException("output must be open for writing");

            byte[][] buffer = { new byte[buffer_size], new byte[buffer_size] };
            int[] length = { 0, 0 };
            int index = 0;
            IAsyncResult read = input.BeginRead(buffer[index], 0, buffer[index].Length, null, null);
            IAsyncResult write = null;

            while (true)
            {

                // wait for the read operation to complete
                read.AsyncWaitHandle.WaitOne();
                length[index] = input.EndRead(read);

                // if zero bytes read, the copy is complete
                if (length[index] == 0)
                    break;

                // wait for the in-flight write operation, if one exists, to complete
                // the only time one won't exist is after the very first read operation completes
                if (write != null)
                {
                    write.AsyncWaitHandle.WaitOne();
                    output.EndWrite(write);
                }

                // start the new write operation
                write = output.BeginWrite(buffer[index], 0, length[index], null, null);

                // toggle the current, in-use buffer
                // and start the read operation on the new buffer.
                //
                // Changed to use XOR to toggle between 0 and 1.
                // A little speedier than using a ternary expression.
                index ^= 1; // bufno = ( bufno == 0 ? 1 : 0 ) ;

                read = input.BeginRead(buffer[index], 0, buffer[index].Length, null, null);
            }

            // wait for the final in-flight write operation, if one exists, to complete
            // the only time one won't exist is if the input stream is empty.
            if (write != null)
            {
                write.AsyncWaitHandle.WaitOne();
                output.EndWrite(write);
            }

            output.Flush();

            // return to the caller ;
            return;
        }


        public static async Task CopyToAsync(this Stream input, Stream output)
        {
            await input.CopyToAsync(output, short.MaxValue);
            return;
        }

        public static async Task CopyToAsync(this Stream input, Stream output, int bufferSize)
        {
            if (!input.CanRead)
                throw new InvalidOperationException("input must be open for reading");
            if (!output.CanWrite)
                throw new InvalidOperationException("output must be open for writing");

            byte[][] buffer = { new byte[bufferSize], new byte[bufferSize] };
            int[] length = { 0, 0 };
            int index = 0;
            Task<int> read = input.ReadAsync(buffer[index], 0, buffer[index].Length);
            Task write = null;

            while (true)
            {
                await read;
                length[index] = read.Result;

                // if zero bytes read, the copy is complete
                if (length[index] == 0)
                    break;

                // wait for the in-flight write operation, if one exists, to complete
                // the only time one won't exist is after the very first read operation completes
                if (write != null)
                    await write;

                // start the new write operation
                write = output.WriteAsync(buffer[index], 0, length[index]);

                // toggle the current, in-use buffer
                // and start the read operation on the new buffer.
                //
                // Changed to use XOR to toggle between 0 and 1.
                // A little speedier than using a ternary expression.
                index ^= 1; // bufno = ( bufno == 0 ? 1 : 0 ) ;

                read = input.ReadAsync(buffer[index], 0, buffer[index].Length);
            }

            // wait for the final in-flight write operation, if one exists, to complete
            // the only time one won't exist is if the input stream is empty.
            if (write != null)
                await write;

            output.Flush();

            // return to the caller ;
            return;
        }
    }
}
