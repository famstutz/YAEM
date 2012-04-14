// -----------------------------------------------------------------------
// <copyright file="IServiceCallback.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace YAEM.Contracts
{
    using System.ServiceModel;
    using Domain;

    /// <summary>
    /// The service callback.
    /// </summary>
    [ServiceContract]
    public interface IServiceCallback
    {
        /// <summary>
        /// Notifies the user joined.
        /// </summary>
        /// <param name="user">The user.</param>
        [OperationContract(IsOneWay = true)]
        void NotifyUserJoined(User user);

        /// <summary>
        /// Notifies the user left.
        /// </summary>
        /// <param name="user">The user.</param>
        [OperationContract(IsOneWay = true)]
        void NotifyUserLeft(User user);

        /// <summary>
        /// Notifies the new message.
        /// </summary>
        /// <param name="message">The message.</param>
        [OperationContract(IsOneWay = true)]
        void NotifyNewMessage(Message message);

        /// <summary>
        /// Notifies the negotiate initialization vector.
        /// </summary>
        /// <param name="initializationVector">The initialization vector.</param>
        /// <param name="algorithm">The algorithm.</param>
        [OperationContract(IsOneWay = true)]
        void NotifyNegotiateInitializationVector(byte[] initializationVector, CryptoAlgorithm algorithm);

        /// <summary>
        /// Notifies the negotiate initialization vector.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="algorithm">The algorithm.</param>
        [OperationContract(IsOneWay = true)]
        void NotifyNegotiateKey(byte[] key, CryptoAlgorithm algorithm);
    }
}
