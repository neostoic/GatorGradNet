﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Utils<T>
    {
        ///
        /// Method to write a delimited file, given a generic enumerable.
        ///
        /// The type T
        /// an enumerable of type T
        /// The destination file info
        /// The delimiter ("," for example)
        public static void WriteDelimitedFile(IEnumerable<T> list, FileInfo saveFile, string delimiter)
        {
            if (list == null) return;
            using (StreamWriter sw = saveFile.CreateText())
            {
                PropertyInfo[] props = typeof(T).GetProperties();
                var headerNames = props.Select(x => x.Name);
                sw.WriteLine(string.Join(delimiter, headerNames.ToArray()));
                foreach (T item in list)
                {
                    T item1 = item; // to prevent access to modified closure
                    var values = props.Select(x => x.GetValue(item1, null) ?? "") // the null coalescing operator, replace null with ""
                    .Select(x => x.ToString())
                    .Select(x => x.Contains(delimiter) ? "\"" + x + "\"" : x); // if a value contains the delimiter, surround with quotes
                    sw.WriteLine(string.Join(delimiter, values.ToArray()));
                }
                sw.Close();
            }
        }
        public static void WriteDelimitedFile(IEnumerable<T> list, FileInfo saveFile, string delimiter, string headers)
        {
            if (list == null) return;
            using (StreamWriter sw = saveFile.CreateText())
            {
                PropertyInfo[] props = typeof(T).GetProperties().Where(x => x.Name != headers).ToArray();
                var headerNames = props.Select(x => x.Name);
                sw.WriteLine(string.Join(delimiter, headerNames.ToArray()));
                foreach (T item in list)
                {
                    T item1 = item; // to prevent access to modified closure
                    var values = props.Select(x => x.GetValue(item1, null) ?? "") // the null coalescing operator, replace null with ""
                    .Select(x => x.ToString())
                    .Select(x => x.Contains(delimiter) ? "\"" + x + "\"" : x); // if a value contains the delimiter, surround with quotes
                    sw.WriteLine(string.Join(delimiter, values.ToArray()));
                }
                sw.Close();
            }
        }
        public static void WriteDelimitedFile(IEnumerable<T> list, FileInfo saveFile, string delimiter, string headers, string headers2)
        {
            if (list == null) return;
            using (StreamWriter sw = saveFile.CreateText())
            {
                PropertyInfo[] props = typeof(T).GetProperties().Where(x => x.Name != headers && x.Name != headers2).ToArray();
                var headerNames = props.Select(x => x.Name);
                sw.WriteLine(string.Join(delimiter, headerNames.ToArray()));
                foreach (T item in list)
                {
                    T item1 = item; // to prevent access to modified closure
                    var values = props.Select(x => x.GetValue(item1, null) ?? "") // the null coalescing operator, replace null with ""
                    .Select(x => x.ToString())
                    .Select(x => x.Contains(delimiter) ? "\"" + x + "\"" : x); // if a value contains the delimiter, surround with quotes
                    sw.WriteLine(string.Join(delimiter, values.ToArray()));
                }
                sw.Close();
            }
        }
        public static T TrimStringProperties(T input)
        {
            var stringProperties = input.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                string currentValue = (string)stringProperty.GetValue(input, null);
                if (currentValue != null)
                    stringProperty.SetValue(input, currentValue.Trim(), null);
            }
            return input;
        }

        public static IList<T> TrimStringProperties(IEnumerable<T> list)
        {
            IList<T> newList = new List<T>();
            foreach (var item in list)
            {
                newList.Add(TrimStringProperties(item));
            }
            return newList;
        }


        public static void WriteDelimitedFile(IEnumerable<T> list, FileInfo saveFile, string delimiter,List<string> headers)
        {
            if (list == null) return;
            using (StreamWriter sw = saveFile.CreateText())
            {
                PropertyInfo[] props = typeof(T).GetProperties().Where(x => headers.Contains(x.Name)).ToArray();
                var headerNames = props.Select(x => x.Name);
                sw.WriteLine(string.Join(delimiter, headerNames.ToArray()));
                foreach (T item in list)
                {
                    T item1 = item; // to prevent access to modified closure
                    var values = props.Select(x => x.GetValue(item1, null) ?? "") // the null coalescing operator, replace null with ""
                    .Select(x => x.ToString())
                    .Select(x => x.Contains(delimiter) ? "\"" + x + "\"" : x); // if a value contains the delimiter, surround with quotes
                    sw.WriteLine(string.Join(delimiter, values.ToArray()));
                    
                }
                sw.Close();
            }
        }

        public static void WriteSalaryToDelimitedFile(IEnumerable<T> list, FileInfo saveFile, string delimiter, List<string>headers)
        {
            if (list == null) return;
            using (StreamWriter sw = saveFile.CreateText())
            {
                PropertyInfo[] props = typeof(T).GetProperties().Where(x => headers.Contains(x.Name)).ToArray();
                var headerNames = props.Select(x => x.Name);
                List<string> salheaders=new List<string>();
                salheaders.Add("SalaryType");
                salheaders.Add("Value");



                sw.WriteLine(string.Join(delimiter, salheaders.ToArray()));
                foreach (T item in list)
                {
                    for(int count=1;count<=headerNames.Count()-1;count++){
                    sw.Write(headerNames.ElementAt(count));
                    
                    
                    T item1 = item; // to prevent access to modified closure
                    var values = props.Select(x => x.GetValue(item1, null) ?? "") // the null coalescing operator, replace null with ""
                    .Select(x => x.ToString())
                    .Select(x => x.Contains(delimiter) ? "\"" + x + "\"" : x); // if a value contains the delimiter, surround with quotes
                    sw.WriteLine(delimiter+values.ElementAt(count));
                        //sw.WriteLine(string.Join(delimiter, values.ToArray()));
                    }

                }
                sw.Close();
            }
        }

    }
}
