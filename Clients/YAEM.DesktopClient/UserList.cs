// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserList.cs" company="Florian Amstutz">
//   Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace YAEM.DesktopClient
{
    using System.Collections.ObjectModel;

    using YAEM.Domain;

    /// <summary>
    /// Contains a list of <see cref="User"/>.
    /// </summary>
    public class UserList : ObservableCollection<User>
    {
    }
}
