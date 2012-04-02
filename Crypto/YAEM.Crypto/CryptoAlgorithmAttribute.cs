// -----------------------------------------------------------------------
// <copyright file="CryptoAlgorithmAttribute.cs" company="ERNI Consulting AG">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using YAEM.Domain;

namespace YAEM.Crypto
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CryptoAlgorithmAttribute : ExportAttribute
    {
        public CryptoAlgorithmAttribute() : base(typeof(ICryptoProvider)) { }
        public CryptoAlgorithm Algorithm { get; set; }
    }
}
