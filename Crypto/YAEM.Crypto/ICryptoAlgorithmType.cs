// -----------------------------------------------------------------------
// <copyright file="CryptoAlgorithmCapabilities.cs" company="ERNI Consulting AG">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using YAEM.Domain;

namespace YAEM.Crypto
{
    public interface ICryptoAlgorithmType
    {
        CryptoAlgorithm Algorithm { get; }
    }
}
