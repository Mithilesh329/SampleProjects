using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SampleProjects
{
    /// <summary>
    /// A simple BloomFilter class for string items which uses two hash functions to create a bloom filter of given size. 
    /// </summary>
    public class BloomFilter
    {
        readonly int bloomFilterSize;
        readonly BitArray bitArray;
        readonly List<HashAlgorithm> algorithms;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size">Size of the bloom filter.</param>
        public BloomFilter(int size = 1000)
        {
            this.bloomFilterSize = size;
            this.bitArray = new BitArray(size, false);
            this.algorithms = new List<HashAlgorithm>();

            // Add two algorithms
            this.algorithms.Add(SHA1.Create());
            this.algorithms.Add(MD5.Create());
        }

        /// <summary>
        /// Adds item to the bloom filter.
        /// </summary>
        /// <param name="item">the item.</param>
        public void Add(string item)
        {
            foreach(HashAlgorithm algo in this.algorithms)
            {
                bitArray[GetHash(algo, item)] = true;
            }
        }

        /// <summary>
        /// Checks whether the item is part of the bloom filter or not.
        /// Because of bloomfilter property, false positives are possible but *not* false negatives.
        /// </summary>
        /// <param name="item">item to be checked.</param>
        /// <returns></returns>
        public bool Contains(string item)
        {
            return this.algorithms.All(ha => bitArray[GetHash(ha, item)]);
        }

        /// <summary>
        /// Internal method to get integral hash within bloom filter size from given hash function.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="item">The item for which hash is calculated.</param>
        /// <returns></returns>
        private int GetHash(HashAlgorithm hashAlgorithm, string item)
        {
            var hashValue = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(item));
            return Math.Abs(BitConverter.ToInt32(hashValue, 0) % bloomFilterSize);
        }
    }
}
