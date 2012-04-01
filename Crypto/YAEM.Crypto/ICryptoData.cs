namespace YAEM.Crypto
{
    /// <summary>
    /// Contains all necessary information in order to instanciate a <see cref="ICryptoProvider"/>.
    /// </summary>
    public interface ICryptoData
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        byte[] Key { get; }

        /// <summary>
        /// Gets or sets the initalization vector.
        /// </summary>
        /// <value>
        /// The initalization vector.
        /// </value>
        byte[] InitalizationVector { get; }
    }
}
